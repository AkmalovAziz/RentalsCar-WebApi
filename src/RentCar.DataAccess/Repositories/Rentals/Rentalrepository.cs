using Dapper;
using RentCar.DataAccess.Interfaces.Rentals;
using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Rentals;

namespace RentCar.DataAccess.Repositories.Rentals;

public class Rentalrepository : BaseRepository, IRentalRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "SELECT COUNT(*) FROM rentals;";
            return await _connecting.QuerySingleAsync<long>(query);
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connecting.CloseAsync();
        }
    }

    public async Task<int> CreatAsync(Rental entity)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "INSERT INTO public.rentals(start_date, end_date, destination, payment_type, is_payment, description, created_at, updated_at) " +
                "VALUES (@StartDate, @EndDate, @Destination, @Payment, @IsPayment, @Description, @CreatedAt, @UpdatedAt);";
            var result = await _connecting.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connecting.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "DELETE FROM rentals WHERE id = @Id;";
            return await _connecting.ExecuteAsync(query, new { Id = id });
            ;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connecting.CloseAsync();
        }
    }

    public async Task<IList<Rental>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = $"SELECT * FROM rentals Order by id desc " +
                $"offset {@params.SkipCount()} limit {@params.PageSize}";
            var result = (await _connecting.QueryAsync<Rental>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Rental>();
        }
        finally
        {
            await _connecting.CloseAsync();
        }
    }

    public async Task<Rental?> GetByIdAsync(long id)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "SELECT * FROM rentals WHERE id = @Id;";
            return await _connecting.QuerySingleAsync<Rental>(query, new { Id = id });
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connecting.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Rental entity)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "UPDATE public.rentals SET start_date=@StartDate, end_date=@EndDate, destination=@Destination, payment_type=@PaymentType, is_payment=@IsPayment, description=@Description, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                "WHERE id = @Id;";
            var result = await _connecting.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connecting.CloseAsync();
        }
    }
}
