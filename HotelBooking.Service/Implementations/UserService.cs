using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Enum;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.User;
using HotelBooking.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.Implementations;

public class UserService : IUserService
{
    private readonly IBaseRepository<User> _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IBaseRepository<User> userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<IBaseResponse<IEnumerable<GetUsersViewModel>>> GetUsers()
    {
        var baseResponse = new BaseResponse<IEnumerable<GetUsersViewModel>>();
        try
        {
            var users = await _userRepository.GetAll()
                .Where(x => x.Email != _httpContextAccessor.HttpContext.User.Identity.Name).ToListAsync();
            if (users.Count == 0)
            {
                baseResponse.Description = "Not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }

            var models = new List<GetUsersViewModel>();

            foreach (var user in users)
            {
                models.Add(new GetUsersViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role.ToString()
                });
            }

            baseResponse.Data = models;
            baseResponse.StatusCode = StatusCode.OK;


            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<GetUsersViewModel>>()
            {
                Description = $"[GetHotels] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteUser(int id)
    {
        var baseResponse = new BaseResponse<bool>(); 
        
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == id);
          
            if (user == null)
            {
                baseResponse.Description = "hotel not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = await _userRepository.DeleteAsync(user);
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> ChangeRole(int id)
    {
        var baseResponse = new BaseResponse<bool>(); 
        
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == id);
          
            if (user == null)
            {
                baseResponse.Description = "hotel not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            if (user.Role == Role.Admin) user.Role = Role.User;
            else user.Role = Role.Admin;
            
            await _userRepository.UpdateAsync(user);
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}