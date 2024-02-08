using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Configurations;
using Persistence.Repository;
using Presentation;
using Services;
using Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment env = builder.Environment;
const string _cors = "cors";

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(PresentationAssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB
builder.Services.AddDbContextPool<RepositoryDbContext>(builder =>
{
    var connectionString = configuration.GetConnectionString("Database");
    builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Persistence"));
});

// My Services
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

// Configurations
builder.Services.Configure<PageSettings>(
    builder.Configuration.GetSection("PageSettings")
);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _cors,
            policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(_cors);

app.UseAuthorization();

app.MapControllers();

app.Run();
