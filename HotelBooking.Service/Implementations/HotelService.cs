using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Enum;
using HotelBooking.Domain.Extentions;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels;
using HotelBooking.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.Implementations;

public class HotelService : IHotelService
{
    private readonly IBaseRepository<Hotel> _hotelRepository;
    private readonly IBaseRepository<HotelAddress> _hotelAddressRepository;
    private readonly IBaseRepository<HotelRoom> _hotelRoomRepository;
    private readonly IBaseRepository<HotelReview> _hotelReviewRepository; 

    public HotelService(IBaseRepository<Hotel> hotelRepository, IBaseRepository<HotelAddress> hotelAddressRepository, IBaseRepository<HotelRoom> hotelRoomRepository, IBaseRepository<HotelReview> hotelReviewRepository)
    {
        _hotelRepository = hotelRepository;
        _hotelAddressRepository = hotelAddressRepository;
        _hotelRoomRepository = hotelRoomRepository;
        _hotelReviewRepository = hotelReviewRepository;
    }
    
    public BaseResponse<Dictionary<int, string>> GetTypes()
    {
        try
        {
            var types = ((HotelRating[]) Enum.GetValues(typeof(HotelRating)))
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

    public async Task<IBaseResponse<CreateHotelReviewViewModel>> CreateHotelReview(CreateHotelReviewViewModel createHotelReviewVm)
    {
        var baseResponse = new BaseResponse<CreateHotelReviewViewModel>();

        try
        {
            
            var hotelReview = new HotelReview()
            {
                HotelId = createHotelReviewVm.HotelId, Email = createHotelReviewVm.Email, Review = createHotelReviewVm.Review
            };

            await _hotelReviewRepository.CreateAsync(hotelReview);

        }
        catch (Exception e)
        {
            return new BaseResponse<CreateHotelReviewViewModel>()
            {
                Description = $"[CreateHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponse; 
    }

    public async Task<IBaseResponse<IEnumerable<GetHotelReviewsViewModel>>> GetHotelReviews(int id)
    {
        var baseResponse = new BaseResponse<IEnumerable<GetHotelReviewsViewModel>>();
        try
        {
            var hotelReviews = await _hotelReviewRepository.GetAll().Where(x=>x.HotelId == id).ToListAsync();
            if (hotelReviews.Count == 0)
            {
                baseResponse.Description = "Not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            var hotelReviewModels = new List<GetHotelReviewsViewModel>(); 

            for(int i = 0; i<hotelReviews.Count; i++)
            {
                hotelReviewModels.Add(new GetHotelReviewsViewModel()
                {
                    Id = hotelReviews[i].Id,
                    Review = hotelReviews[i].Review,
                    Email = hotelReviews[i].Email, 
                });
            }

            baseResponse.Data = hotelReviewModels;
            baseResponse.StatusCode = StatusCode.OK; 


            return baseResponse;

        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<GetHotelReviewsViewModel>>()
            {
                Description = $"[GetHotels] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteHotelReview(int id)
    {
        var baseResponse = new BaseResponse<bool>(); 
        
        try
        {
            var hotelReview = await _hotelReviewRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == id);

            if (hotelReview == null)
            {
                baseResponse.Description = "hotel not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = await _hotelReviewRepository.DeleteAsync(hotelReview);
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

    public async Task<IBaseResponse<IEnumerable<GetHotelsViewModel>>> GetHotels()
    {
        var baseResponse = new BaseResponse<IEnumerable<GetHotelsViewModel>>();
        try
        {
            var hotels = await _hotelRepository.GetAll().ToListAsync();
            var addresses = await _hotelAddressRepository.GetAll().ToListAsync();
            if (hotels.Count == 0)
            {
                baseResponse.Description = "Not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            var hotelModels = new List<GetHotelsViewModel>(); 

            for(int i = 0; i<hotels.Count; i++)
            {
                hotelModels.Add(new GetHotelsViewModel()
                {
                    Id = hotels[i].Id,
                    Name = hotels[i].Name,
                    Description = hotels[i].Description,
                    Rating = hotels[i].Rating.ToString(), 
                    Country = addresses[i].Country,
                    City = addresses[i].City
                });
            }

            baseResponse.Data = hotelModels;
            baseResponse.StatusCode = StatusCode.OK; 


            return baseResponse;

        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<GetHotelsViewModel>>()
            {
                Description = $"[GetHotels] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<GetHotelViewModel>> GetHotel(int id)
    {
        var baseResponse = new BaseResponse<GetHotelViewModel>();
        try
        {
            var hotel = await _hotelRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            var address = await _hotelAddressRepository.GetAll().FirstOrDefaultAsync(x => x.HotelId == id);
            if (hotel == null)
            {
                baseResponse.Description = "hotel not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = new GetHotelViewModel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Description = hotel.Description,
                Rating = hotel.Rating.ToString(), 
                Country = address.Country,
                City = address.City,
                Street = address.Street,
                Building = address.Building
            };
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse; 
        }
        catch (Exception e)
        {
            return new BaseResponse<GetHotelViewModel>()
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
            var hotel = await _hotelRepository.GetAll().FirstOrDefaultAsync(x=>x.Name == name);
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
            var hotel = await _hotelRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == id);
            var hotelRooms = await _hotelRoomRepository.GetAll().Where(x => x.HotelId == id).ToListAsync();
            var hotelAddress = await _hotelAddressRepository.GetAll().FirstOrDefaultAsync(x => x.HotelId == id);
            if (hotel == null)
            {
                baseResponse.Description = "hotel not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            foreach (var hotelRoom in hotelRooms)
            {
                await _hotelRoomRepository.DeleteAsync(hotelRoom); 
            }

            await _hotelAddressRepository.DeleteAsync(hotelAddress); 
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

    public async Task<IBaseResponse<CreateHotelViewModel>> CreateHotel(CreateHotelViewModel createHotelViewModel)
    {
        var baseResponse = new BaseResponse<CreateHotelViewModel>();

        try
        {
            
            var hotel = new Hotel()
            {
                Name = createHotelViewModel.Name, 
                Description = createHotelViewModel.Description,
                Rating = (HotelRating)Convert.ToInt32(createHotelViewModel.Rating)
            };

            await _hotelRepository.CreateAsync(hotel);

            var address = new HotelAddress()
            {
                HotelId = hotel.Id,
                Country = createHotelViewModel.Country,
                City = createHotelViewModel.City,
                Street = createHotelViewModel.Street,
                Building = createHotelViewModel.Building
            };

            await _hotelAddressRepository.CreateAsync(address); 
        }
        catch (Exception e)
        {
            return new BaseResponse<CreateHotelViewModel>()
            {
                Description = $"[CreateHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponse; 
    }

    public async Task<IBaseResponse<Hotel>> EditHotel(CreateHotelViewModel createHotelViewModel)
    {
        var baseResponse = new BaseResponse<Hotel>();
        try
        {
            var hotel = await _hotelRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == createHotelViewModel.Id);
            var hotelAddress = await _hotelAddressRepository.GetAll()
                .FirstOrDefaultAsync(x => x.HotelId == createHotelViewModel.Id);
            if (hotel == null)
            {
                baseResponse.StatusCode = StatusCode.NotFound;
                baseResponse.Description = "hotel not found";
                return baseResponse;
            }

            hotel.Name = createHotelViewModel.Name;
            hotel.Description = createHotelViewModel.Description;
            hotel.Rating = (HotelRating)Convert.ToInt32(createHotelViewModel.Rating);

            hotelAddress.Country = createHotelViewModel.Country;
            hotelAddress.City = createHotelViewModel.City;
            hotelAddress.Street = createHotelViewModel.Street;
            hotelAddress.Building = createHotelViewModel.Building;
            hotelAddress.HotelId = createHotelViewModel.Id;

            baseResponse.Data = hotel;
            baseResponse.StatusCode = StatusCode.OK;

            
            await _hotelRepository.UpdateAsync(baseResponse.Data);
            await _hotelAddressRepository.UpdateAsync(hotelAddress); 
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