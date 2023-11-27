using System.Security.Claims;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.Account;

namespace HotelBooking.Service.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

    Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

    Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
}