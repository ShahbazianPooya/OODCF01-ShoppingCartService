namespace CustomerBasketManagement.Domain.Common
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : AggregateRoot<TPrimaryKey>
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(TPrimaryKey key);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
