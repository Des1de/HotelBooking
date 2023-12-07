using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.HotelRoom;

namespace HotelBooking.Service.Interfaces;

public interface IHotelRoomService
{
    Task<IBaseResponse<IEnumerable<HotelRoom>>> GetHotels();
    Task<IBaseResponse<HotelRoom>> GetHotel(int id);
    Task<IBaseResponse<HotelRoom>> GetHotelByName(string name);
    Task<IBaseResponse<bool>> DeleteHotel(int id);
    Task<IBaseResponse<HotelRoomViewModel>> CreateHotel(HotelRoomViewModel hotelRoomVM);
    Task<IBaseResponse<HotelRoom>> EditHotel(HotelRoomViewModel hotelRoomVM); 
}