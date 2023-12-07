namespace HotelBooking.Domain.Entity;

public class UserInfo
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Country { get; set; }
    public string Passport { get; set; }
    public byte[]? Avatar { get; set; }
}