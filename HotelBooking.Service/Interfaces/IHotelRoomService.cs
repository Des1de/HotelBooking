using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.HotelRoom;

namespace HotelBooking.Service.Interfaces;

public interface IHotelRoomService
{
    Task<IBaseResponse<IEnumerable<GetHotelRoomsViewModel>>> GetHotelRooms(int hotelId);
    Task<IBaseResponse<GetHotelRoomViewModel>> GetHotelRoom(int id);
    Task<IBaseResponse<HotelRoom>> GetHotelRoomByName(string name);
    Task<IBaseResponse<bool>> DeleteHotelRoom(int id);
    Task<IBaseResponse<CreateHotelRoomViewModel>> CreateHotelRoom(CreateHotelRoomViewModel getHotelRoomsVm, int hotelId);
    Task<IBaseResponse<HotelRoom>> EditHotelRoom(CreateHotelRoomViewModel getHotelRoomsVm);
    BaseResponse<Dictionary<int, string>> GetTypes();
    Task<IBaseResponse<bool>> DeleteHotelRoomReview(int id);
    Task<IBaseResponse<IEnumerable<GetHotelRoomReviewsViewModel>>> GetHotelRoomReviews(int id);

    Task<IBaseResponse<CreateHotelRoomReviewViewModel>> CreateHotelRoomReview(
        CreateHotelRoomReviewViewModel createHotelRoomReviewVm);
}