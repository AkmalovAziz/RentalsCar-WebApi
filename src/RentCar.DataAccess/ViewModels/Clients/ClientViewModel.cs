using RentCar.Domain.Entities;
using RentCar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.ViewModels.Clients;

public class ClientViewModel : AudiTable
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string DriverLicense { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public UserRole Role { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

}
