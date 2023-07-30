using Dapper;
using RentCar.DataAccess.Interfaces.Transactions;
using RentCar.DataAccess.Utils;
using RentCar.DataAccess.ViewModels.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace RentCar.DataAccess.Repositories.Transaction;

public class TransactionRepository : BaseRepository, ITransactionRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "SELECT COUNT(*) FROM transactions";
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

    public async Task<int> CreatAsync(Domain.Entities.Transactions.Transaction entity)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "INSERT INTO public.transactions(car_id, client_id, rental_id, total_price, description, created_at, updated_at) " +
                "VALUES (@CarId, @ClientId, @RentalId, @TotalPrice, @Description, @CreatedAt, @UpdatedAt);";
            return await _connecting.ExecuteAsync(query, entity);
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
            string query = "DELETE FROM transactions WHERE id=@Id";
            return await _connecting.ExecuteAsync(query, new { Id = id });
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

    public async Task<IList<TransactionViewModel>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "select transactions.id, cars.name, cars.image_path, cars.price_of_date, clients.first_name, clients.last_name, clients.phone_number, " +
                "rentals.days, rentals.payment_type, transactions.total_price, transactions.description from transactions " +
                "join cars on transactions.car_id = cars.id " +
                "join clients on transactions.client_id = clients.id " +
                "join rentals on transactions.rental_id = rentals.id order by transactions.id desc " +
                "offset 0 limit 10";
            return (await _connecting.QueryAsync<TransactionViewModel>(query)).ToList();
        }
        catch
        {
            return new List<TransactionViewModel>();
        }
        finally
        {
            await _connecting.CloseAsync();
        }
    }

    public async Task<TransactionViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "select transactions.id, cars.name, cars.image_path, cars.price_of_date, clients.first_name, clients.last_name, clients.phone_number, " +
                "rentals.days, rentals.payment_type, transactions.total_price, transactions.description from transactions " +
                "join cars on transactions.car_id = cars.id " +
                "join clients on transactions.client_id = clients.id " +
                "join rentals on transactions.rental_id = rentals.id where transactions.id = @Id;";
            return await _connecting.QuerySingleAsync<TransactionViewModel>(query, new {Id = id});
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

    public async Task<Domain.Entities.Transactions.Transaction?> GetIdAsync(long id)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "SELECT * FROM transactions WHERE id=@Id";
            return await _connecting.QuerySingleAsync<Domain.Entities.Transactions.Transaction>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Domain.Entities.Transactions.Transaction entity)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = $"UPDATE transactions SET car_id=@CarId, rental_id=@RentalId, client_id=@ClientId, description=@Description Where id = {id};";
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
}
