using Microsoft.OpenApi.Models;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Application.Mapper;
using WeatherCheckApi.Domain.Interfaces;
using WeatherCheckApi.Filters;
using WeatherCheckApi.Infrastructure.Data.DB;
using WeatherCheckApi.Infrastructure.Repositories;
using WeatherCheckApi.Mapper;
using WeatherCheckApi.Middlewares;
using WeatherCheckApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddAutoMapper(typeof(PresentationMappingProfile));


builder.Services.AddScoped<ApiKeyAuthenticationFilter>();
builder.Services.AddScoped<WeatherApiService>();
builder.Services.AddScoped<IWeatherRepo, WeatherRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        // Add a security definition for the API key in Swagger
        c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.ApiKey,
            Name = AuthConstants.ApiKeyHeaderName,
            In = ParameterLocation.Header,
            Description = "API key for authentication"
        });

        // Add a Schema to key header
        var scheme = new OpenApiSecurityScheme
        {

            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "ApiKey"
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

builder.Services.AddHttpClient();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetailsExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
