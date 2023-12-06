using CarJotter.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarJotter.Infrastructure.Persistance.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context) : base()
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public T? Get(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public IList<T>? GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }
}
