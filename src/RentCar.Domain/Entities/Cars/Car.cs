using RentCar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Entities.Cars;

public class Car : AudiTable
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Model { get; set; } = string.Empty;

    public CarStatus Status { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public float PriceOfDate { get; set; }

    public string Description { get; set; } = string.Empty;
}
