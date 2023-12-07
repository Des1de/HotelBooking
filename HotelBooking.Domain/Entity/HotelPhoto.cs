namespace HotelBooking.Domain.Entity;

public class HotelPhoto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public byte[] Photo { get; set; }
}