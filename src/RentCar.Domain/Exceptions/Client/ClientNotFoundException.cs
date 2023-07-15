using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions.Client;

public class ClientNotFoundException : NotFoundExceptions
{
    public ClientNotFoundException()
    {
        this.TitleMessage = "Client not found";
    }
}
