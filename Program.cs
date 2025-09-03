
//using Microsoft.EntityFrameworkCore;
//using BrightMindQuizApi.Data;
//using Microsoft.OpenApi.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Services
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BrightMind Quiz API", Version = "v1" });
//});

//// EF Core (uses appsettings.json connection string named BrightMindDb)
//builder.Services.AddDbContext<BrightMindContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("BrightMindDb")));

//// (Optional, but recommended for Flutter/Web access)
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", builder =>
//    {
//        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//    });
//});


//var app = builder.Build();

//// Pipeline
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// If your IIS site only has HTTP binding, keep HTTPS redirection OFF.
//// If you have an HTTPS binding + certificate, enable the line below.
//// app.UseHttpsRedirection();
//app.UseCors("AllowAll");
//app.UseAuthorization();
//app.MapControllers();

//app.Run();


using Microsoft.EntityFrameworkCore;
using BrightMindQuizApi.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BrightMind Quiz API", Version = "v1" });
});

// EF Core with retry logic
builder.Services.AddDbContext<BrightMindContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BrightMindDb"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // Retry up to 5 times
            maxRetryDelay: TimeSpan.FromSeconds(10), // Wait up to 10 seconds between retries
            errorNumbersToAdd: null))); // Use default transient error codes

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

app.Run();