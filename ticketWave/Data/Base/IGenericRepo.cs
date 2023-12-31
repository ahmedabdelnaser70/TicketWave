﻿using System.Linq.Expressions;
using ticketWave.Models;

namespace ticketWave.Data.Base
{
    public interface IGenericRepo<T> where T : BaseEntity,  new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
