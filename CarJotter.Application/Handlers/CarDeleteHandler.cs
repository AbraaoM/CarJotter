using CarJotter.Application.Commands;
using CarJotter.Application.DTOs;
using CarJotter.Core.Entities;
using CarJotter.Core.Interfaces.Repositories;
using MediatR;

namespace CarJotter.Application.Handlers;
public class CarDeleteHandler : IRequestHandler<CarDeleteCommand>
{
    private readonly ICarRepository _carRepository;

    public CarDeleteHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public Task Handle(CarDeleteCommand request, CancellationToken cancellationToken)
    {
        var car = _carRepository.Get(request.Id);

        if (car == null)
        {
            return null;
        }

        _carRepository.Delete(car);
        return Task.CompletedTask;
    }
}

