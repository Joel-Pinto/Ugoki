
using Ugoki.Data;
using Ugoki.Data.Repositories;
using Ugoki.Application.Services;
using Ugoki.Application.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// In here we add Authorization and Authentication services to the application
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"] ?? string.Empty)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
        };
    });

// Dependency Injections have a lifecycle of an HTTP request, it's also scoped for that same request. It does not share with other requests.
builder.Services.AddScoped<IAuthService, AuthRepositorie>();        // Dependency Injection for the Auth Service
builder.Services.AddScoped<IUserRepository, UserRepository>();  // Dependency Injection for the User Repository
builder.Services.AddScoped<UserService>();                      // Dependency Injection for the User 
builder.Services.AddScoped<AuthRepositorie>();
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
builder.Services.AddAuthentication().AddBearerToken();

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

// Must be in this order!
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
