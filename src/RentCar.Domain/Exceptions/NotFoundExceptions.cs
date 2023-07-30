using System.Net;

namespace RentCar.Domain.Exceptions;

public class NotFoundExceptions : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; protected set; } = string.Empty;
}
