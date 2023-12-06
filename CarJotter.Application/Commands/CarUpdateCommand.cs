using CarJotter.Application.DTOs;
using MediatR;

namespace CarJotter.Application.Commands;
public class CarUpdateCommand : IRequest<CarDTO>
{
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? LicensePlate { get; set; }
    public int? Year { get; set; }
}
