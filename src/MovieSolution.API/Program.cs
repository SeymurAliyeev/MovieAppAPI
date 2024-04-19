using MovieSolution.Data;
using MovieSolution.Business;
using MovieSolution.Data.Context;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using MovieSolution.Business.DTOs.MovieDTOs;
using MovieSolution.Business.DTOValidators.MovieDTOValidators;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(m =>
{
    m.RegisterValidatorsFromAssembly(typeof(MovieCreateDtoValidator).Assembly);
});
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddDbContext<AppDbContext>( opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
