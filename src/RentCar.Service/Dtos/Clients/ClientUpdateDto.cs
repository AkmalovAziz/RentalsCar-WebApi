using Microsoft.AspNetCore.Http;

namespace RentCar.Service.Dtos.Clients;

public class ClientUpdateDto
{
    public string FirstNAme { get; set; } = string.Empty;

    public string LastNAme { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string DeliveyLicense { get; set; } = string.Empty;

    public bool IsMAle { get; set; }

    public IFormFile ImagePath { get; set; }

    public string Description { get; set; } = string.Empty;
}
