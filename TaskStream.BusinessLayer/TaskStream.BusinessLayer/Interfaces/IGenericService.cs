namespace TaskStream.BusinessLayer.Interfaces;

public interface IGenericService<T> where T : class
{
   
    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByIdAsync(Guid id);

    Task<bool> AddAsync(T entity);

    Task<bool> UpdateAsync(T entity);

    Task<bool> DeleteAsync(Guid id);
}