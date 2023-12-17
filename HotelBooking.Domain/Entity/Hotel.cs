using HotelBooking.Domain.Enum;

namespace HotelBooking.Domain.Entity;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<HotelPhoto> HotelPhotos { get; set; }
    public IEnumerable<HotelReview> HotelReviews { get; set; }
    public HotelRating Rating { get; set; }
    
}