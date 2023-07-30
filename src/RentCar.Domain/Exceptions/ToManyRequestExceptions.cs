using System.Net;

namespace RentCar.Domain.Exceptions;

public class ToManyRequestExceptions : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.TooManyRequests;

    public override string TitleMessage { get; protected set; } = string.Empty;
}
