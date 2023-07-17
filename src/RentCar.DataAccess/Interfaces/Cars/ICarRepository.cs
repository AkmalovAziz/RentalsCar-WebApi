using RentCar.DataAccess.Common.Interfaces;
using RentCar.Domain.Entities.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Interfaces.Cars;

public interface ICarRepository : IRepository<Car, Car>, ISearch<Car>
{

}
