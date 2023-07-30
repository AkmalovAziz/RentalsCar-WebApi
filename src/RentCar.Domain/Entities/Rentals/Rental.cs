using RentCar.Domain.Enums;

namespace RentCar.Domain.Entities.Rentals;

public class Rental : AudiTable
{
    public int Days { get; set; }
    public string Destination { get; set; } = string.Empty;

    public PaymentType Payment { get; set; }

    public bool IsPayment { get; set; }

    public string Description { get; set; } = string.Empty;
}
