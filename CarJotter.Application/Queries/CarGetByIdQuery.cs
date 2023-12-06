using CarJotter.Application.DTOs;
using MediatR;

namespace CarJotter.Application.Queries;
public class CarGetByIdQuery : IRequest<CarDTO>
{
    public int Id { get; set; }
}
