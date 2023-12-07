using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using Microsoft.EntityFrameworkCore.Query;

namespace HotelBooking.DAL.Repositories;

public class HotelPhotoRepository : IBaseRepository<HotelPhoto>
{
    private readonly ApplicationDbContext _dbContext;

    public HotelPhotoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> CreateAsync(HotelPhoto entity)
    {
        await _dbContext.HotelPhotos.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }


    public IQueryable<HotelPhoto> GetAll()
    {
        return _dbContext.HotelPhotos.AsQueryable();
    }
    
    public async Task<bool> DeleteAsync(HotelPhoto entity)
    {
        _dbContext.HotelPhotos.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<HotelPhoto> UpdateAsync(HotelPhoto entity)
    {
        _dbContext.HotelPhotos.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity; 
    }
}