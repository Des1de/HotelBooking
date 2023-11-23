using HotelBooking.Domain.Entity;

namespace HotelBooking.DAL.Interfaces;

public interface IHotelRepository : IBaseRepository<Hotel>
{
    Task<Hotel> GetByNameAsync(string name); 
}