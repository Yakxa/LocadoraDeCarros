using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TesteLocadoraDeCarros.Dal;
using TesteLocadoraDeCarros.Domain.Validators.CarroValidators;
using Microsoft.AspNetCore.Mvc;
using TesteLocadoraDeCarros.Application.UserProfiles.Queries;
using MediatR;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra todos os Profiles do AutoMapper
builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllUserProfiles));
// Registra todos os Profiles do MediatR
builder.Services.AddMediatR(typeof(GetAllUserProfiles));

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