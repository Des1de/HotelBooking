using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;

namespace HotelBooking.DAL.Repositories;

public class HotelRoomReviewRepository : IBaseRepository<HotelRoomReview>
{
    private readonly ApplicationDbContext _dbContext;

    public HotelRoomReviewRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> CreateAsync(HotelRoomReview entity)
    {
        await _dbContext.HotelRoomReviews.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }


    public IQueryable<HotelRoomReview> GetAll()
    {
        return _dbContext.HotelRoomReviews.AsQueryable();
    }
    
    public async Task<bool> DeleteAsync(HotelRoomReview entity)
    {
        _dbContext.HotelRoomReviews.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<HotelRoomReview> UpdateAsync(HotelRoomReview entity)
    {
        _dbContext.HotelRoomReviews.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity; 
    }
}