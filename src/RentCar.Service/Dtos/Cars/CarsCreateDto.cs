﻿using Microsoft.AspNetCore.Http;
using RentCar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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