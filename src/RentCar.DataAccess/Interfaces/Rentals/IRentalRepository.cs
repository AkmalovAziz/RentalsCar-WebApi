using RentCar.Domain.Entities.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Interfaces.Rentals;

public interface IRentalRepository : IRepository<Rental, Rental>
{

}
