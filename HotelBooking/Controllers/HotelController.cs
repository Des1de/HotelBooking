using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

public class HotelController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}