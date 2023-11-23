using HotelBooking.Domain.ViewModels;
using HotelBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

public class HotelController : Controller
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
       
        var response = await _hotelService.GetHotels();
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data); 
        }

        return RedirectToAction("Error","Home");
    }
}