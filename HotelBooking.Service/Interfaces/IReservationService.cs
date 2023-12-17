using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.Reservation;

namespace HotelBooking.Service.Interfaces;

public interface IReservationService
{
    Task<IBaseResponse<IEnumerable<GetReservationsViewModel>>> GetReservationsByUserId(); 
    Task<IBaseResponse<CreateReservationViewModel>> CreateReservation(CreateReservationViewModel hotelVM);
    Task<IBaseResponse<bool>> DeleteReservation(int id);
}