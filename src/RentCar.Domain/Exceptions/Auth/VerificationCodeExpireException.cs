namespace RentCar.Domain.Exceptions.Auth;

public class VerificationCodeExpireException : ExpiredExceptions
{
    public VerificationCodeExpireException()
    {
        TitleMessage = "Verification code is expired!";
    }
}
