using Microsoft.AspNetCore.Http;

namespace RentCar.Service.Dtos.Clients;

public class ClientCreateDto
{
    public string FirstNAme { get; set; } = string.Empty;

    public string LastNAme { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string DeliveryLicense { get; set; } = string.Empty;

    public bool IsMAle { get; set; }

    public IFormFile ImagePath { get; set; } = default!;

    public string Description { get; set; } = string.Empty;
}
