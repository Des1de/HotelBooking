using HotelBooking.Domain.Enum;

namespace HotelBooking.Domain.Entity;

public class Reservation
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int HotelRoomId { get; set; }
    public double TotalPrice { get; set; }
    public DateOnly CheckInDate { get; set; }
    public DateOnly CheckOutDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
}