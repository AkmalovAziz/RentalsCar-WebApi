using RentCar.DataAccess.Interfaces.Clients;
using RentCar.DataAccess.Utils;
using RentCar.DataAccess.ViewModels.Clients;
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
    private IPaginator _paginator;

    public ClientService(IClientRepository clientRepository, IFileService fileService,
        IPaginator paginator)
    {
        this._repository = clientRepository;
        this._fileservise = fileService;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();


    public async Task<bool> CreateAsync(ClientCreateDto dto)
    {
        //string image = await _fileservise.UploadImageAsync(dto.ImagePath);
        //Client client = new Client();
        //client.FirstName = dto.FirstName;
        //client.LastName = dto.LastName;
        //client.PhoneNumber = dto.PhoneNumber;
        //client.IsMale = dto.IsMale;
        //client.ImagePath = image;
        //client.DriverLicense = dto.DriverLicense;
        //client.Role = 0;
        //client.Description = dto.Description;
        //client.CreatedAt = TimeHelper.GetDateTime();
        //client.UpdatedAt = TimeHelper.GetDateTime();

        //var result = await _repository.CreatAsync(client);
        //return result > 0;
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(long clientId)
    {
        var client = await _repository.GetIdAsync(clientId);
        if (client is null) throw new ClientNotFoundException();

        var image = await _fileservise.DeleteImageAsync(client.ImagePath);
        if (image == false) throw new ImageNotFoundException();

        var result = await _repository.DeleteAsync(clientId);
        return result > 0;
    }

    public async Task<IList<ClientViewModel>> GetAllAsync(Paginationparams @params)
    {
        var client = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return client;
    }

    public async Task<ClientViewModel?> GetByIdAsync(long clientId)
    {
        var client = await _repository.GetByIdAsync(clientId);
        if (client is null) throw new ClientNotFoundException();

        return client;
    }

    public async Task<bool> UpdateAsync(long clientId, ClientUpdateDto dto)
    {
        var client = await _repository.GetIdAsync(clientId);
        if (client is null) throw new ClientNotFoundException();

        client.FirstName = dto.FirstName;
        client.LastName = dto.LastName;
        client.PhoneNumber = dto.PhoneNumber;
        client.IsMale = dto.IsMale;
        client.DriverLicense = dto.DriverLicense;
        client.Description = dto.Description;

        if (dto.ImagePath is not null)
        {
            string newimage = await _fileservise.UploadImageAsync(dto.ImagePath);
            client.ImagePath = newimage;
        }
        client.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.UpdateAsync(clientId, client);
        return dbResult > 0;
    }
}
