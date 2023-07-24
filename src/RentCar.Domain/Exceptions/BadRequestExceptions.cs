using System.Net;

namespace RentCar.Domain.Exceptions;

public class BadRequestExceptions : Exception
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;

    public string TitleMessage { get; protected set; } = string.Empty;
}
