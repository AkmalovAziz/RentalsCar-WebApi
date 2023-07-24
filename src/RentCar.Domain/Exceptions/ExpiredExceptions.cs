using System.Net;

namespace RentCar.Domain.Exceptions;

public class ExpiredExceptions : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.Gone;

    public string TitleMessage { get; protected set; } = string.Empty;
}
