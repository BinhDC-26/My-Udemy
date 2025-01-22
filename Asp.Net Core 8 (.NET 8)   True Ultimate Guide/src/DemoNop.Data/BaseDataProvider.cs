using DemoNop.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading;
using System.Xml.Linq;

namespace DemoNop.Data
{
    public class BaseDataProvider : INopDataProvider
    {
        private NorthwindDBContext _dbContext;

        public BaseDataProvider(NorthwindDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetTable<TEntity>() where TEntity : BaseEntity
        {
            return _dbContext.Set<TEntity>();
        }

        #region Methods
        public Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sql, cancellationToken);
        }

        public Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
        }

        public void InsertEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public async Task InsertEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            await _dbContext.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdateEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            EntityEntry<TEntity> trackedEntity = _dbContext.ChangeTracker.Entries<TEntity>().FirstOrDefault(x => x.Entity == entity);

            if (trackedEntity == null)
            {
                IEntityType entityType = _dbContext.Model.FindEntityType(typeof(TEntity));

                if (entityType == null)
                {
                    throw new InvalidOperationException($"{typeof(TEntity).Name} is not part of EF Core DbContext model");
                }

                string primaryKeyName = entityType.FindPrimaryKey().Properties.Select(p => p.Name).FirstOrDefault();

                if (primaryKeyName != null)
                {
                    Type primaryKeyType = entityType.FindPrimaryKey().Properties.Select(p => p.ClrType).FirstOrDefault();

                    object primaryKeyDefaultValue = primaryKeyType.IsValueType ? Activator.CreateInstance(primaryKeyType) : null;

                    object primaryValue = entity.GetType().GetProperty(primaryKeyName).GetValue(entity, null);

                    if (primaryKeyDefaultValue.Equals(primaryValue))
                    {
                        throw new InvalidOperationException("The primary key value of the entity to be updated is not valid.");
                    }
                }

                _dbContext.Set<TEntity>().Update(entity);
            }

            int count = await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return count;
        }

        public void UpdateEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
                _dbContext.Set<TEntity>().Update(entity);
        }

        public async Task<int> DeleteEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _dbContext.Set<TEntity>().Remove(entity);
            int count = await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return count;
        }

        public void DeleteEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
        #endregion Methods
    }
}
