using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions;

public class ToManyRequestExceptions : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.TooManyRequests;

    public string TitleMessage { get; protected set; } = string.Empty;
}
