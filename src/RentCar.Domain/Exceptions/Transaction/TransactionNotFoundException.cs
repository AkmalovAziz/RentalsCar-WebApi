namespace RentCar.Domain.Exceptions.Transaction;

public class TransactionNotFoundException : NotFoundExceptions
{
    public TransactionNotFoundException()
    {
        this.TitleMessage = "Transaction not found";
    }
}
