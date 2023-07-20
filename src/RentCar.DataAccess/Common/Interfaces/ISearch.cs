using RentCar.DataAccess.Utils;

namespace RentCar.DataAccess.Common.Interfaces;

public interface ISearch<TViewModel>
{
    public Task<(int ItemsCount, IList<TViewModel>)> SearchAsync(string search, Paginationparams @params);
}
