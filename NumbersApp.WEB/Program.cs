using Microsoft.EntityFrameworkCore;
using NumbersApp.WEB.EF;
using NumbersApp.WEB.Interfaces;
using NumbersApp.WEB.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseInMemoryDatabase("NumbersDb"));

builder.Services.AddScoped<INumbersRepository, NumbersRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
