using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Enum;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.Reservation;
using HotelBooking.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.Implementations;

public class ReservationService : IReservationService
{
    private readonly IBaseRepository<Reservation> _reservationRepository;

    public ReservationService(IBaseRepository<Reservation> reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<IBaseResponse<IEnumerable<Reservation>>> GetReservationsBy(int userId)
    {
        var baseResponse = new BaseResponse<IEnumerable<Reservation>>(); 
        try
        {
            var reservations = await _reservationRepository.GetAll().Where(x => x.UserId == userId).ToListAsync();
            if (reservations.Count == 0)
            {
                baseResponse.Description = "Not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = reservations;
            baseResponse.StatusCode = StatusCode.OK; 


            return baseResponse;

        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Reservation>>()
            {
                Description = $"[GetHotels] : {e.Message}"
            };
        }
    }

    public Task<IBaseResponse<ReservationViewModel>> CreateReservation(ReservationViewModel hotelVM)
    {
        throw new NotImplementedException();
    }
}