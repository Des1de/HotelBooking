using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Enum;
using HotelBooking.Domain.Response;
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
}