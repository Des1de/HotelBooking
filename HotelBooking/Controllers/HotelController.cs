using HotelBooking.Domain.ViewModels;
using HotelBooking.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

public class HotelController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HotelController(IHotelService hotelService, IHttpContextAccessor httpContextAccessor)
    {
        _hotelService = hotelService;
        _httpContextAccessor = httpContextAccessor;
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
    
    [HttpGet]
    public async Task<IActionResult> EditHotel(int id)
    {
        var responce = await _hotelService.GetHotel(id); 
        var hotel = new CreateHotelViewModel()
        {
                Name = responce.Data.Name, Description = responce.Data.Description,
                Rating = responce.Data.Rating, Country = responce.Data.Country,
                City = responce.Data.City, Street = responce.Data.Street,
                Building = responce.Data.Building
        };
        return View(hotel); 
    }

    [HttpPost]
    public async Task<IActionResult> EditHotel(CreateHotelViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _hotelService.EditHotel(model); 
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

    [HttpGet]
    public async Task<IActionResult> GetHotelReviews(int hotelId)
    {
        var response = await _hotelService.GetHotelReviews(hotelId);
        if (response.StatusCode == Domain.Enum.StatusCode.OK || response.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return View(response.Data); 
        }

        return RedirectToAction("Error","Home");
    }

    public async Task<IActionResult> DeleteHotelReview(int id)
    {
        var response = await _hotelService.DeleteHotelReview(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetHotelReviews"); 
        }
        return RedirectToAction("Error","Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateHotelReview(int id)
    {
        
        var hotel = new CreateHotelReviewViewModel()
        {
            HotelId = id, 
            Email = _httpContextAccessor.HttpContext.User.Identity.Name
        };
        return View(hotel); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateHotelReview(CreateHotelReviewViewModel model)
    {
       
        await _hotelService.CreateHotelReview(model); 
        return RedirectToAction("GetHotels"); 
        

        return View(model);

    }
}