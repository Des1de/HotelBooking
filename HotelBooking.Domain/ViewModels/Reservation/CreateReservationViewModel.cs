namespace HotelBooking.Domain.ViewModels.Reservation;

public class CreateReservationViewModel
{
    public int Id { get; set; }
    public int HotelRoomId { get; set; }
    public int UserId { get; set; }
    public string CheckInDate { get; set; }
    public string CheckOutDate { get; set; }
    public string ReservationStatus { get; set; }
}