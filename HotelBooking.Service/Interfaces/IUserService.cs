using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.User;

namespace HotelBooking.Service.Interfaces;

public interface IUserService
{
    Task<IBaseResponse<IEnumerable<GetUsersViewModel>>> GetUsers(); 
    
    Task<IBaseResponse<bool>> DeleteUser(int id);
    Task<IBaseResponse<bool>> ChangeRole(int id);
    
}