using Dapper;
using RentCar.DataAccess.Interfaces.Cars;
using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Repositories.Cars;

public class CarsRepositorry : BaseRepository, ICarRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
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

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Car>> GetAllAsync(Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    public Task<Car> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<(int ItemsCount, IList<Car>)> SearchAsync(string search, Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Car entity)
    {
        throw new NotImplementedException();
    }
}
