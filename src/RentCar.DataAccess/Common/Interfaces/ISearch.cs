using RentCar.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Common.Interfaces;

public interface ISearch<TViewModel>
{
    public Task<(int ItemsCount, IList<TViewModel>)> SearchAsync(string search, Paginationparams @params);
}
