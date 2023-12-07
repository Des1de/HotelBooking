using HotelBooking.Domain.Enum;

namespace HotelBooking.Domain.Entity;

public class HotelRoom
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public int FloorNumber { get; set; }
    public double Price { get; set; }
    public IEnumerable<HotelRoomPhoto> HotelRoomPhotos { get; set; }
    public IEnumerable<HotelRoomReview> HotelRoomReviews { get; set; }
    public RoomType RoomType { get; set; }
    
}