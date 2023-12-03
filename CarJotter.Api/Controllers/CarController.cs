using Microsoft.AspNetCore.Mvc;
using CarJotter.Application.DTOs;
using CarJotter.Application.Commands;
using CarJotter.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using CarJotter.Core.Entities;

namespace CarJotter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly ICarRepository _carRepository;

    public CarController(ILogger<CarController> logger, ICarRepository carRepository)
    {
        _logger = logger;
        _carRepository = carRepository;
    }

    [HttpGet(Name = "GetCars")]
    public ActionResult<IList<CarDTO>> GetAll()
    {
        var cars = _carRepository.GetAll();
        if (cars == null)
        {
            return NotFound();
        }

        return Ok(cars.Select(car => new CarDTO
        {
            Id = car.Id,
            Brand = car.Brand,
            Model = car.Model,
            Year = car.Year,
        }).ToList());
    }

    [HttpPost(Name = "AddCar")]
    public ActionResult<CarDTO> Add(CarCreateCommand command)
    {
        var car = new CarEntity
        {
            Brand = command.Brand,
            Model = command.Model,
            Year = command.Year,
            LicensePlate = command.LicensePlate,
        };
        _carRepository.Add(car);
        return CreatedAtRoute("GetCars", new { id = car.Id }, car);
    }
}
