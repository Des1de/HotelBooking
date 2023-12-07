using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;

namespace HotelBooking.DAL.Repositories;

public class HotelAddressRepository : IBaseRepository<HotelAddress>
{
    private readonly ApplicationDbContext _dbContext;

    public HotelAddressRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(HotelAddress entity)
    {
        await _dbContext.HotelAddresses.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }


    public IQueryable<HotelAddress> GetAll()
    {
        return _dbContext.HotelAddresses.AsQueryable();
    }
    
    public async Task<bool> DeleteAsync(HotelAddress entity)
    {
        _dbContext.HotelAddresses.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<HotelAddress> UpdateAsync(HotelAddress entity)
    {
        _dbContext.HotelAddresses.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity; 
    }
}