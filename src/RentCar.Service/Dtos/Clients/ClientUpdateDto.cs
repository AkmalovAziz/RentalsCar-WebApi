using Microsoft.AspNetCore.Http;

namespace RentCar.Service.Dtos.Clients;

public class ClientUpdateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string DriverLicense { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public IFormFile? ImagePath { get; set; }

    public string Description { get; set; } = string.Empty;
}
