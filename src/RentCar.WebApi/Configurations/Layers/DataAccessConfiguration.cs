using RentCar.DataAccess.Interfaces.Cars;
using RentCar.DataAccess.Interfaces.Clients;
using RentCar.DataAccess.Interfaces.Rentals;
using RentCar.DataAccess.Interfaces.Transactions;
using RentCar.DataAccess.Repositories.Cars;
using RentCar.DataAccess.Repositories.Clients;
using RentCar.DataAccess.Repositories.Rentals;
using RentCar.DataAccess.Repositories.Transaction;

namespace RentCar.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //DI contenier
        builder.Services.AddScoped<ICarRepository, CarsRepositorry>();
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IRentalRepository, Rentalrepository>();
        builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
    }
}
