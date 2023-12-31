﻿using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Cars;
using RentCar.Service.Dtos.Cars;

namespace RentCar.Service.Interfaces.Cars;

public interface ICarService
{
    public Task<bool> CreateAsync(CarsCreateDto dto);

    public Task<Car> GetByIdAsync(long carId);

    public Task<IList<Car>> GetAllAsync(Paginationparams @params);

    public Task<bool> DeleteAsync(long carsId);

    public Task<bool> UpdateAsync(long carId, CarsUpdatedto dto);

    public Task<long> CountAsync();
}
