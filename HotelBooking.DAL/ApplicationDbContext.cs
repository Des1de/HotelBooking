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
    public DbSet<HotelAddress> HotelAddresses { get; set; }
    public DbSet<HotelPhoto> HotelPhotos { get; set; }
    public DbSet<HotelReview> HotelReviews { get; set; }
    public DbSet<HotelRoomPhoto> HotelRoomPhotos { get; set; }
    public DbSet<HotelRoomReview> HotelRoomReviews { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
}