using HotelBooking.Domain.ViewModels;
using HotelBooking.Domain.ViewModels.HotelRoom;
using HotelBooking.Service.Implementations;
using HotelBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

public class HotelRoomController : Controller
{
    private readonly IHotelRoomService _hotelRoomService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HotelRoomController(IHotelRoomService hotelRoomService, IHttpContextAccessor httpContextAccessor)
    {
        _hotelRoomService = hotelRoomService;
        _httpContextAccessor = httpContextAccessor;
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
    public async Task<IActionResult> GetHotelRoom(int id)
    {
        var response = await _hotelRoomService.GetHotelRoom(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK )
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
    
    [HttpGet]
    public async Task<IActionResult> EditHotelRoom(int id)
    {
        var responce = await _hotelRoomService.GetHotelRoom(id);
        return View(new CreateHotelRoomViewModel()
        {
            Id = responce.Data.Id,
            HotelId = responce.Data.HotelId,
            RoomType = responce.Data.RoomType,
            FloorNumber = responce.Data.FlourNumber,
            Description = responce.Data.Description,
            Price = responce.Data.Price
        }); 
    }

    [HttpPost]
    public async Task<IActionResult> EditHotelRoom(CreateHotelRoomViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _hotelRoomService.EditHotelRoom(model); 
            return RedirectToAction("GetHotelRooms", "HotelRoom", model.HotelId); 
        }

        return View(model);

    }
    
    [HttpPost]
    public JsonResult GetTypes()
    {
        var types = _hotelRoomService.GetTypes();
        return Json(types.Data);
    }
    
    public async Task<IActionResult> DeleteHotelRoom(int id)
    {
        var response = await _hotelRoomService.DeleteHotelRoom(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetHotels","Hotel"); 
        }
        return RedirectToAction("Error","Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetHotelRoomReviews(int hotelRoomId)
    {
        var response = await _hotelRoomService.GetHotelRoomReviews(hotelRoomId);
        if (response.StatusCode == Domain.Enum.StatusCode.OK || response.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return View(response.Data); 
        }

        return RedirectToAction("Error","Home");
    }

    public async Task<IActionResult> DeleteHotelRoomReview(int id)
    {
        var response = await _hotelRoomService.DeleteHotelRoomReview(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetHotelRoomReviews"); 
        }
        return RedirectToAction("Error","Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateHotelRoomReview(int id)
    {
        
        var hotel = new CreateHotelRoomReviewViewModel()
        {
            HotelRoomId = id, 
            Email = _httpContextAccessor.HttpContext.User.Identity.Name
        };
        return View(hotel); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateHotelRoomReview(CreateHotelRoomReviewViewModel model)
    {
       
        await _hotelRoomService.CreateHotelRoomReview(model); 
        return RedirectToAction("GetHotelRooms"); 
        

    }
}