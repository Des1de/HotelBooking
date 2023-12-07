namespace HotelBooking.Domain.Entity;

public class HotelRoomPhoto
{
    public int Id { get; set; }
    public int HotelRoomId { get; set; }
    public byte[] Photo { get; set; }
}