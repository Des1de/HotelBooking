using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Enum;

public enum ReservationStatus
{
    [Display(Name = "Одобренно")]
    Accepted = 0, 
    [Display(Name = "Рассматривается")]
    Pending = 1, 
    [Display(Name = "Отклонено")]
    Rejected = 2
}