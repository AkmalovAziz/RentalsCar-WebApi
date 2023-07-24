namespace RentCar.Domain.Exceptions.Client;

public class ClientAllreadyExistsExseption : AlreadyExistsExceptions
{
    public ClientAllreadyExistsExseption()
    {
        TitleMessage = "Client already exists";
    }

    public ClientAllreadyExistsExseption(string phone)
    {
        TitleMessage = "This phone is already registered";
    }
}
