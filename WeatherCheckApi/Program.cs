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
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value)),


    };


});

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<ApiKeyAuthenticationFilter>();
builder.Services.AddScoped<WeatherApiService>();
builder.Services.AddScoped<IWeatherRepo, WeatherRepo>();
//builder.Services.AddScoped<IWeatherApi, WeatherApiProvider>();
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

builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetailsExceptionHandler();

app.UseHttpsRedirection();
//app.UseMiddleware<ApiKeyAuthenticationMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
