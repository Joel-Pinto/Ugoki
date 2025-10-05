
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

using Ugoki.Data;
using Ugoki.Data.Models;
using Ugoki.Data.Repositories;
using Ugoki.Application.Interfaces;


var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<UgokiDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// In here we add Authorization and Authentication services to the application
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<UgokiDbContext>()
    .AddApiEndpoints()
    .AddDefaultTokenProviders();

// Dependency Injections have a lifecycle of an HTTP request, it's also scoped for that same request. It does not share with other requests.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  // Dependency Injection  
//builder.Services.AddScoped<UserService>();              // Dependency Injection  


// Activate CORS (mecanismo de segurança do browser, para pedidos entre diferentes portas) because the request is coming from a different PORT, the port from which VITE is being ran
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient",
            policy => policy.WithOrigins("https://localhost:64749") // Vue dev server
                        .AllowAnyHeader()
                        .AllowAnyMethod()); // This last option is not good, find a better way to solve the issue
});

// Add services to the container. 
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Add the default pages?
builder.Services.AddControllersWithViews();


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

// Must be in this order!
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<User>();

app.MapFallbackToFile("/index.html");

app.Run();
