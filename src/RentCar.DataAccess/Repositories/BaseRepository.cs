using Dapper;
using Npgsql;

namespace RentCar.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connecting;

    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connecting = new NpgsqlConnection("Host=localhost; Port=5432; Database=RentalsCar-db; User Id=postgres; Password=1111;");
    }
}
