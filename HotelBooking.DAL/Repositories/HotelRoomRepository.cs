using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL.Repositories;

public class HotelRoomRepository : IHotelRoomRepository
{
    private readonly ApplicationDbContext _dbContext;

    public HotelRoomRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
    
    public async Task<bool> CreateAsync(HotelRoom entity)
    {
        _dbContext.HotelRooms.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<HotelRoom> GetAsync(int id)
    {
        return await _dbContext.HotelRooms.FirstOrDefaultAsync(x => x.Id == id); 
    }

    public async Task<List<HotelRoom>> SelectAsync()
    {
        return await _dbContext.HotelRooms.ToListAsync(); 
    }

    public async Task<bool> DeleteAsync(HotelRoom entity)
    {
        _dbContext.HotelRooms.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

}