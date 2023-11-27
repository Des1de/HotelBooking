using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.ViewModels.Account;

public class LoginViewModel
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Укажите адрес электронной почты")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Введите пароль")]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
}