using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.ViewModels.HotelRoom;

public class CreateHotelRoomViewModel
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    [Display(Name = "Этаж")]
    [Required(ErrorMessage = "Введите этаж комнаты")]
    public int FloorNumber { get; set; }
    
    [Display(Name = "Стоимость за сутки")]
    [Required(ErrorMessage = "Введите стоимость в сутки")]
    public double Price { get; set; }
    
    [Display(Name = "Тип комнаты")]
    [Required(ErrorMessage = "Выберите тип комнаты")]
    public string RoomType { get; set; }
}