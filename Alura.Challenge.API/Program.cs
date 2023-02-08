using Alura.Challenge.API.Extensions;
using Alura.Challenge.Infrastructure.Data.Context;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidators();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "Alura.Challenge.API.xml");
    c.IncludeXmlComments(filePath);
});

builder.Services.AddDbContext<AluraFlixContext>(opt => 
    opt
    .UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration
                    .GetConnectionString("Default")
    ).EnableSensitiveDataLogging()
);

builder.Services.AddServices().AddRepositories();

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
