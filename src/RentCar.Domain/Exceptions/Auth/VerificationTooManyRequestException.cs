namespace RentCar.Domain.Exceptions.Auth;

public class VerificationTooManyRequestException : ToManyRequestExceptions
{
    public VerificationTooManyRequestException()
    {
        TitleMessage = "You tried more than limits!";
    }
}
