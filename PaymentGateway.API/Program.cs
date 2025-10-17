using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Application.Handlers;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDapperRepository, DbConnectionFactory>();
 
 
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure
 
    app.UseSwagger();
    app.UseSwaggerUI();
 

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
