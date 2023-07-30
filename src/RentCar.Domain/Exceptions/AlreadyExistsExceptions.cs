using System.Net;

namespace RentCar.Domain.Exceptions;

public class AlreadyExistsExceptions : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; protected set; } = string.Empty;
}
