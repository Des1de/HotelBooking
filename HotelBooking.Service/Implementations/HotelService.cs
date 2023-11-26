using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Enum;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels;
using HotelBooking.Service.Interfaces;

namespace HotelBooking.Service.Implementations;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<IBaseResponse<IEnumerable<Hotel>>> GetHotels()
    {
        var baseResponse = new BaseResponse<IEnumerable<Hotel>>();
        try
        {
            var hotels = await _hotelRepository.SelectAsync();
            if (hotels.Count == 0)
            {
                baseResponse.Description = "Not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = hotels;
            baseResponse.StatusCode = StatusCode.OK; 


            return baseResponse;

        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Hotel>>()
            {
                Description = $"[GetHotels] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Hotel>> GetHotel(int id)
    {
        var baseResponse = new BaseResponse<Hotel>();
        try
        {
            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
            {
                baseResponse.Description = "hotel not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = hotel;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse; 
        }
        catch (Exception e)
        {
            return new BaseResponse<Hotel>()
            {
                Description = $"[GetHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<Hotel>> GetHotelByName(string name)
    {
        var baseResponse = new BaseResponse<Hotel>();
        try
        {
            var hotel = await _hotelRepository.GetByNameAsync(name);
            if (hotel == null)
            {
                baseResponse.Description = "hotel not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = hotel;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse; 
        }
        catch (Exception e)
        {
            return new BaseResponse<Hotel>()
            {
                Description = $"[GetHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteHotel(int id)
    {
        var baseResponse = new BaseResponse<bool>(); 
        
        try
        {
            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
            {
                baseResponse.Description = "hotel not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = await _hotelRepository.DeleteAsync(hotel);
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

    public async Task<IBaseResponse<HotelViewModel>> CreateHotel(HotelViewModel hotelViewModel)
    {
        var baseResponse = new BaseResponse<HotelViewModel>();

        try
        {
            var hotel = new Hotel()
            {
                Name = hotelViewModel.Name, 
                Description = hotelViewModel.Description,
                Rating = hotelViewModel.Rating
            };

            await _hotelRepository.CreateAsync(hotel); 
        }
        catch (Exception e)
        {
            return new BaseResponse<HotelViewModel>()
            {
                Description = $"[CreateHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponse; 
    }

    public async Task<IBaseResponse<Hotel>> EditHotel(HotelViewModel hotelViewModel)
    {
        var baseResponse = new BaseResponse<Hotel>();
        try
        {
            var hotel = await _hotelRepository.GetAsync(hotelViewModel.Id);
            if (hotel == null)
            {
                baseResponse.StatusCode = StatusCode.NotFound;
                baseResponse.Description = "hotel not found";
                return baseResponse;
            }

            hotel.Name = hotelViewModel.Name;
            hotel.Description = hotelViewModel.Description;
            hotel.Rating = hotelViewModel.Rating;

            baseResponse.Data = hotel;
            baseResponse.StatusCode = StatusCode.OK;

            await _hotelRepository.UpdateAsync(baseResponse.Data); 
            
            return baseResponse; 
        }
        catch (Exception e)
        {
            return new BaseResponse<Hotel>()
            {
                Description = $"[CreateHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}