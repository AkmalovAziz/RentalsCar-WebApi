using RentCar.Domain.Entities.Clients;

namespace RentCar.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GeneratedToken(Client client);
}
