using Microsoft.AspNetCore.Http;
using RentCar.Domain.Enums;

namespace RentCar.Service.Dtos.Clients;

public class ClientCreateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string DriverLicense { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public UserRole Role { get; set; }

    public IFormFile ImagePath { get; set; } = default!;

    public string PasswordHAsh { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
