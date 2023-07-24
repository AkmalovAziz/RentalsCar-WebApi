using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions.Auth;

public class VerificationTooManyRequestException : ToManyRequestExceptions
{
    public VerificationTooManyRequestException()
    {
        TitleMessage = "You tried more than limits!";
    }
}
