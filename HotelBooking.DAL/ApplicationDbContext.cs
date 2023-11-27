using HotelBooking.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<HotelRoom> HotelRooms { get; set; }
    public DbSet<User> Users { get; set; }
}