using dotnet;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MySQLDBContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        // var host = Environment.GetEnvironmentVariable("DBHOST") ?? "localhost";
        // var port = Environment.GetEnvironmentVariable("DBPORT") ?? "3306";
        // var password = Environment.GetEnvironmentVariable("DBPASSWORD") ?? "password";
        // var connectionString = $"server={host};userid=root;pwd={password};port={port};database=super-app";
        Console.WriteLine($"Connection String is: {connectionString}");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Remove this line
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();