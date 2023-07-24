using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions.Auth;

public class PasswordNotMatchExceptions : BadRequestExceptions
{
    public PasswordNotMatchExceptions()
    {
        TitleMessage = "password is invalid!";
    }
}
