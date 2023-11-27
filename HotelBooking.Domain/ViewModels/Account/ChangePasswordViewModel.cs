using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.ViewModels.Account;

public class ChangePasswordViewModel
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Укажите адрес электронной почты")]
    [EmailAddress]
    public string Email { get; set; }
        
    [Required(ErrorMessage = "Введите пароль")]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    [MinLength(5, ErrorMessage = "Пароль должен быть больше или равен 5 символов")]
    public string NewPassword { get; set; }
}