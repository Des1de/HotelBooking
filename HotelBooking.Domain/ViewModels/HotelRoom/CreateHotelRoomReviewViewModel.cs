namespace HotelBooking.Domain.ViewModels.HotelRoom;

public class CreateHotelRoomReviewViewModel
{
    public int Id { get; set; }
    public int HotelRoomId { get; set; }
    public string Email { get; set; }
    public string Review { get; set; } 
}