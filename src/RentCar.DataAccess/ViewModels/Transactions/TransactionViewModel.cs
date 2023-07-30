using RentCar.Domain.Entities;
using RentCar.Domain.Enums;

namespace RentCar.DataAccess.ViewModels.Transactions;

public class TransactionViewModel : AudiTable
{
    public string Name { get; set; } = string.Empty;

    public float PriceOfDate { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Days { get; set; } = string.Empty;

    public PaymentType Payment { get; set; }

    public float TotalPrice { get; set; }

    public string Description { get; set; } = string.Empty;
}
