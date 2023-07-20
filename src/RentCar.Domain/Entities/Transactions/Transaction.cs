namespace RentCar.Domain.Entities.Transactions;

public class Transaction : AudiTable
{
    public long CarId { get; set; }

    public long ClientId { get; set; }

    public long RentalId { get; set; }

    public string Description { get; set; } = string.Empty;
}
