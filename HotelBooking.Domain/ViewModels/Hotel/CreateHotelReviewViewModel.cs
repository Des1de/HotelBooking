namespace HotelBooking.Domain.ViewModels;

public class CreateHotelReviewViewModel
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string Email { get; set; }
    public string Review { get; set; }
}