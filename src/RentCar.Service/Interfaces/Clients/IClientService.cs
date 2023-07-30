using RentCar.DataAccess.Utils;
using RentCar.DataAccess.ViewModels.Clients;
using RentCar.Domain.Entities.Clients;
using RentCar.Service.Dtos.Clients;

namespace RentCar.Service.Interfaces.Clients;

public interface IClientService
{
    public Task<bool> CreateAsync(ClientCreateDto dto);

    public Task<IList<ClientViewModel>> GetAllAsync(Paginationparams @params);

    public Task<ClientViewModel> GetByIdAsync(long clientId);

    public Task<bool> DeleteAsync(long clientId);

    public Task<bool> UpdateAsync(long clientId, ClientUpdateDto dto);

    public Task<long> CountAsync();
}
