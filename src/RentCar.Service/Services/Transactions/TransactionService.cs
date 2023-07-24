using RentCar.DataAccess.Interfaces.Transactions;
using RentCar.DataAccess.Utils;
using RentCar.DataAccess.ViewModels;
using RentCar.Domain.Entities.Transactions;
using RentCar.Domain.Exceptions.Transaction;
using RentCar.Service.Dtos.Transactions;
using RentCar.Service.Interfaces.Common;
using RentCar.Service.Interfaces.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Services.Transactions;

public class TransactionService : ITransactionService
{
    private ITransactionRepository _repository;
    private IPaginator _paginator;

    public TransactionService(ITransactionRepository transactionRepository,
        IPaginator paginator)
    {
        this._repository = transactionRepository;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(TransactionCreateDto dto)
    {
        Transaction transaction = new Transaction();
        transaction.CarId = dto.CarId;
        transaction.RentalId = dto.RentalId;
        transaction.ClientId = dto.ClientId;
        transaction.TotalPrice = dto.TotalPrice;
        transaction.Description = dto.Description;

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
}
