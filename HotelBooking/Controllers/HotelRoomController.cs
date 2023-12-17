using HotelBooking.Domain.ViewModels.HotelRoom;
using HotelBooking.Service.Implementations;
using HotelBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

public class HotelRoomController : Controller
{
    private readonly IHotelRoomService _hotelRoomService;

    public HotelRoomController(IHotelRoomService hotelRoomService)
    {
        _hotelRoomService = hotelRoomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHotelRooms(int id)
    {
        var response = await _hotelRoomService.GetHotelRooms(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK || response.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return View(response.Data); 
        }

        return RedirectToAction("Error","Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateHotelRoom(int id)
    {
        
        return View(new CreateHotelRoomViewModel()
        {
            HotelId = id
        }); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateHotelRoom(CreateHotelRoomViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _hotelRoomService.CreateHotelRoom(model, model.HotelId); 
            return RedirectToAction("GetHotels", "Hotel"); 
        }

        return View(model);

    }
    
    [HttpPost]
    public JsonResult GetTypes()
    {
        var types = _hotelRoomService.GetTypes();
        return Json(types.Data);
    }
}