using CarJotter.Application.DTOs;
using MediatR;

namespace CarJotter.Application.Queries;
public class ProcedureGetAllQuery : IRequest<List<ProcedureDTO>>
{
}
