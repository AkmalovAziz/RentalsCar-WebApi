using System.Net;

namespace RentCar.Domain.Exceptions;

public class NotFoundExceptions : Exception
{
    public HttpStatusCode Statuscode { get; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = string.Empty;
}
