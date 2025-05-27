using System.Reflection;
using Asp.Versioning;
using GreenMarket.API.Configurations;
using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure;
using GreenMarket.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GreenMarket.API",
        Version = "v1"
    });
});

var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);

// DBContext, Redis, ...
builder.Services.AddInfrastructure(appSettings.ConnectionStrings.DefaultConnection);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Register CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});


builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;
    options.ReportApiVersions = true;
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var groupNames = app.DescribeApiVersions().Select(description => description.GroupName);

        // Build a swagger endpoint for each discovered API version
        foreach (var groupName in groupNames)
        {
            options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant());
        }
    });
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

// app use these
app.UseCors("AllowAnyOrigin");
app.UseAuthentication();
app.UseAuthorization();
//

app.MapControllers();

app.Run();
