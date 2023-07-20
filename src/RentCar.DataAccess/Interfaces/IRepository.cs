using RentCar.DataAccess.Utils;

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
