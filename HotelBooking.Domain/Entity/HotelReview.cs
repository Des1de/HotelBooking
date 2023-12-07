namespace HotelBooking.Domain.Entity;

public class HotelReview
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int HotelId { get; set; }
    public string Review { get; set; }
}