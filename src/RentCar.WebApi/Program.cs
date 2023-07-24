using RentCar.DataAccess.Interfaces.Cars;
using RentCar.DataAccess.Interfaces.Clients;
using RentCar.DataAccess.Interfaces.Rentals;
using RentCar.DataAccess.Repositories.Cars;
using RentCar.DataAccess.Repositories.Clients;
using RentCar.DataAccess.Repositories.Rentals;
using RentCar.Service.Interfaces.Auth;
using RentCar.Service.Interfaces.Cars;
using RentCar.Service.Interfaces.Clients;
using RentCar.Service.Interfaces.Common;
using RentCar.Service.Interfaces.Notification;
using RentCar.Service.Interfaces.Rentals;
using RentCar.Service.Services.AuthServices;
using RentCar.Service.Services.CarServices;
using RentCar.Service.Services.ClientServices;
using RentCar.Service.Services.Common;
using RentCar.Service.Services.Notification;
using RentCar.Service.Services.Rentals;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<ICarRepository, CarsRepositorry>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IRentalRepository, Rentalrepository>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddSingleton<ISmsSender, SmsSender>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
