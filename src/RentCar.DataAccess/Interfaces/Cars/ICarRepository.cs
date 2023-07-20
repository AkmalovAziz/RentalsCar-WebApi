using RentCar.DataAccess.Common.Interfaces;
using RentCar.Domain.Entities.Cars;

namespace RentCar.DataAccess.Interfaces.Cars;

public interface ICarRepository : IRepository<Car, Car>, ISearch<Car>
{

}
