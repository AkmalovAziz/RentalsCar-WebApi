using System.Net;

namespace RentCar.Domain.Exceptions;

public class ExpiredExceptions : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Gone;

    public override string TitleMessage { get; protected set; } = string.Empty;
}
