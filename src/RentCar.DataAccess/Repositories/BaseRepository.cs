using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connecting;

    public BaseRepository()
    {
        this._connecting = new NpgsqlConnection("Host=localhost, Port=5432, Database=RentalsCar-db, User id=postgres, Password=1111");
    }
}
