using RentCar.DataAccess.Interfaces.Clients;
using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Clients;
using RentCar.Domain.Exceptions.Client;
using RentCar.Domain.Exceptions.Files;
using RentCar.Service.Common.Helpers;
using RentCar.Service.Dtos.Clients;
using RentCar.Service.Interfaces.Clients;
using RentCar.Service.Interfaces.Common;

namespace RentCar.Service.Services.ClientServices;

public class ClientService : IClientService
{
    private IClientRepository _repository;
    private IFileService _fileservise;

    public ClientService(IClientRepository clientRepository, IFileService fileService)
    {
        this._repository = clientRepository;
        this._fileservise = fileService;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();


    public async Task<bool> CreateAsync(ClientCreateDto dto)
    {
        string image = await _fileservise.UploadImageAsync(dto.ImagePath);
        Client client = new Client();
        client.FirstNAme = dto.FirstNAme;
        client.LastNAme = dto.LastNAme;
        client.PhoneNumber = dto.PhoneNumber;
        client.IsMAle = dto.IsMAle;
        client.DeliveyLicense = dto.DeliveryLicense;
        client.Description = dto.Description;
        client.CreatedAt = TimeHelper.GetDateTime();
        client.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreatAsync(client);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long clientId)
    {
        var client = await _repository.GetByIdAsync(clientId);
        if (client is null) throw new ClientNotFoundException();

        var image = await _fileservise.DeleteImageAsync(client.ImagePath);
        if (image == false) throw new ImageNotFoundException();

        var result = await _repository.DeleteAsync(clientId);
        return result > 0;
    }

    public async Task<IList<Client>> GetAllAsync(Paginationparams @params)
    {
        var client = await _repository.GetAllAsync(@params);
        return client;
    }

    public async Task<Client> GetByIdAsync(long clientId)
    {
        var client = await _repository.GetByIdAsync(clientId);
        if (client is null) throw new ClientNotFoundException();

        return client;
    }

    public async Task<bool> UpdateAsync(long clientId, ClientUpdateDto dto)
    {
        var client = await _repository.GetByIdAsync(clientId);
        if (client is null) throw new ClientNotFoundException();

        client.FirstNAme = dto.FirstNAme;
        client.LastNAme = dto.LastNAme;
        client.PhoneNumber = dto.PhoneNumber;
        client.IsMAle = dto.IsMAle;
        client.DeliveyLicense = dto.DeliveyLicense;
        client.Description = dto.Description;

        if (dto.ImagePath is not null)
        {
            var image = await _fileservise.DeleteImageAsync(client.ImagePath);
            if (image == false) throw new ImageNotFoundException();

            string newimage = await _fileservise.UploadImageAsync(dto.ImagePath);
            client.ImagePath = newimage;
        }
        client.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.UpdateAsync(clientId, client);
        return dbResult > 0;
    }
}
