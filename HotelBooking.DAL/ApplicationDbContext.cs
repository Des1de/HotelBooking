using HotelBooking.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        this.Database.EnsureCreated(); 
    }

    
    
    public DbSet<HotelRoom> HotelRooms { get; set; }
}