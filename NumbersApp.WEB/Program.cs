using NumbersApp.WEB.Interfaces;
using NumbersApp.WEB.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<INumbersService, NumbersService>();

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
