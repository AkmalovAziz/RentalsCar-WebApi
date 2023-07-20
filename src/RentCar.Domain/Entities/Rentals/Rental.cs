using RentCar.Domain.Enums;

namespace RentCar.Domain.Entities.Rentals;

public class Rental : AudiTable
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Destination { get; set; } = string.Empty;

    public PaymentType Payment { get; set; }

    public bool IsPayment { get; set; }

    public string Description { get; set; } = string.Empty;
}
