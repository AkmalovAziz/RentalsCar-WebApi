using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Rentals;
using RentCar.Service.Dtos.Rentals;

namespace RentCar.Service.Interfaces.Rentals;

public interface IRentalService
{
    public Task<bool> CreateAsync(RentalsCreateDto dto);

    public Task<Rental> GetByIdAsync(long rentalId);

    public Task<long> CountAsync();

    public Task<bool> DeleteAsync(long rentalId);

    public Task<bool> UpdateAsync(long rentalId, RentalsUpdateDto dto);

    public Task<IList<Rental>> GetAllAsync(Paginationparams @params);
}
