using RentCar.Domain.Enums;

namespace RentCar.Service.Dtos.Rentals;

public class RentalsUpdateDto
{
    public string Destination { get; set; } = string.Empty;

    public PaymentType Payment { get; set; }

    public string Description { get; set; } = string.Empty;
}
