using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions.Transaction;

public class TransactionNotFoundException : NotFoundExceptions
{
    public TransactionNotFoundException()
    {
        this.TitleMessage = "Transaction not found";
    }
}
