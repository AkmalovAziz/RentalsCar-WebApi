using Dapper;
using RentCar.DataAccess.Interfaces.Clients;
using RentCar.DataAccess.Utils;
using RentCar.Domain.Entities.Clients;
using static Dapper.SqlMapper;

namespace RentCar.DataAccess.Repositories.Clients;

public class ClientRepository : BaseRepository, IClientRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "SELECT COUNT(*) FROM clients;";
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

    public async Task<int> CreatAsync(Client entity)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "INSERT INTO public.clients( " +
                   "first_name, last_name, phone_number, drivers_license, is_male, image_path, description, created_at, updated_at) " +
                   "VALUES(@FirstName, @LastName, @PhoneNumber, @DriversLicense, @IsMale, @ImagePath, @Description, @CreatedAt, @UpdatedAt); ";
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
            string query = "DELETE * FROM public.clients where id = @Id";
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

    public async Task<IList<Client>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = $"SELECT * FROM public.clients order by id desc " +
                $"offset{@params.SkipCount()} limit{@params.PageSize}";
            var result = (await _connecting.QueryAsync<Client>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Client>();
        }
        finally
        {
            await _connecting.CloseAsync();
        }
    }

    public async Task<Client?> GetByIdAsync(long id)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "SELECT * FROM public.clients where id = @Id";
            var result = await _connecting.QuerySingleAsync<Client>(query, new { Id = id });
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

    public Task<(int ItemsCount, IList<Client>)> SearchAsync(string search, Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Client entity)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = $"UPDATE public.clients SET " +
                $"first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber, drivers_license=@DriversLicense, " +
                $"is_male=@IsMale, image_path=@ImagePath, description=@Description, created_at=@reatedAt, updated_at=@UpdatedAt WHERE <id = {id}>;";
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
