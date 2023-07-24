using System.Net;

namespace RentCar.Domain.Exceptions;

public class AlreadyExistsExceptions : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = string.Empty;
}
