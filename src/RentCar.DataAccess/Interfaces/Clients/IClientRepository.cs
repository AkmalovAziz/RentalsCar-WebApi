using RentCar.DataAccess.Common.Interfaces;
using RentCar.Domain.Entities.Clients;

namespace RentCar.DataAccess.Interfaces.Clients;

public interface IClientRepository : IRepository<Client, Client>, ISearch<Client>
{

}
