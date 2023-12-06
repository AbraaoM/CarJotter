using CarJotter.Application.DTOs;
using MediatR;

namespace CarJotter.Application.Queries;
public class CarGetAllQuery : IRequest<List<CarDTO>>
{
}
