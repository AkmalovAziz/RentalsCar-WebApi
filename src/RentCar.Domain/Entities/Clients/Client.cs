using System.ComponentModel.DataAnnotations;

namespace RentCar.Domain.Entities.Clients;

public class Client : AudiTable
{
    [MaxLength(50)]
    public string FirstNAme { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastNAme { get; set; } = string.Empty;

    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string DeliveyLicense { get; set; } = string.Empty;

    public bool IsMAle { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

}
