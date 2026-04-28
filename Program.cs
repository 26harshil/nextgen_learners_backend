using Microsoft.EntityFrameworkCore;
using BrightMindQuizApi.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//  "DefaultConnection":"Host=dpg-d2s7v2odl3ps73bn9mv0-a.singapore-postgres.render.com;Port=5432;Database=db_nextgen_learners;Username=harshil;Password=3gKsPTp0YWWSAdGmbNZsUxXoUPd49okl;Sslmode=require;TrustServerCertificate=true;"
// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BrightMind Quiz API",
        Version = "v1",
        Description = """
            REST API for the NextGen Learners kids quiz app.

            **Available Quiz Endpoints** (all under `/Quizz/`):
            | Route | Category | DB ID |
            |---|---|---|
            | `/Quizz/math` | Math for Kids | 1 |
            | `/Quizz/colors` | Color Trivia | 2 |
            | `/Quizz/fruits` | Fruit Trivia | 3 |
            | `/Quizz/animalname` | Ground Animal Trivia | 4 |
            | `/Quizz/birds` | Bird Trivia | 5 |
            | `/Quizz/vegetables` | Vegetable Trivia | 6 |
            | `/Quizz/vehicles` | Vehicle Trivia | 7 |
            | `/Quizz/basicshapes` | Basic Shapes | 11 |
            | `/Quizz/bodyparts` | Body Parts | 12 |
            | `/Quizz/weather` | Weather and Seasons | 14 |
            | `/Quizz/opposites` | Opposites | 15 |
            | `/Quizz/emotions` | Emotions & Feelings | 16 |
            | `/Quizz/ocenlife` | Ocean Life | 26 |
            | `/Quizz/animalhomes` | Animal Homes & Babies | 27 |
            | `/Quizz/musicalinstruments` | Musical Instruments | 28 |
            | `/Quizz/communityhelpers` | Community Helpers | 29 |
            | `/Quizz/babyanimals` | Baby Animals | 19 |
            """,
        Contact = new OpenApiContact { Name = "NextGen Learners" }
    });
    c.EnableAnnotations();
    c.TagActionsBy(api => new[] { "Quiz" });
    // Include XML comments for method summaries
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (System.IO.File.Exists(xmlPath)) c.IncludeXmlComments(xmlPath);
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

// Swagger — available at /swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BrightMind Quiz API v1");
    c.RoutePrefix = "swagger";  // access at /swagger
    c.DocumentTitle = "BrightMind Quiz API";
    c.DefaultModelsExpandDepth(-1); // hide models section by default
});

// app.UseHttpsRedirection(); // Keep commented if no HTTPS binding in IIS
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapGet("/health/db", async (BrightMindContext db) =>
{
    try
    {
        var canConnect = await db.Database.CanConnectAsync();
        return canConnect ? Results.Ok("DB OK") : Results.Problem("DB unreachable");
    }
    catch (Exception ex)
    {
        return Results.Problem($"DB error: {ex.GetBaseException().Message}");
    }
});

app.Run();