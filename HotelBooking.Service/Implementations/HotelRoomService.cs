using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using HotelBooking.Domain.Enum;
using HotelBooking.Domain.Extentions;
using HotelBooking.Domain.Response;
using HotelBooking.Domain.ViewModels;
using HotelBooking.Domain.ViewModels.HotelRoom;
using HotelBooking.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Service.Implementations;

public class HotelRoomService : IHotelRoomService
{
    private readonly IBaseRepository<HotelRoom> _hotelRoomRepository;
    private readonly IBaseRepository<Hotel> _hotelRepository;

    public HotelRoomService(IBaseRepository<HotelRoom> hotelRoomRepository, IBaseRepository<Hotel> hotelRepository)
    {
        _hotelRoomRepository = hotelRoomRepository;
        _hotelRepository = hotelRepository;
    }

    public async Task<IBaseResponse<IEnumerable<GetHotelRoomsViewModel>>> GetHotelRooms(int hotelId)
    {
        var baseResponse = new BaseResponse<IEnumerable<GetHotelRoomsViewModel>>();
        try
        {
            var hotelRooms = await _hotelRoomRepository.GetAll().Where(x=>x.HotelId == hotelId).ToListAsync();
            var hotel = await _hotelRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == hotelId);
            if (hotelRooms.Count == 0)
            {
                baseResponse.Description = "Not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            var hotelRoomModels = new List<GetHotelRoomsViewModel>(); 

            for(int i = 0; i<hotelRooms.Count; i++)
            {
                hotelRoomModels.Add(new GetHotelRoomsViewModel()
                {
                    Id = hotelRooms[i].Id,
                    HotelName = hotel.Name,
                    HotelId = hotelRooms[i].HotelId,
                    FloorNumber = hotelRooms[i].FloorNumber,
                    Price = hotelRooms[i].Price,
                    RoomType = hotelRooms[i].RoomType.ToString()
                });
            }

            baseResponse.Data = hotelRoomModels;
            baseResponse.StatusCode = StatusCode.OK; 


            return baseResponse;

        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<GetHotelRoomsViewModel>>()
            {
                Description = $"[GetHotels] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<GetHotelRoomViewModel>> GetHotelRoom(int id)
    {
        var baseResponse = new BaseResponse<GetHotelRoomViewModel>();
        try
        {
            var hotelRoom = await _hotelRoomRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            var hotel = await _hotelRepository.GetAll().FirstOrDefaultAsync(x => x.Id == hotelRoom.HotelId);
            if (hotelRoom == null)
            {
                baseResponse.Description = "hotel room not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = new GetHotelRoomViewModel()
            {
                Id = hotelRoom.Id,
                HotelName = hotel.Name,
                HotelId = hotel.Id,
                Description = hotelRoom.Description,
                RoomType = hotelRoom.RoomType.ToString(), 
                FlourNumber = hotelRoom.FloorNumber,
                Price = hotelRoom.Price
            };
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse; 
        }
        catch (Exception e)
        {
            return new BaseResponse<GetHotelRoomViewModel>()
            {
                Description = $"[GetHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public Task<IBaseResponse<HotelRoom>> GetHotelRoomByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<bool>> DeleteHotelRoom(int id)
    {
        var baseResponse = new BaseResponse<bool>(); 
        
        try
        {
            var hotelRoom = await _hotelRoomRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == id);
          
            if (hotelRoom == null)
            {
                baseResponse.Description = "hotel not found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse; 
            }

            baseResponse.Data = await _hotelRoomRepository.DeleteAsync(hotelRoom);
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

    public async Task<IBaseResponse<CreateHotelRoomViewModel>> CreateHotelRoom(CreateHotelRoomViewModel createHotelRoomVm, int hotelId)
    {
        var baseResponse = new BaseResponse<CreateHotelRoomViewModel>();

        try
        {
            
            var hotelRoom = new HotelRoom()
            {
                HotelId = hotelId,
                FloorNumber = createHotelRoomVm.FloorNumber, 
                Price = createHotelRoomVm.Price,
                RoomType = (RoomType)Convert.ToInt32(createHotelRoomVm.RoomType),
                Description = createHotelRoomVm.Description
            };

            await _hotelRoomRepository.CreateAsync(hotelRoom);

        }
        catch (Exception e)
        {
            return new BaseResponse<CreateHotelRoomViewModel>()
            {
                Description = $"[CreateHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }

        return baseResponse; 
    }

    public async Task<IBaseResponse<HotelRoom>> EditHotelRoom(CreateHotelRoomViewModel getHotelRoomsVm)
    {
        var baseResponse = new BaseResponse<HotelRoom>();
        try
        {
            var hotelRoom = await _hotelRoomRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == getHotelRoomsVm.Id);
            if (hotelRoom == null)
            {
                baseResponse.StatusCode = StatusCode.NotFound;
                baseResponse.Description = "hotel not found";
                return baseResponse;
            }

            hotelRoom.HotelId = getHotelRoomsVm.HotelId;
            hotelRoom.RoomType = (RoomType)Convert.ToInt32(getHotelRoomsVm.RoomType);
            hotelRoom.Description = getHotelRoomsVm.Description;
            hotelRoom.FloorNumber = getHotelRoomsVm.FloorNumber;
            hotelRoom.Price = getHotelRoomsVm.Price; 

            baseResponse.Data = hotelRoom;
            baseResponse.StatusCode = StatusCode.OK;

            
            await _hotelRoomRepository.UpdateAsync(baseResponse.Data);
            return baseResponse; 
        }
        catch (Exception e)
        {
            return new BaseResponse<HotelRoom>()
            {
                Description = $"[CreateHotel] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public BaseResponse<Dictionary<int, string>> GetTypes()
    {
        try
        {
            var types = ((RoomType[]) Enum.GetValues(typeof(RoomType)))
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