using GreenMarket.API.Configurations;
using GreenMarket.API.Middleware;
using GreenMarket.Application;
using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure;
using GreenMarket.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);

// DI appSetting.jwt
builder.Services.AddSingleton(appSettings.Jwt);

// Register API Services, Swagger, ...
builder.Services.AddApiServices(builder.Configuration);

// DBContext, Redis, ...
builder.Services.AddInfrastructure(appSettings.ConnectionStrings.DefaultConnection);

// Register Application Services (MediatR, AutoMapper, FluentValidation)
builder.Services.AddApplicationServices();

// Register Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Config Authentication (Placed after Registere identity)
builder.Services.ConfigureAuthentication(appSettings.Jwt);

// Register CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Build a swagger endpoint for each discovered API version
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var groupNames = app.DescribeApiVersions().Select(description => description.GroupName);    
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

//app.UseHttpsRedirection();

// app use these
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAnyOrigin");

app.UseExceptionMiddleware();
app.MapControllers();
app.Run();
