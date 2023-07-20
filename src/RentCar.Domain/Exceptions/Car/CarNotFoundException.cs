namespace RentCar.Domain.Exceptions.Car;

public class CarNotFoundException : NotFoundExceptions
{
    public CarNotFoundException()
    {
        this.TitleMessage = "Car not found";
    }
}
