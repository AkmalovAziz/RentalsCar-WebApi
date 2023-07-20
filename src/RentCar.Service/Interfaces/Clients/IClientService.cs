using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Clients;
using RentCar.Service.Dtos.Clients;

namespace RentCar.Service.Interfaces.Clients;

public interface IClientService
{
    public Task<bool> CreateAsync(ClientCreateDto dto);

    public Task<IList<Client>> GetAllAsync(Paginationparams @params);

    public Task<Client> GetByIdAsync(long clientId);

    public Task<bool> DeleteAsync(long clientId);

    public Task<bool> UpdateAsync(long clientId, ClientUpdateDto dto);

    public Task<long> CountAsync();
}
