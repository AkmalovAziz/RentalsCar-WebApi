using Microsoft.AspNetCore.Http;
using RentCar.Domain.Enums;

namespace RentCar.Service.Dtos.Cars;

public class CarsCreateDto
{
    public string Name { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public CarStatus Status { get; set; }

    public IFormFile ImagePath { get; set; } = default!;

    public float PriceOfDate { get; set; }

    public string Description { get; set; } = string.Empty;
}
