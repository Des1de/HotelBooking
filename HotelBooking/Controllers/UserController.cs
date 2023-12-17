using HotelBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
       
        var response = await _userService.GetUsers();
        if (response.StatusCode == Domain.Enum.StatusCode.OK || response.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return View(response.Data); 
        }

        return RedirectToAction("Error","Home");
    }
    
    
    public async Task<IActionResult> DeleteUser(int id)
    {
       
        var response = await _userService.DeleteUser(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK || response.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return RedirectToAction("GetUsers"); 
        }

        return RedirectToAction("Error","Home");
    }
    
    public async Task<IActionResult> ChangeRole(int id)
    {
       
        var response = await _userService.ChangeRole(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK || response.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return RedirectToAction("GetUsers"); 
        }

        return RedirectToAction("Error","Home");
    }
}