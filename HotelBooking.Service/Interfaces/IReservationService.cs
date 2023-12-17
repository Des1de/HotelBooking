using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.Reservation;

namespace HotelBooking.Service.Interfaces;

public interface IReservationService
{
    Task<IBaseResponse<IEnumerable<Reservation>>> GetReservationsBy(int userId); 
    Task<IBaseResponse<ReservationViewModel>> CreateReservation(ReservationViewModel hotelVM);
}