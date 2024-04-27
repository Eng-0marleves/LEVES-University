using LEVES_University.DBContext;
using LEVES_University.Interfaces;
using LEVES_University.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Database Configuration
builder.Services.AddDbContext<LevesEntities>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LevesUniversity")));

// Data Protection
builder.Services.AddDataProtection();

builder.Services.AddHttpContextAccessor();

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddSingleton<JwtService>();

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .WithOrigins("http://localhost:8080")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
});

builder.Services.AddEndpointsApiExplorer();

// Dependency Injection
#region services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISeedDataService, SeedDataService>();
builder.Services.AddScoped<ISemesterService, SemesterService>();
builder.Services.AddScoped<IStudentService, StudentService>();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// CORS
app.UseCors("CorsPolicy");

// Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
