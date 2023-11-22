using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult SignIn()
    {
        return View();
    }
    
    public IActionResult SignUp()
    {
        return View();
    }
}