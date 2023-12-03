using CarJotter.Core.Interfaces.Repositories;
using CarJotter.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarJotter.Infrastructure.Persistance.Repositories;
public class CarRepository : BaseRepository<CarEntity>, ICarRepository
{
    public readonly ApplicationDbContext _context;
    public CarRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
