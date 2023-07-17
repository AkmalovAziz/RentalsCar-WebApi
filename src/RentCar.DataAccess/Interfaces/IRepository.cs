using RentCar.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Interfaces;

public interface IRepository<TEntity, TViewModel>
{
    public Task<int> CreatAsync(TEntity entity);

    public Task<IList<TViewModel>> GetAllAsync(Paginationparams @params);

    public Task<int> UpdateAsync(long id, TEntity entity);

    public Task<int> DeleteAsync(long id);

    public Task<long> CountAsync();

    public Task<TViewModel> GetByIdAsync(long id);
}
