using System.Runtime.CompilerServices;
using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly ApplicationDbContext _dbContext;

    public HotelRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
    
    public async Task<bool> CreateAsync(Hotel entity)
    {
        _dbContext.Hotels.AddAsync(entity);
        _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<Hotel> GetAsync(int id)
    {
        return await _dbContext.Hotels.FirstOrDefaultAsync(x => x.Id == id); 
    }
    
    public async Task<Hotel> GetByNameAsync(string name)
    {
        return await _dbContext.Hotels.FirstOrDefaultAsync(x => x.Name == name); 
    }

    public async Task<List<Hotel>> SelectAsync()
    {
        return await _dbContext.Hotels.ToListAsync(); 
    }

    public async Task<bool> DeleteAsync(Hotel entity)
    {
        _dbContext.Hotels.Remove(entity);
        _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<Hotel> UpdateAsync(Hotel entity)
    {
        _dbContext.Hotels.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity; 
    }
}