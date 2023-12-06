using CarJotter.Application.Queries;
using CarJotter.Application.DTOs;
using CarJotter.Core.Entities;
using CarJotter.Core.Interfaces.Repositories;
using MediatR;

namespace CarJotter.Application.Handlers;
public class CarGetByIdHandler : IRequestHandler<CarGetByIdQuery, CarDTO>
{
    private readonly ICarRepository _carRepository;

    public CarGetByIdHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public Task<CarDTO> Handle(CarGetByIdQuery request, CancellationToken cancellationToken)
    {
        var car = _carRepository.Get(request.Id);

        if (car == null)
        {
            return null;
        }

        return Task.FromResult(new CarDTO
        {
            Id = car.Id,
            Brand = car.Brand,
            Model = car.Model,
            Year = car.Year,
            LicensePlate = car.LicensePlate,
        });
    }
}

