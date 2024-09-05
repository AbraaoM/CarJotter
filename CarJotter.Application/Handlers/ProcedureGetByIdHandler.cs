using CarJotter.Application.Queries;
using CarJotter.Application.DTOs;
using CarJotter.Core.Entities;
using CarJotter.Core.Interfaces.Repositories;
using MediatR;

namespace CarJotter.Application.Handlers;
public class ProcedureGetByIdHandler : IRequestHandler<ProcedureGetByIdQuery, ProcedureDTO>
{
    private readonly IProcedureRepository _procedureRepository;

    public ProcedureGetByIdHandler(IProcedureRepository procedureRepository)
    {
        _procedureRepository = procedureRepository;
    }
    public Task<ProcedureDTO> Handle(ProcedureGetByIdQuery request, CancellationToken cancellationToken)
    {
        var procedure = _procedureRepository.Get(request.Id);

        if (procedure == null)
        {
            return null;
        }

        return Task.FromResult(new ProcedureDTO
        {
            Id = procedure.Id,
            Title = procedure.Title,
            Description = procedure.Description,
            Car = procedure.Car
        });
    }
}

