using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;


namespace HotelBooking.DAL.Repositories;

public class HotelRepository : IBaseRepository<Hotel>
{
    private readonly ApplicationDbContext _dbContext;

    public HotelRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
    
    public async Task<bool> CreateAsync(Hotel entity)
    {
        await _dbContext.Hotels.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }


    public IQueryable<Hotel> GetAll()
    {
        return _dbContext.Hotels.AsQueryable();
    }
    
    public async Task<bool> DeleteAsync(Hotel entity)
    {
        _dbContext.Hotels.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<Hotel> UpdateAsync(Hotel entity)
    {
        _dbContext.Hotels.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity; 
    }
}