namespace RentCar.Domain.Exceptions.Auth;

public class PasswordNotMatchExceptions : BadRequestExceptions
{
    public PasswordNotMatchExceptions()
    {
        TitleMessage = "password is invalid!";
    }
}
