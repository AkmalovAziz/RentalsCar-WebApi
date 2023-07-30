using RentCar.DataAccess.Utils;
using RentCar.DataAccess.ViewModels.Transactions;
using RentCar.Domain.Entities.Transactions;
using RentCar.Service.Dtos.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Interfaces.Transactions;

public interface ITransactionService
{
    public Task<bool> CreateAsync(TransactionCreateDto dto);

    public Task<TransactionViewModel?> GetByIdAsync(long transactionId);

    public Task<bool> DeleteAsync(long transactionId);

    public Task<IList<TransactionViewModel>> GetAllAsync(Paginationparams @params);

    public Task<long> CountAsync();

    public Task<bool> UpdateAsync(long transactionId, TransactionUpdateDto dto);
}
