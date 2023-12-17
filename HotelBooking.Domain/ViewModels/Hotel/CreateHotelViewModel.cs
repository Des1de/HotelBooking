using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.ViewModels;

public class CreateHotelViewModel
{
    public int Id { get; set; }

    [Display(Name = "Название")]
    [Required(ErrorMessage = "Введите название")]
    [MinLength(2, ErrorMessage = "Минимальная длинна от 2 символов")]
    public string Name { get; set; }

    [Display(Name = "Описание")]
    [MinLength(50, ErrorMessage = "Минимальная длина должна быть больше 50 символов")]
    public string Description { get; set; }

    
    [Display(Name = "Рейтинг отеля")]
    [Required(ErrorMessage = "Выберите рейтинг")]
    public string Rating { get; set; }
    
    [Display(Name = "Страна")]
    [Required(ErrorMessage = "Введите название страны")]
    [MinLength(2, ErrorMessage = "Минимальная длинна от 2 символов")]
    public string Country { get; set; }
    
    [Display(Name = "Горд")]
    [Required(ErrorMessage = "Введите название города")]
    [MinLength(2, ErrorMessage = "Минимальная длинна от 2 символов")]
    public string City { get; set; }
    
    [Display(Name = "Улица")]
    [Required(ErrorMessage = "Введите название улицы")]
    [MinLength(2, ErrorMessage = "Минимальная длинна от 2 символов")]
    public string Street { get; set; }
    
    [Display(Name = "Здание")]
    [Required(ErrorMessage = "Введите здание")]
    [MinLength(2, ErrorMessage = "Минимальная длинна от 2 символов")]
    public string Building { get; set; }
}