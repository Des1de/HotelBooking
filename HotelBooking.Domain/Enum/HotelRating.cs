using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Enum;

public enum HotelRating
{
    [Display(Name = "Однозвёздочный отель")]
    OneStar = 1, 
    [Display(Name = "Двухзвёздочный отель")]
    TwoStar = 2, 
    [Display(Name = "Трехзвёхдочный отель")]
    TreeStar = 3, 
    [Display(Name = "Четырёхзвёздочный отель")]
    FourStar = 4, 
    [Display(Name = "Пятизвёздочный отель")]
    FiveStar = 5
}