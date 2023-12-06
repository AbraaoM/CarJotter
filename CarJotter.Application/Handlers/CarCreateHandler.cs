using CarJotter.Application.Commands;
using CarJotter.Application.DTOs;
using CarJotter.Core.Entities;
using CarJotter.Core.Interfaces.Repositories;
using MediatR;

namespace CarJotter.Application.Handlers;
public class CarCreateHandler : IRequestHandler<CarCreateCommand, CarDTO>
{
    private readonly ICarRepository _carRepository;

    public CarCreateHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public Task<CarDTO> Handle(CarCreateCommand request, CancellationToken cancellationToken)
    {
        var newCar = new CarEntity
        {
            Brand = request.Brand,
            Model = request.Model,
            Year = request.Year,
            LicensePlate = request.LicensePlate,
        };
        _carRepository.Add(newCar);
        return Task.FromResult(new CarDTO
        {
            Id = newCar.Id,
            Brand = newCar.Brand,
            Model = newCar.Model,
            Year = newCar.Year,
            LicensePlate = newCar.LicensePlate,
        });
    }
}

