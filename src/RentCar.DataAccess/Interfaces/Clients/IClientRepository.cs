using RentCar.DataAccess.Common.Interfaces;
using RentCar.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Interfaces.Clients;

public interface IClientRepository : IRepository<Client, Client>, ISearch<Client>
{

}
