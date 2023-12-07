using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.HotelRoom;
using HotelBooking.Service.Interfaces;

namespace HotelBooking.Service.Implementations;

public class HotelRoomService : IHotelRoomService
{
    public Task<IBaseResponse<IEnumerable<HotelRoom>>> GetHotels()
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<HotelRoom>> GetHotel(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<HotelRoom>> GetHotelByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<bool>> DeleteHotel(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<HotelRoomViewModel>> CreateHotel(HotelRoomViewModel hotelRoomVM)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<HotelRoom>> EditHotel(HotelRoomViewModel hotelRoomVM)
    {
        throw new NotImplementedException();
    }
}