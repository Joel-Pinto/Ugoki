using Ugoki.Data.Models;
using Ugoki.Application.Common;

using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Ugoki.Application.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDbContext<UgokiDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Activate CORS because the request is coming from a different PORT, the port from which VITE is being ran
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient",
            policy => policy.WithOrigins("http://localhost:64749") // Vue dev server
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()); // This last option is not good, find a better way to solve the issue
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("AllowClient");

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
