using RentCar.Service.Dtos.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Interfaces.Cars;

public interface ICarService
{
    public Task<bool> CreateAsync(CarsCreateDto dto);
}
