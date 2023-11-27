using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.ViewModels;

public class HotelViewModel
{
    public int Id { get; set; }

    [Display(Name = "Название")]
    [Required(ErrorMessage = "Введите название")]
    [MinLength(2, ErrorMessage = "Минимальная длинна от 2 символов")]
    public string Name { get; set; }

    [Display(Name = "Описание")]
    [MinLength(50, ErrorMessage = "Минимальная длина должна быть больше 50 символов")]
    public string Description { get; set; }

    public string Rating { get; set; }
    public FileInfo Avatar { get; set; }

}