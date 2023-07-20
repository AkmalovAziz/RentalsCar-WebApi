namespace RentCar.Domain.Exceptions.Files;

public class ImageNotFoundException : NotFoundExceptions
{
    public ImageNotFoundException()
    {
        this.TitleMessage = "Image not found";
    }
}
