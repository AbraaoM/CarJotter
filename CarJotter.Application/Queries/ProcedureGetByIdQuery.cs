using CarJotter.Application.DTOs;
using MediatR;

namespace CarJotter.Application.Queries;
public class ProcedureGetByIdQuery : IRequest<ProcedureDTO>
{
    public int Id { get; set; }
}
