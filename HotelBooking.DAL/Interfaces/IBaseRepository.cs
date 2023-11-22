using HotelBooking.Domain.Entity;

namespace HotelBooking.DAL.Interfaces;

public interface IBaseRepository<T>
{
    Task<bool> CreateAsync(T entity);

    Task<T> GetAsync(int id);

    Task<List<T>> SelectAsync();

    Task<bool> DeleteAsync(T entity); 
}