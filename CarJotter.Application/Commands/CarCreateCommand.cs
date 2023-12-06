using CarJotter.Application.DTOs;
using MediatR;

namespace CarJotter.Application.Commands;
public class CarCreateCommand : IRequest<CarDTO>
{
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string LicensePlate { get; set; } = default!;
    public int Year { get; set; }
}
