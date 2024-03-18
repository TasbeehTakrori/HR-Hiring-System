using HRHiringSystem.Persistence;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

