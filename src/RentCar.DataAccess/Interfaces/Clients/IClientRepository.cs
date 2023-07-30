using RentCar.DataAccess.Common.Interfaces;
using RentCar.DataAccess.ViewModels.Clients;
using RentCar.Domain.Entities.Clients;

namespace RentCar.DataAccess.Interfaces.Clients;

public interface IClientRepository : IRepository<Client, ClientViewModel>, ISearch<ClientViewModel>
{
    public Task<Client?> GetByPhoneNumberAsync(string phone);

    public Task<Client?> GetIdAsync(long id);
}
