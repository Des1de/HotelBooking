using System.Security.Claims;
using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Enum;
using HotelBooking.Domain.Extentions;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels.Reservation;
using HotelBooking.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.Implementations;

public class ReservationService : IReservationService
{
    private readonly IBaseRepository<Reservation> _reservationRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IBaseRepository<HotelRoom> _hotelRoomRepository;
    private readonly IBaseRepository<User> _userRepository; 

    public ReservationService(IBaseRepository<Reservation> reservationRepository, IHttpContextAccessor httpContextAccessor, IBaseRepository<HotelRoom> hotelRoomRepository, IBaseRepository<User> userRepository)
    {
        _reservationRepository = reservationRepository;
        
        _httpContextAccessor = httpContextAccessor;
        _hotelRoomRepository = hotelRoomRepository;
        _userRepository = userRepository;
    }

    public async Task<IBaseResponse<IEnumerable<GetReservationsViewModel>>> GetReservationsByUserId()
    {
        
        var baseResponse = new BaseResponse<IEnumerable<GetReservationsViewModel>>(); 
        try
        {
            var email = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email == email);
            var reservations = await _reservationRepository.GetAll().Where(x => x.UserId == user.Id).ToListAsync();
            if (reservations.Count == 0)
            {
                baseResponse.Description = "Not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            var models = new List<GetReservationsViewModel>();

            foreach (var reservation in reservations)
            {
                models.Add(new GetReservationsViewModel()
                {
                    Id = reservation.Id,
                    UserId = reservation.UserId,
                    HotelRoomId = reservation.HotelRoomId,
                    CheckInDate = reservation.CheckInDate.ToString(),
                    CheckOutDate = reservation.CheckOutDate.ToString(),
                    ReservationStatus = reservation.ReservationStatus.ToString()
                });
            }

            baseResponse.Data = models;
            baseResponse.StatusCode = StatusCode.OK; 


            return baseResponse;

        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<GetReservationsViewModel>>()
            {
                Description = $"[GetHotels] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<CreateReservationViewModel>> CreateReservation(CreateReservationViewModel reservationViewModel)
    {
        var baseResponse = new BaseResponse<CreateReservationViewModel>();

        try
        {
            var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email == userEmail);
            var reservation = new Reservation()
            {
                UserId = user.Id,
                HotelRoomId = reservationViewModel.HotelRoomId,
                CheckInDate = DateOnly.Parse(reservationViewModel.CheckInDate), CheckOutDate = DateOnly.Parse(reservationViewModel.CheckOutDate),
                ReservationStatus =  ReservationStatus.Pending
            };

            await _reservationRepository.CreateAsync(reservation);
            
            baseResponse.Data = reservationViewModel;
            baseResponse.StatusCode = StatusCode.OK;
            
        }
        catch (Exception e)
        {
            return new BaseResponse<CreateReservationViewModel>()
            {
                Description = $"[CreateHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponse; 
    }

    public async Task<IBaseResponse<bool>> DeleteReservation(int id)
    {
        var baseResponse = new BaseResponse<bool>(); 
        
        try
        {
            var reservation = await _reservationRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == id);
          
            if (reservation == null)
            {
                baseResponse.Description = "hotel not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = await _reservationRepository.DeleteAsync(reservation);
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public BaseResponse<Dictionary<int, string>> GetTypes()
    {
        try
        {
            var types = ((ReservationStatus[]) Enum.GetValues(typeof(ReservationStatus)))
                .ToDictionary(k => (int) k, t => t.GetDisplayName());

            return new BaseResponse<Dictionary<int, string>>()
            {
                Data = types,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<Dictionary<int, string>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}