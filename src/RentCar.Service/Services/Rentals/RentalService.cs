using RentCar.DataAccess.Interfaces.Rentals;
using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Rentals;
using RentCar.Domain.Exceptions.Rental;
using RentCar.Service.Common.Helpers;
using RentCar.Service.Dtos.Rentals;
using RentCar.Service.Interfaces.Rentals;

namespace RentCar.Service.Services.Rentals;

public class RentalService : IRentalService
{
    private IRentalRepository _repository;

    public RentalService(IRentalRepository rentalRepository)
    {
        this._repository = rentalRepository;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(RentalsCreateDto dto)
    {
        var rental = new Rental();
        rental.StartDate = dto.StartDate;
        rental.EndDate = dto.EndDate;
        rental.Destination = dto.Destination;
        rental.Payment = dto.Payment;
        rental.IsPayment = dto.IsPayment;
        rental.Description = dto.Description;
        rental.CreatedAt = TimeHelper.GetDateTime();
        rental.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.CreatAsync(rental);
        return dbResult > 0;
    }

    public async Task<bool> DeleteAsync(long rentalId)
    {
        var rental = await _repository.GetByIdAsync(rentalId);
        if (rental is null) throw new RentalNotFoundException();

        var dbResult = await _repository.DeleteAsync(rentalId);
        return dbResult > 0;
    }

    public async Task<IList<Rental>> GetAllAsync(Paginationparams @params)
        => await _repository.GetAllAsync(@params);

    public async Task<Rental> GetByIdAsync(long rentalId)
        => await _repository.GetByIdAsync(rentalId);

    public async Task<bool> UpdateAsync(long rentalId, RentalsUpdateDto dto)
    {
        var rental = await _repository.GetByIdAsync(rentalId);
        if (rental is null) throw new RentalNotFoundException();

        rental.StartDate = dto.StartDate;
        rental.EndDate = dto.EndDate;
        rental.Destination = dto.Destination;
        rental.Payment = dto.Payment;
        rental.IsPayment = dto.IsPayment;
        rental.Description = dto.Description;
        rental.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(rentalId, rental);
        return dbResult > 0;
    }
}
