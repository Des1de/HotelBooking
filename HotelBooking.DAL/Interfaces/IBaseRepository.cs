using HotelBooking.Domain.Entity;

namespace HotelBooking.DAL.Interfaces;

public interface IBaseRepository<T>
{
    Task<bool> CreateAsync(T entity);


    IQueryable<T> GetAll();

    Task<bool> DeleteAsync(T entity);

    Task<T> UpdateAsync(T entity); 
}