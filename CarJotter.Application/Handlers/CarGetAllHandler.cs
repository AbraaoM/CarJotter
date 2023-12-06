using CarJotter.Application.Queries;
using CarJotter.Application.DTOs;
using CarJotter.Core.Entities;
using CarJotter.Core.Interfaces.Repositories;
using MediatR;

namespace CarJotter.Application.Handlers;
public class CarGetAllHandler : IRequestHandler<CarGetAllQuery, List<CarDTO>>
{
    private readonly ICarRepository _carRepository;

    public CarGetAllHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public Task<List<CarDTO>> Handle(CarGetAllQuery request, CancellationToken cancellationToken)
    {
        var cars = _carRepository.GetAll();

        if (cars == null)
        {
            return null;
        }

        return Task.FromResult(cars.Select(car => new CarDTO
        {
            Id = car.Id,
            Brand = car.Brand,
            Model = car.Model,
            Year = car.Year,
            LicensePlate = car.LicensePlate,
        }).OrderBy(c => c.Id).ToList());
    }
}

