using RentCar.Service.Interfaces.Auth;
using RentCar.Service.Interfaces.Cars;
using RentCar.Service.Interfaces.Clients;
using RentCar.Service.Interfaces.Common;
using RentCar.Service.Interfaces.Notification;
using RentCar.Service.Interfaces.Rentals;
using RentCar.Service.Interfaces.Transactions;
using RentCar.Service.Services.AuthServices;
using RentCar.Service.Services.CarServices;
using RentCar.Service.Services.ClientServices;
using RentCar.Service.Services.Common;
using RentCar.Service.Services.Notification;
using RentCar.Service.Services.Rentals;
using RentCar.Service.Services.Transactions;

namespace RentCar.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IRentalService, RentalService>();
        builder.Services.AddScoped<ICarService, CarService>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddScoped<ITransactionService, TransactionService>();
        //builder.Services.AddSingleton<ISmsSender, SmsSender>();
    }
}
