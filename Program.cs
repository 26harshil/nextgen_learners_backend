using Microsoft.EntityFrameworkCore;
using BrightMindQuizApi.Data;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using BrightMindQuizApi.Models;

var builder = WebApplication.CreateBuilder(args);
//  "DefaultConnection":"Host=dpg-d2s7v2odl3ps73bn9mv0-a.singapore-postgres.render.com;Port=5432;Database=db_nextgen_learners;Username=harshil;Password=3gKsPTp0YWWSAdGmbNZsUxXoUPd49okl;Sslmode=require;TrustServerCertificate=true;"
// Services
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BrightMind Quiz API", Version = "v1" });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<BrightMindContext>(options =>
{
    options.UseNpgsql(connectionString, npgsqlOptions =>
    {
        npgsqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorCodesToAdd: null);
        npgsqlOptions.CommandTimeout(30);
    });

    if (builder.Environment.IsDevelopment())
    {
        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging();
    }
});

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Ensure database exists on startup (creates tables if missing)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BrightMindContext>();
    try
    {
        db.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "Failed to ensure database is created");
    }
}

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Keep commented if no HTTPS binding in IIS
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.MapGet("/", () => Results.Ok("Healthy ✅"));

app.MapGet("/health/db", async (BrightMindContext db) =>
{
    try
    {
        var canConnect = await db.Database.CanConnectAsync();
        return canConnect ? Results.Ok("Database connection OK") : Results.Problem("Database connection failed");
    }
    catch (Exception ex)
    {
        return Results.Problem($"DB health check failed: {ex.Message}");
    }
});

app.MapGet("/health/schema", async (BrightMindContext db) =>
{
    try
    {
        var anyQuestion = await db.Questions.Take(1).Select(q => q.QuestionId).ToListAsync();
        return Results.Ok(new { ok = true, hasQuestions = anyQuestion.Any() });
    }
    catch (Exception ex)
    {
        return Results.Problem($"Schema check failed: {ex.Message}");
    }
});

app.Run();