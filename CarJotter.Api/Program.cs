using CarJotter.Application.Commands;
using CarJotter.Application.Queries;
using CarJotter.Application.DTOs;
using CarJotter.Application.Handlers;
using CarJotter.Core.Interfaces.Repositories;
using CarJotter.Infrastructure;
using CarJotter.Infrastructure.Persistance.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), 
        b => b.MigrationsAssembly("CarJotter.Api"));
});

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddScoped<IRequestHandler<CarCreateCommand, CarDTO>, CarCreateHandler>();
builder.Services.AddScoped<IRequestHandler<CarUpdateCommand, CarDTO>, CarUpdateHandler>();
builder.Services.AddScoped<IRequestHandler<CarDeleteCommand>, CarDeleteHandler>();
builder.Services.AddScoped<IRequestHandler<CarGetAllQuery, List<CarDTO>>, CarGetAllHandler>();
builder.Services.AddScoped<IRequestHandler<CarGetByIdQuery, CarDTO>, CarGetByIdHandler>();


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
