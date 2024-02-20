using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleBlue.API.Filters;
using ScheduleBlue.Application.Queries.GetAllSchedule;
using ScheduleBlue.Application.Validators;
using ScheduleBlue.Core.Repositories;
using ScheduleBlue.Infrastructure.Persistence;
using ScheduleBlue.Infrastructure.Persistence.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();

builder.Services.AddControllers(option => option.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddUserCommandValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(GetAllScheduleQuery));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("cosapp");

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();
