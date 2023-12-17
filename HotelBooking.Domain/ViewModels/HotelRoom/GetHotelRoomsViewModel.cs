namespace HotelBooking.Domain.ViewModels.HotelRoom;

public class GetHotelRoomsViewModel
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string HotelName { get; set; }
    public int FloorNumber { get; set; }
    public double Price { get; set; }
    public string RoomType { get; set; }
}