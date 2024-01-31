using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repository;
using Services;
using Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment env = builder.Environment;
const string _cors = "cors";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<RepositoryDbContext>(builder =>
{
    var connectionString = configuration.GetConnectionString("Database");
    builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Persistence"));
});

// My Services
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
