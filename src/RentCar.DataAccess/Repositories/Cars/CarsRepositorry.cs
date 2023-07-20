using Dapper;
using RentCar.DataAccess.Interfaces.Cars;
using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Cars;

namespace RentCar.DataAccess.Repositories.Cars;

public class CarsRepositorry : BaseRepository, ICarRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "Select Count(*) from public.cars";
            var result = await _connecting.QuerySingleAsync<long>(query);
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

    public async Task<int> CreatAsync(Car entity)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "INSERT INTO public.cars " +
                "(name, model, status, image_path, price_of_date, description, created_at, updated_at) " +
                "VALUES (@Name, @Model, @Status, @ImagePath, @PriceOfDate, @Description, @CreatedAt, @UpdatedAt);";
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
            string query = "DELETE from public.cars WHERE id = @Id";
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

    public async Task<IList<Car>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = $"SELECT * from public.cars order by id desc " +
                $"offset {@params.SkipCount()} limit {@params.PageSize}";
            var result = (await _connecting.QueryAsync<Car>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Car>();
        }
        finally
        {
            await _connecting.CloseAsync();
        }
    }

    public async Task<Car?> GetByIdAsync(long id)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "SELECT * from public.cars WHERE id = @Id";
            var result = await _connecting.QuerySingleAsync<Car>(query, new { Id = id });
            return result;
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

    public async Task<(int ItemsCount, IList<Car>)> SearchAsync(string search, Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Car entity)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = $"UPDATE public.cars SET name=@Name, model=@Model, status=@Status, " +
                $"image_path=@ImagePath, price_of_date=@PriceOfDate, description=@Description, " +
                $"created_at=@CreatedAt, updated_at=@UpdatedAt WHERE id = {id};";
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
