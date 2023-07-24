using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions;

public class BadRequestExceptions : Exception
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;

    public string TitleMessage { get; protected set; } = string.Empty;
}
