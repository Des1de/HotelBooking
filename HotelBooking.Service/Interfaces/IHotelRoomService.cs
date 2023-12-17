using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.HotelRoom;

namespace HotelBooking.Service.Interfaces;

public interface IHotelRoomService
{
    Task<IBaseResponse<IEnumerable<GetHotelRoomsViewModel>>> GetHotelRooms(int hotelId);
    Task<IBaseResponse<HotelRoom>> GetHotelRoom(int id);
    Task<IBaseResponse<HotelRoom>> GetHotelRoomByName(string name);
    Task<IBaseResponse<bool>> DeleteHotelRoom(int id);
    Task<IBaseResponse<CreateHotelRoomViewModel>> CreateHotelRoom(CreateHotelRoomViewModel getHotelRoomsVm, int hotelId);
    Task<IBaseResponse<HotelRoom>> EditHotelRoom(GetHotelRoomsViewModel getHotelRoomsVm);
    BaseResponse<Dictionary<int, string>> GetTypes();
}