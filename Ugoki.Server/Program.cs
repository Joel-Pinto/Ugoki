
using Ugoki.Data;
using Ugoki.Application.Common;
using Ugoki.Application.Services;


using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Ugoki.Application.Interfaces;
using Ugoki.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Dependency Injections have a lifecycle of an HTTP request, it's also scoped for that same request. It does not share with other requests.
builder.Services.AddScoped<IAuthService, AuthService>();        // Dependency Injection for the Auth Service
builder.Services.AddScoped<IUserRepository, UserRepository>();  // Dependency Injection for the User Repository
builder.Services.AddScoped<UserService>();                      // Dependency Injection for the User 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();          // Dependency Injection for the Unit of work, which takes care of making sure the saves to the DB happen securely and data is not compromised. 

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
