using DemoNop.Core;
using DemoNop.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DemoNop.Data
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields
        private readonly INopDataProvider _dataProvider;
        #endregion

        #region Ctor
        public EntityRepository(INopDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        #endregion Ctor

        #region Properties
        public IQueryable<TEntity> Table => _dataProvider.GetTable<TEntity>();


        #endregion Properties

        #region Methods
        public Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? func = null, bool includeDeleted = true)
        {
            async Task<IList<TEntity>> getAllAsync()
            {
                var query = AddDeletedFilter(Table, includeDeleted);
                query = func != null ? func(query) : query;

                return await query.ToListAsync();
            }

            return getAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int? id, bool includeDeleted = true)
        {
            if (!id.HasValue || id == 0)
                return null;

            async Task<TEntity> getEntityAsync()
            {
                return await AddDeletedFilter(Table, includeDeleted).FirstOrDefaultAsync(entity => entity.Id == Convert.ToInt32(id));
            }

            return await getEntityAsync();
        }

        public TEntity? GetById(int? id, bool includeDeleted = true)
        {
            if (!id.HasValue || id == 0)
                return null;

            TEntity getEntity()
            {
                return AddDeletedFilter(Table, includeDeleted).FirstOrDefault(entity => entity.Id == Convert.ToInt32(id));
            }

            return getEntity();

        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dataProvider.InsertEntity(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _dataProvider.InsertEntityAsync(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dataProvider.UpdateEntity(entity);
        }

        public async Task<int> UpdateAsync(TEntity? entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return await _dataProvider.UpdateEntityAsync(entity);
        }

        public void Delete(TEntity? entity)
        {
            switch (entity)
            {
                case null:
                    throw new ArgumentNullException(nameof(entity));

                case ISoftDeletedEntity softDeletedEntity:
                    softDeletedEntity.Deleted = true;
                    _dataProvider.UpdateEntity(entity);
                    break;

                default:
                    _dataProvider.DeleteEntity(entity);
                    break;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            switch (entity)
            {
                case null:
                    throw new ArgumentNullException(nameof(entity));

                case ISoftDeletedEntity softDeletedEntity:
                    softDeletedEntity.Deleted = true;
                    await _dataProvider.UpdateEntityAsync(entity);
                    break;

                default:
                    await _dataProvider.DeleteEntityAsync(entity);
                    break;
            }
        }

        #endregion Methods

        #region Utilities

        /// <summary>
        /// Adds "deleted" filter to query which contains <see cref="ISoftDeletedEntity"/> entries, if its need
        /// </summary>
        /// <param name="query">Entity entries</param>
        /// <param name="includeDeleted">Whether to include deleted items</param>
        /// <returns>Entity entries</returns>
        protected virtual IQueryable<TEntity> AddDeletedFilter(IQueryable<TEntity> query, in bool includeDeleted)
        {
            if (includeDeleted)
                return query;

            if (typeof(TEntity).GetInterface(nameof(ISoftDeletedEntity)) == null)
                return query;

            return query.OfType<ISoftDeletedEntity>().Where(entry => !entry.Deleted).OfType<TEntity>();
        }


        #endregion Utilities
    }
}
