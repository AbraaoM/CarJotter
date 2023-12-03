namespace CarJotter.Core.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    IList<T>? GetAll();
    T? Get(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
}


