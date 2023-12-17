namespace HotelBooking.Domain.ViewModels;

public class GetHotelViewModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }


    public string Rating { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string Building { get; set; }
}