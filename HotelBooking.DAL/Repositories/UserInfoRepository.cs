using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;

namespace HotelBooking.DAL.Repositories;

public class UserInfoRepository : IBaseRepository<UserInfo>
{
    private readonly ApplicationDbContext _dbContext;

    public UserInfoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> CreateAsync(UserInfo entity)
    {
        await _dbContext.UserInfos.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }


    public IQueryable<UserInfo> GetAll()
    {
        return _dbContext.UserInfos.AsQueryable();
    }
    
    public async Task<bool> DeleteAsync(UserInfo entity)
    {
        _dbContext.UserInfos.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<UserInfo> UpdateAsync(UserInfo entity)
    {
        _dbContext.UserInfos.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity; 
    }
}