using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL.Repositories;

public class HotelRoomRepository : IBaseRepository<HotelRoom>
{
    private readonly ApplicationDbContext _dbContext;

    public HotelRoomRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
    
    public async Task<bool> CreateAsync(HotelRoom entity)
    {
        await _dbContext.HotelRooms.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public IQueryable<HotelRoom> GetAll()
    {
        return _dbContext.HotelRooms.AsQueryable(); 
    }


    public async Task<bool> DeleteAsync(HotelRoom entity)
    {
        _dbContext.HotelRooms.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public Task<HotelRoom> UpdateAsync(HotelRoom entity)
    {
        throw new NotImplementedException();
    }
}

