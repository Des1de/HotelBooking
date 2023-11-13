using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Enum;

public enum RoomType
{
    [Display(Name = "Стандартный одноместный номер")]
    Sgl  = 0,
    [Display(Name = "Стандартный двухместный номер с двуспальной кроватью")]
    Dbl = 1,
    [Display(Name = "Двухместный номер с двумя односпальными кроватями")]
    Twin  = 2,
    [Display(Name = "Трехместный номер c 3 кроватями")]
    Trpl = 3,
    [Display(Name = "Четырехместный номер c 4 кроватями")]
    Qdpl = 4
    
    
}