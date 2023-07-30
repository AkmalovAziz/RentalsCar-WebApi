using RentCar.DataAccess.ViewModels.Transactions;
using RentCar.Domain.Entities.Transactions;

namespace RentCar.DataAccess.Interfaces.Transactions;

public interface ITransactionRepository : IRepository<Transaction, TransactionViewModel>
{
    public Task<Transaction?> GetIdAsync(long id);
}
