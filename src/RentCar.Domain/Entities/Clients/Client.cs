using RentCar.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Domain.Entities.Clients;

public class Client : AudiTable
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string DriverLicense { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public UserRole Role { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public string PasswordHAsh { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

}
