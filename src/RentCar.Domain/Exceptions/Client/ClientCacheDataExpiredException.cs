namespace RentCar.Domain.Exceptions.Client;

public class ClientCacheDataExpiredException : ExpiredExceptions
{
    public ClientCacheDataExpiredException()
    {
        TitleMessage = "Client data has expired!";
    }
}
