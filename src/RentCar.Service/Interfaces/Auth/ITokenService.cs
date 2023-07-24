using RentCar.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GeneratedToken(Client client);
}
