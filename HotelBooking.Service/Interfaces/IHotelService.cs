using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Response;

namespace HotelBooking.Service.Interfaces;

public interface IHotelService
{
    Task<IBaseResponse<IEnumerable<Hotel>>> GetHotels(); 
}