namespace HotelBooking.Domain.ViewModels.HotelRoom;

public class GetHotelRoomViewModel
{
    public int Id { get; set; }
    public string HotelName { get; set; }
    public int HotelId { get; set; }
    public double Price { get; set; }
    public int FlourNumber { get; set; }
    public string Description { get; set; }
    public string RoomType { get; set; }
}