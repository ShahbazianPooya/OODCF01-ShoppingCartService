using CustomerBasketManagement.Domain.Common;
using Dapper.Contrib.Extensions;
using System.Data;

namespace CustomerBasketManagement.Infrastructure.Persistence
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : AggregateRoot<TPrimaryKey>
    {
        private readonly IDbConnection _dbConnection;
        public Repository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async virtual Task AddAsync(TEntity entity)
        {
            await _dbConnection.InsertAsync(entity);
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            await _dbConnection.DeleteAsync(entity);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbConnection.GetAllAsync<TEntity>();
        }

        public async virtual Task<TEntity> GetByIdAsync(TPrimaryKey key)
        {
            return await _dbConnection.GetAsync<TEntity>(key);
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            await _dbConnection.UpdateAsync(entity);
        }
    }
}
