using RentCar.DataAccess.Interfaces.Cars;
using RentCar.DataAccess.Interfaces.Clients;
using RentCar.DataAccess.Interfaces.Rentals;
using RentCar.DataAccess.Interfaces.Transactions;
using RentCar.DataAccess.Utils;
using RentCar.DataAccess.ViewModels.Transactions;
using RentCar.Domain.Entities.Transactions;
using RentCar.Domain.Exceptions.Car;
using RentCar.Domain.Exceptions.Client;
using RentCar.Domain.Exceptions.Rental;
using RentCar.Domain.Exceptions.Transaction;
using RentCar.Service.Common.Helpers;
using RentCar.Service.Dtos.Transactions;
using RentCar.Service.Interfaces.Common;
using RentCar.Service.Interfaces.Transactions;
using RentCar.Service.Validators.Dtos.Transactions;

namespace RentCar.Service.Services.Transactions;

public class TransactionService : ITransactionService
{
    private ITransactionRepository _repository;
    private IPaginator _paginator;
    private ICarRepository _carRepository;
    private IRentalRepository _rentalRepository;
    private IClientRepository _clientRepository;

    public TransactionService(ITransactionRepository transactionRepository,
        IPaginator paginator, ICarRepository carRepository, IRentalRepository rentalRepository,
        IClientRepository clientRepository)
    {
        this._repository = transactionRepository;
        this._paginator = paginator;
        this._carRepository = carRepository;
        this._rentalRepository = rentalRepository;
        this._clientRepository = clientRepository;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(TransactionCreateDto dto)
    {
        var car = await _carRepository.GetByIdAsync(dto.CarId);
        if (car is null) throw new CarNotFoundException();

        var rental = await _rentalRepository.GetByIdAsync(dto.RentalId);
        if (rental is null) throw new RentalNotFoundException();

        var client = await _clientRepository.GetByIdAsync(dto.ClientId);
        if (rental is null) throw new ClientNotFoundException();

        Transaction transaction = new Transaction();
        transaction.CarId = dto.CarId;
        transaction.RentalId = dto.RentalId;
        transaction.ClientId = dto.ClientId;
        transaction.TotalPrice = (car.PriceOfDate * rental.Days);
        transaction.Description = dto.Description;
        transaction.CreatedAt = transaction.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreatAsync(transaction);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long transactionId)
    {
        var transaction = await _repository.GetByIdAsync(transactionId);
        if (transaction is null) throw new TransactionNotFoundException();

        var dbResult = await _repository.DeleteAsync(transactionId);
        return dbResult > 0;
    }

    public async Task<IList<TransactionViewModel>> GetAllAsync(Paginationparams @params)
    {
        var transaction = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return transaction;
    }

    public async Task<TransactionViewModel?> GetByIdAsync(long transactionId)
    {
        var transaction = await _repository.GetByIdAsync(transactionId);
        if (transaction is null) throw new TransactionNotFoundException();

        return transaction;
    }

    public async Task<bool> UpdateAsync(long transactionId, TransactionUpdateDto dto)
    {
        var transaction = await _repository.GetIdAsync(transactionId);
        if (transaction is null) throw new TransactionNotFoundException();

        var car = await _carRepository.GetByIdAsync(dto.CarId);
        if (car is null) throw new CarNotFoundException();

        var rental = await _rentalRepository.GetByIdAsync(dto.RentalId);
        if (rental is null) throw new RentalNotFoundException();

        var client = await _clientRepository.GetByIdAsync(dto.ClientId);
        if (rental is null) throw new ClientNotFoundException();

        transaction.CarId = dto.CarId;
        transaction.RentalId = dto.RentalId;
        transaction.ClientId = dto.ClientId;
        transaction.Description = dto.Description;
        transaction.TotalPrice = (car.PriceOfDate * rental.Days);

        transaction.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(transactionId, transaction);
        return dbResult > 0;
    }
}
