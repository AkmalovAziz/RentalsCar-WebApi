using Dapper;
using RentCar.DataAccess.Interfaces.Clients;
using RentCar.DataAccess.Utils;
using RentCar.DataAccess.ViewModels.Clients;
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
                   "first_name, last_name, phone_number, drivers_license, is_male, image_path, password_hash, salt, role, description, created_at, updated_at) " +
                   "VALUES(@FirstName, @LastName, @PhoneNumber, @DriverLicense, @IsMale, @ImagePath, @PasswordHAsh, @Salt, @Role, @Description, @CreatedAt, @UpdatedAt); ";
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

    public async Task<IList<ClientViewModel>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = $"SELECT * FROM public.clients order by id desc " +
                $"offset {@params.SkipCount()} limit {@params.PageSize}";
            var result = (await _connecting.QueryAsync<ClientViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<ClientViewModel>();
        }
        finally
        {
            await _connecting.CloseAsync();
        }
    }

    public async Task<ClientViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "SELECT * FROM public.clients where id = @Id";
            var result = await _connecting.QuerySingleAsync<ClientViewModel>(query, new { Id = id });
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

    public async Task<Client?> GetByPhoneNumberAsync(string phone)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = "SELECT * FROM public.clients where phone_number = @PhoneNumber";
            var data = await _connecting.QuerySingleAsync<Client>(query, new { PhoneNumber = phone });
            return data;
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

    public async Task<Client?> GetIdAsync(long id)
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

    public async Task<(int ItemsCount, IList<ClientViewModel>)> SearchAsync(string search, Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Client entity)
    {
        try
        {
            await _connecting.OpenAsync();
            string query = $"UPDATE public.clients SET " +
                $"first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber, drivers_license=@DriverLicense, " +
                $"is_male=@IsMale, image_path=@ImagePath, description=@Description, created_at=@CreatedAt, updated_at=@UpdatedAt WHERE id = {id};";
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
