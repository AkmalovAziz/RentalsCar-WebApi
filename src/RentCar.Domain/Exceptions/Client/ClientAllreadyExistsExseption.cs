using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions.Client;

public class ClientAllreadyExistsExseption : AlreadyExistsExceptions
{
    public ClientAllreadyExistsExseption()
    {
        TitleMessage = "Client already exists";
    }

    public ClientAllreadyExistsExseption(string phone)
    {
        TitleMessage = "This phone is already registered";
    }
}
