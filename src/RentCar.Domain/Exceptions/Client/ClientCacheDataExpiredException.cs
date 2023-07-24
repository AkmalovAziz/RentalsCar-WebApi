using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions.Client;

public class ClientCacheDataExpiredException : ExpiredExceptions
{
    public ClientCacheDataExpiredException()
    {
        TitleMessage = "Client data has expired!";
    }
}
