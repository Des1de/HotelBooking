using HotelBooking.Domain.ViewModels;
using HotelBooking.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<IActionResult> GetHotels()
    {
       
        var response = await _hotelService.GetHotels();
        if (response.StatusCode == Domain.Enum.StatusCode.OK || response.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return View(response.Data); 
        }

        return RedirectToAction("Error","Home");
    }

    [HttpGet]
    public async Task<IActionResult> GetHotel(int id)
    {
        var response = await _hotelService.GetHotel(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data); 
        }
        
        return RedirectToAction("Error","Home");
    }
    
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var response = await _hotelService.DeleteHotel(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetHotels"); 
        }
        return RedirectToAction("Error","Home");
    }

    [HttpGet]
    public async Task<IActionResult> CreateHotel()
    {
        
        var hotel = new CreateHotelViewModel()
        {
                
        };
        return View(hotel); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateHotel(CreateHotelViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _hotelService.CreateHotel(model); 
            return RedirectToAction("GetHotels"); 
        }

        return View(model);

    }
    
    [HttpPost]
    public JsonResult GetTypes()
    {
        var types = _hotelService.GetTypes();
        return Json(types.Data);
    }
}