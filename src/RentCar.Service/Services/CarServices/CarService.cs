using RentCar.DataAccess.Interfaces.Cars;
using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Cars;
using RentCar.Domain.Exceptions.Car;
using RentCar.Domain.Exceptions.Files;
using RentCar.Service.Common.Helpers;
using RentCar.Service.Dtos.Cars;
using RentCar.Service.Interfaces.Cars;
using RentCar.Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Services.CarServices;

public class CarService : ICarService
{
    private IFileService _fileservis;
    private ICarRepository _repository;

    public CarService(ICarRepository carRepository, IFileService fileService)
    {
        this._fileservis = fileService;
        this._repository = carRepository;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(CarsCreateDto dto)
    {
        string image = await _fileservis.UploadImageAsync(dto.ImagePath);
        Car car = new Car();
        car.ImagePath = image;
        car.PriceOfDate = dto.PriceOfDate;
        car.Status = dto.Status;
        car.Model = dto.Model;
        car.Name = dto.Name;
        car.Description = dto.Description;
        car.CreatedAt = TimeHelper.GetDateTime();
        car.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreatAsync(car);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long carsId)
    {
        var car = await _repository.GetByIdAsync(carsId);
        if (car is null) throw new CarNotFoundException();

        var result = await _fileservis.DeleteImageAsync(car.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbresult = await _repository.DeleteAsync(carsId);
        return dbresult > 0;
    }

    public async Task<IList<Car>> GetAllAsync(Paginationparams @params)
    {
        var car = await _repository.GetAllAsync(@params);
        return car;
    }

    public async Task<Car> GetByIdAsync(long carId)
    {
        var car = await _repository.GetByIdAsync(carId);
        if (car is null) throw new CarNotFoundException();
        return car;
    }

    public async Task<bool> UpdateAsync(long carId, CarsUpdatedto dto)
    {
        var car = await _repository.GetByIdAsync(carId);
        if (car is null) throw new CarNotFoundException();

        car.Name = dto.Name;
        car.Model = dto.Model;
        car.Status = dto.Status;
        car.PriceOfDate = dto.PriceOfDate;
        car.Description = dto.Description;

        if(dto.ImagePath is not null)
        {
            var imageresult = await _fileservis.DeleteImageAsync(car.ImagePath);
            if (imageresult == false) throw new ImageNotFoundException();

            string newimage = await _fileservis.UploadImageAsync(dto.ImagePath);

            car.ImagePath = newimage;
        }

        car.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _repository.UpdateAsync(carId, car);
        return result > 0;
    }
}
