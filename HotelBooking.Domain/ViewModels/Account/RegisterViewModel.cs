using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.ViewModels.Account;

public class RegisterViewModel
{
    
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Укажите адрес электронной почты")]
    [EmailAddress]
    public string Email { get; set; }
        
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    [MinLength(6, ErrorMessage = "Пароль должен иметь длину больше 6 символов")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Подтвердите пароль")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string PasswordConfirm { get; set; }
}