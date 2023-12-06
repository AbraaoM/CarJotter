using MediatR;

namespace CarJotter.Application.Commands;
public class CarDeleteCommand : IRequest
{
    public int Id { get; set; }
}
