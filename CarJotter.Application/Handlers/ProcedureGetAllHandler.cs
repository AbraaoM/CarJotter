using CarJotter.Application.Queries;
using CarJotter.Application.DTOs;
using CarJotter.Core.Entities;
using CarJotter.Core.Interfaces.Repositories;
using MediatR;

namespace CarJotter.Application.Handlers;
public class ProcedureGetAllHandler : IRequestHandler<ProcedureGetAllQuery, List<ProcedureDTO>>
{
    private readonly IProcedureRepository _procedureRepository;

    public ProcedureGetAllHandler(IProcedureRepository procedureRepository)
    {
        _procedureRepository = procedureRepository;
    }
    public Task<List<ProcedureDTO>> Handle(ProcedureGetAllQuery request, CancellationToken cancellationToken)
    {
        var procedures = _procedureRepository.GetAll(); 

        if (procedures == null) return null;

        return Task.FromResult(procedures.Select(procedure => new ProcedureDTO
        {
            Id = procedure.Id,
            Title = procedure.Title,
            Description = procedure.Description,
            Car = procedure.Car,
        }).OrderBy(c => c.Id).ToList());
    }
}

