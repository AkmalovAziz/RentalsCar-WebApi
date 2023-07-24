using System.Net;

namespace RentCar.Domain.Exceptions;

public class ToManyRequestExceptions : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.TooManyRequests;

    public string TitleMessage { get; protected set; } = string.Empty;
}
