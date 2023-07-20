namespace RentCar.Domain.Exceptions.Rental;

public class RentalNotFoundException : NotFoundExceptions
{
    public RentalNotFoundException()
    {
        this.TitleMessage = "Rental not found";
    }
}
