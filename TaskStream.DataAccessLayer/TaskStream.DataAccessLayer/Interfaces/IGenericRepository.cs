using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskStream.BusinessLayer.Interfaces;

public interface IGenericRepository<T> where T : class
{
     Task<IEnumerable<T>> GetAllAsync();
     Task<T> GetByIdAsync(Guid id); 
     Task<bool> AddAsync(T entity); 
     Task<bool> UpdateAsync(T entity); 
     Task<bool> DeleteAsync(Guid id); 
}
