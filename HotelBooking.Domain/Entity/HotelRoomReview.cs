namespace HotelBooking.Domain.Entity;

public class HotelRoomReview
{
    public int Id { get; set; }
    public string Email { get; set; }
    public int HotelRoomId { get; set; }
    public string Review { get; set; }
}