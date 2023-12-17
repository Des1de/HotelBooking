using HotelBooking.Domain.Enum;
using HotelBooking.Domain.ViewModels.Reservation;
using HotelBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

public class ReservationController : Controller
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserReservations()
    {
       
        var response = await _reservationService.GetReservationsByUserId();
        if (response.StatusCode == Domain.Enum.StatusCode.OK || response.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return View(response.Data); 
        }

        return RedirectToAction("Error","Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateReservation(int id)
    {
        
        return View(new CreateReservationViewModel()
        {
            HotelRoomId = id
        }); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation(CreateReservationViewModel model)
    {
        model.ReservationStatus = ReservationStatus.Pending.ToString();
       
        await _reservationService.CreateReservation(model); 
        return RedirectToAction("GetHotels", "Hotel"); 


    }
    
    public async Task<IActionResult> DeleteReservation(int id)
    {
        var response = await _reservationService.DeleteReservation(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetUserReservations","Reservation"); 
        }
        return RedirectToAction("Error","Home");
    }

    public async Task<IActionResult> GetPendingReservations()
    {
        var response = await _reservationService.GetPendingReservations();
        if (response.StatusCode == Domain.Enum.StatusCode.OK || response.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return View(response.Data); 
        }

        return RedirectToAction("Error","Home");
    }
    
    public async Task<IActionResult> AcceptReservation(int id)
    {
        var response = await _reservationService.AcceptReservation(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetPendingReservations", "Reservation"); 
        }

        return RedirectToAction("Error","Home");
    }
    
    public async Task<IActionResult> RejectReservation(int id)
    {
        var response = await _reservationService.RejectReservation(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK )
        {
            return RedirectToAction("GetPendingReservations", "Reservation"); 
        }

        return RedirectToAction("Error","Home");
    }
}