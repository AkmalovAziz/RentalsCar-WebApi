using RentCar.DataAccess.ViewModels;
using RentCar.Domain.Entities.Transactions;

namespace RentCar.DataAccess.Interfaces.Transactions;

public interface ITransactionRepository : IRepository<Transaction, TransactionViewModel>
{

}
