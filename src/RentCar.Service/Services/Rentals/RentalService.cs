using RentCar.DataAccess.Interfaces.Rentals;
using RentCar.DataAccess.Interfaces.Transactions;
using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Rentals;
using RentCar.Domain.Exceptions.Rental;
using RentCar.Service.Common.Helpers;
using RentCar.Service.Dtos.Rentals;
using RentCar.Service.Interfaces.Common;
using RentCar.Service.Interfaces.Rentals;

namespace RentCar.Service.Services.Rentals;

public class RentalService : IRentalService
{
    private IRentalRepository _repository;
    private IPaginator _paginator;

    public RentalService(IRentalRepository rentalRepository,
        IPaginator paginator)
    {
        this._repository = rentalRepository;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(RentalsCreateDto dto)
    {
        var rental = new Rental();
        rental.Days = dto.Days;
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
    {
        var rental = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return rental;
    }

    public async Task<Rental> GetByIdAsync(long rentalId)
        => await _repository.GetByIdAsync(rentalId);

    public async Task<bool> UpdateAsync(long rentalId, RentalsUpdateDto dto)
    {
        var rental = await _repository.GetByIdAsync(rentalId);
        if (rental is null) throw new RentalNotFoundException();

        rental.Destination = dto.Destination;
        rental.Description = dto.Description;
        rental.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(rentalId, rental);
        return dbResult > 0;
    }
}
