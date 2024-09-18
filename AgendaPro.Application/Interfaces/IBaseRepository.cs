using AgendaPro.Domain.Helpers;

namespace AgendaPro.Application.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(Guid id);
        Task<AsyncOutResult<IEnumerable<TEntity>, int>> GetAll(int? take, int? offSet, string sortingProp, bool? asc);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> UpdateRangeAsync(IEnumerable<TEntity> listEntity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> DeleteRangeAsync(IEnumerable<TEntity> listEntity);
        Task<AsyncOutResult<IEnumerable<TEntity>, int>> PaginateAsync(int? take, int? offSet, string sortingProp, bool? asc);
    }
}
