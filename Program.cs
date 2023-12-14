global using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Text;
using ApiWithAuth;
using AutoMapper;
using Library_System_Application;
using Library_System_Application.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
builder.Services.AddControllers();
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "admin authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                  Reference = new OpenApiReference
                  {
                      Id = "Bearer",
                      Type = ReferenceType.SecurityScheme
                  }
            },
            new List<string>()
        }
    });
});


builder.Services.AddDbContext<LibrarySystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=TRAVIS\\SQLEXPRESS;Database=LibrarySystem;Trusted_Connection=True;TrustServerCertificate=True;"));
});






builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                
    .AddJwtBearer(options =>
    {
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





builder.Services.AddDbContext<LibrarySystemContext>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMvc();
builder.Services.AddControllers();


builder.Services.AddMvc(options =>
{
    options.AllowEmptyInputInBodyModelBinding = true;
    foreach (var formatter in options.InputFormatters)
    {
        if (formatter.GetType() == typeof(SystemTextJsonInputFormatter))
            ((SystemTextJsonInputFormatter)formatter).SupportedMediaTypes.Add(
                Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("text/plain"));
    }
    
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(policyBuilder =>
    policyBuilder.AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(host => true).AllowAnyHeader());


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();



