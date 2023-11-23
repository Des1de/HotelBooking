using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels;

namespace HotelBooking.Service.Interfaces;

public interface IHotelService
{
    Task<IBaseResponse<IEnumerable<Hotel>>> GetHotels();
    Task<IBaseResponse<Hotel>> GetHotel(int id);
    Task<IBaseResponse<Hotel>> GetHotelByName(string name);
    Task<IBaseResponse<bool>> DeleteHotel(int id);
    Task<IBaseResponse<HotelViewModel>> CreateHotel(HotelViewModel hotelVM);
}