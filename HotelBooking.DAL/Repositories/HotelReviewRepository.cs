using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;

namespace HotelBooking.DAL.Repositories;

public class HotelReviewRepository : IBaseRepository<HotelReview>
{
    private readonly ApplicationDbContext _dbContext;

    public HotelReviewRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> CreateAsync(HotelReview entity)
    {
        await _dbContext.HotelReviews.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }


    public IQueryable<HotelReview> GetAll()
    {
        return _dbContext.HotelReviews.AsQueryable();
    }
    
    public async Task<bool> DeleteAsync(HotelReview entity)
    {
        _dbContext.HotelReviews.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<HotelReview> UpdateAsync(HotelReview entity)
    {
        _dbContext.HotelReviews.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity; 
    }
}