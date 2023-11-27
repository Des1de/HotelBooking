using HotelBooking.Domain.Enum;

namespace HotelBooking.Domain.Entity;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public HotelRating Rating { get; set; }
    public byte[]? Avatar { get; set; }
    
}