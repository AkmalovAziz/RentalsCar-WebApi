namespace RentCar.Domain.Exceptions.Client;

public class ClientNotFoundException : NotFoundExceptions
{
    public ClientNotFoundException()
    {
        this.TitleMessage = "Client not found";
    }
}
