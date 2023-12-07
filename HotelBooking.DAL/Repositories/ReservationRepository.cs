using HotelBooking.DAL.Interfaces;
using HotelBooking.Domain.Entity;

namespace HotelBooking.DAL.Repositories;

public class ReservationRepository : IBaseRepository<Reservation>
{
    private readonly ApplicationDbContext _dbContext;

    public ReservationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> CreateAsync(Reservation entity)
    {
        await _dbContext.Reservations.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }


    public IQueryable<Reservation> GetAll()
    {
        return _dbContext.Reservations.AsQueryable();
    }
    
    public async Task<bool> DeleteAsync(Reservation entity)
    {
        _dbContext.Reservations.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true; 
    }

    public async Task<Reservation> UpdateAsync(Reservation entity)
    {
        _dbContext.Reservations.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity; 
    }
}