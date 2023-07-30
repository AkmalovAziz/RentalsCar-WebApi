using System.Net;

namespace RentCar.Domain.Exceptions;

public class BadRequestExceptions : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

    public override string TitleMessage { get; protected set; } = string.Empty;
}
