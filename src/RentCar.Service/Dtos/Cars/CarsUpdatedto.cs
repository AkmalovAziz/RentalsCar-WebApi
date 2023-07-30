using Microsoft.AspNetCore.Http;
using RentCar.Domain.Enums;

namespace RentCar.Service.Dtos.Cars;

public class CarsUpdatedto
{
    public string Name { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public IFormFile? ImagePath { get; set; }

    public float PriceOfDate { get; set; }

    public string Description { get; set; } = string.Empty;
}
