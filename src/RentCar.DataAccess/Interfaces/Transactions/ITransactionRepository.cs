using RentCar.DataAccess.ViewModels;
using RentCar.Domain.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Interfaces.Transactions;

public interface ITransactionRepository : IRepository<Transaction, TransactionViewModel>
{

}
