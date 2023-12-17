using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels;

namespace HotelBooking.Service.Interfaces;

public interface IHotelService
{
    Task<IBaseResponse<IEnumerable<GetHotelsViewModel>>> GetHotels();
    Task<IBaseResponse<GetHotelViewModel>> GetHotel(int id);
    Task<IBaseResponse<Hotel>> GetHotelByName(string name);
    Task<IBaseResponse<bool>> DeleteHotel(int id);
    Task<IBaseResponse<CreateHotelViewModel>> CreateHotel(CreateHotelViewModel createHotelVm);
    Task<IBaseResponse<Hotel>> EditHotel(CreateHotelViewModel createHotelVm);
    BaseResponse<Dictionary<int, string>> GetTypes();
}