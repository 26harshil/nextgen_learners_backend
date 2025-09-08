using Microsoft.EntityFrameworkCore;
using BrightMindQuizApi.Data;
using Microsoft.OpenApi.Models;
using System.Text.Json;

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

// // EF Core with retry logic
// builder.Services.AddDbContext<BrightMindContext>(options =>
//     options.UseSqlServer(
//         builder.Configuration.GetConnectionString("DefaultConnection"),
//         // builder.Configuration.GetConnectionString("BrightMindDb"),
//         sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
//             maxRetryCount: 5, // Retry up to 5 times
//             maxRetryDelay: TimeSpan.FromSeconds(10), // Wait up to 10 seconds between retries
//             errorNumbersToAdd: null))); // Use default transient error codes


builder.Services.AddDbContext<BrightMindContext>(options => 
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

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

app.Run();