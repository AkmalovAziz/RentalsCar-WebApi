namespace RentCar.Service.Dtos.Auth;

public class VerifyDto
{
    public string PhoneNumber { get; set; } = string.Empty;

    public int Code { get; set; }
}
