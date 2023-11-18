using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Application.Mapper;
using WeatherCheckApi.Domain.Entities;
using WeatherCheckApi.Domain.Interfaces;
using WeatherCheckApi.Infrastructure.Adapters;
using WeatherCheckApi.Infrastructure.Data.DB;
using WeatherCheckApi.Infrastructure.Repositories;
using WeatherCheckApi.Interfaces;
using WeatherCheckApi.Middlewares;
using WeatherCheckApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = builder.Configuration.GetSection("IdentityServer:Authority").Value;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration.GetSection("IdentityServer:Audience").Value,
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration.GetSection("IdentityServer:Issuer").Value,

                };
                options.RequireHttpsMetadata = false;

            });
builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddScoped<IAuthIndentityServerServiceProvider, AuthIdentityServerServiceProvider>();
builder.Services.AddScoped<IAuthServiceAdapter, AuthServiceAdapter>();
builder.Services.AddScoped<WeatherApiService>();
builder.Services.AddScoped<IWeatherRepo, WeatherRepo>();
builder.Services.AddScoped<IWeatherApi, WeatherApiAdapter>();
builder.Services.AddScoped<IWeatherApiProvider, WeatherApiProvider>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        // Add a security definition for the API key in Swagger
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.ApiKey,
            Name = AuthConstants.ApiKeyHeaderName,
            In = ParameterLocation.Header,
            Description = "WT Authorization header using the Bearer scheme",
            Scheme = "Bearer"
        });

        // Add a Schema to key header
        var scheme = new OpenApiSecurityScheme
        {

            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            In = ParameterLocation.Header,
        };

        // Add Requirements
        var requirement = new OpenApiSecurityRequirement
    {
        {scheme, new List<string>() }
    };
        c.AddSecurityRequirement(requirement);

    }

    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetailsExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
