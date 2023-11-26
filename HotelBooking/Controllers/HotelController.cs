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
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
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

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var response = await _hotelService.GetHotel(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetHotels"); 
        }
        return RedirectToAction("Error","Home");
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> SaveHotel(int id)
    {
        if (id == 0)
        {
            return View(); 
        }

        var response = await _hotelService.GetHotel(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data); 
        }
        
        return RedirectToAction("Error","Home");
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> SaveHotel(HotelViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.Id == 0)
            {
                await _hotelService.CreateHotel(model); 
            }
            else
            {
                await _hotelService.EditHotel(model);
            }
        }

        return RedirectToAction("GetHotels"); 
    }
}