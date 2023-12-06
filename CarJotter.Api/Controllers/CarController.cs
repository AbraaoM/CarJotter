using Microsoft.AspNetCore.Mvc;
using CarJotter.Application.DTOs;
using CarJotter.Application.Commands;
using CarJotter.Application.Queries;
using CarJotter.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using CarJotter.Core.Entities;
using MediatR;

namespace CarJotter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly ICarRepository _carRepository;
    private readonly IMediator _mediator;

    public CarController(
        ILogger<CarController> logger, 
        ICarRepository carRepository,
        IMediator mediator)
    {
        _logger = logger;
        _carRepository = carRepository;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetCars")]
    public ActionResult<IList<CarDTO>> GetAll()
    {
        var cars = _mediator.Send(new CarGetAllQuery());
        if (cars == null)
        {
            return NotFound();
        }
        return Ok(cars.Result);
    }

    [HttpGet("{Id}", Name = "GetCarById")]
    public ActionResult<CarDTO> GetById([FromRoute] CarGetByIdQuery query)
    {
        var car = _mediator.Send(query);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car.Result);
    }

    [HttpPost(Name = "AddCar")]
    public ActionResult<CarDTO> Add([FromBody] CarCreateCommand command)
    {
        var car = _mediator.Send(command);

        return CreatedAtRoute("GetCars", new { id = car.Id }, car);
    }

    [HttpPut(Name = "UpdateCar")]
    public ActionResult<CarDTO> Update([FromBody] CarUpdateCommand command)
    {
        var car = _mediator.Send(command);

        return CreatedAtRoute("GetCars", new { id = car.Id }, car);
    }

    [HttpDelete("{Id}", Name = "DeleteCar")]
    public void Delete([FromRoute] CarDeleteCommand command)
    {
        _mediator.Send(command);

        return;
    }
}
