using GreenMarket.API.Configurations;
using GreenMarket.Application;
using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure;
using GreenMarket.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);

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

app.UseHttpsRedirection();

// app use these
app.UseCors("AllowAnyOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
