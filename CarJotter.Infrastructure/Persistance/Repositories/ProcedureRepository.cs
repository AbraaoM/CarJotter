using CarJotter.Core.Interfaces.Repositories;
using CarJotter.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarJotter.Infrastructure.Persistance.Repositories;
public class ProcedureRepository : BaseRepository<ProcedureEntity>, IProcedureRepository
{
    public readonly ApplicationDbContext _context;
    public ProcedureRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
