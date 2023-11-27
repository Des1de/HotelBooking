using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;

namespace HotelBooking.DAL.Repositories;

public class UserRepository : IBaseRepository<User>
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public IQueryable<User> GetAll()
    {
        return _db.Users;
    }

    public async Task<bool> DeleteAsync(User entity)
    {
        _db.Users.Remove(entity);
        await _db.SaveChangesAsync();
        return true; 
    }

    public async Task<bool> CreateAsync(User entity)
    {
        await _db.Users.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true; 
    }

    public async Task<User> UpdateAsync(User entity)
    {
        _db.Users.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}