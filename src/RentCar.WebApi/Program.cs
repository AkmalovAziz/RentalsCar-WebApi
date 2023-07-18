using RentCar.DataAccess.Interfaces.Cars;
using RentCar.DataAccess.Repositories.Cars;
using RentCar.Service.Interfaces.Cars;
using RentCar.Service.Interfaces.Common;
using RentCar.Service.Services.CarServices;
using RentCar.Service.Services.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICarRepository, CarsRepositorry>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICarService, CarService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
