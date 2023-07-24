using RentCar.DataAccess.Utils;

namespace RentCar.Service.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, Paginationparams @params);
}
