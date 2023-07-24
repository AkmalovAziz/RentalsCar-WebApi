using RentCar.Domain.Enums;

namespace RentCar.Service.Dtos.Rentals;

public class RentalsCreateDto
{
    public string StartDate { get; set; } = string.Empty;

    public string EndDate { get; set; } = string.Empty;

    public string Destination { get; set; } = string.Empty;

    public PaymentType Payment { get; set; }

    public bool IsPayment { get; set; }

    public string Description { get; set; } = string.Empty;
}
