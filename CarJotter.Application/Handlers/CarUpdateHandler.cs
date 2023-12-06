using CarJotter.Application.Commands;
using CarJotter.Application.DTOs;
using CarJotter.Core.Entities;
using CarJotter.Core.Interfaces.Repositories;
using MediatR;

namespace CarJotter.Application.Handlers;
public class CarUpdateHandler : IRequestHandler<CarUpdateCommand, CarDTO>
{
    private readonly ICarRepository _carRepository;

    public CarUpdateHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public Task<CarDTO> Handle(CarUpdateCommand request, CancellationToken cancellationToken)
    {
        var car = _carRepository.Get(request.Id);

        if (car == null)
        {
            return Task.FromResult<CarDTO>(null);
        }

        car.Brand = request.Brand ?? car.Brand;
        car.Model = request.Model ?? car.Model;
        car.Year = request.Year.HasValue ? request.Year.Value : car.Year;
        car.LicensePlate = request.LicensePlate ?? car.LicensePlate;

        _carRepository.Update(car);
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

