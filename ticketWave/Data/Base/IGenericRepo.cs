using ticketWave.Models;

namespace ticketWave.Data.Base
{
    public interface IGenericRepo<T> where T :class, IBaseEntity,  new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
