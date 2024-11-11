using Microsoft.EntityFrameworkCore;
using TaskStream.BusinessLayer.Interfaces;
using TaskStream.DataAccessLayer.Data;
using TaskStream.DataAccessLayer.Interfaces;

namespace TaskStream.DataAccessLayer.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbset;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbset = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbset.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbset.FindAsync(id);
    }

    public async Task<bool> AddAsync(T entity)
    {
        try
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }


    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
            return true;

        }
        catch
        {
            return false;
        }
    }
    

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity=await _dbset.FindAsync(id);
        if (entity!=null)
        {
            _dbset.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}