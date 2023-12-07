using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;

namespace HotelBooking.DAL.Repositories;

public class HotelRoomPhotoRepository : IBaseRepository<HotelRoomPhoto>
{
    private readonly ApplicationDbContext _dbContext;

    public HotelRoomPhotoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> CreateAsync(HotelRoomPhoto entity)
    {
        await _dbContext.HotelRoomPhotos.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }


    public IQueryable<HotelRoomPhoto> GetAll()
    {
        return _dbContext.HotelRoomPhotos.AsQueryable();
    }
    
    public async Task<bool> DeleteAsync(HotelRoomPhoto entity)
    {
        _dbContext.HotelRoomPhotos.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<HotelRoomPhoto> UpdateAsync(HotelRoomPhoto entity)
    {
        _dbContext.HotelRoomPhotos.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity; 
    }
}