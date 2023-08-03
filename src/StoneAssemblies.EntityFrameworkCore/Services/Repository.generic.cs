namespace StoneAssemblies.EntityFrameworkCore.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using StoneAssemblies.EntityFrameworkCore.Extensions;
    using StoneAssemblies.EntityFrameworkCore.Services.Interfaces;
    using StoneAssemblies.EntityFrameworkCore.Specifications.Interfaces;

    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    /// <typeparam name="TDbContext">
    /// The database context type.
    /// </typeparam>
    public partial class Repository<TEntity, TDbContext> : IRepository<TEntity, TDbContext>
        where TEntity : class where TDbContext : DbContext
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly TDbContext _context;

        /// <summary>
        /// List of dirty entities.
        /// </summary>
        private readonly List<TEntity> _dirtyEntities = new List<TEntity>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StoneAssemblies.EntityFrameworkCore.Services.Repository{TEntity,TDbContext}" /> class.
        /// </summary>
        /// <param name="context">
        /// The database context.
        /// </param>
        public Repository(TDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this._context = context;
        }

        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Add(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            this._dirtyEntities.Add(this._context.Set<TEntity>().Add(entity).Entity);
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>
        /// The entities.
        /// </returns>
        public IQueryable<TEntity> All()
        {
            return this._context.Set<TEntity>();
        }

        /// <summary>
        /// The begin transaction.
        /// </summary>
        /// <returns>
        /// The <see cref="IDbContextTransaction" />.
        /// </returns>
        public IDbContextTransaction BeginTransaction()
        {
            return this._context.Database.BeginTransaction();
        }

        /// <summary>
        /// The begin transaction.
        /// </summary>
        /// <param name="isolationLevel">
        /// The isolation level.
        /// </param>
        /// <returns>
        /// The <see cref="IDbContextTransaction"/>.
        /// </returns>
        public IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return this._context.Database.BeginTransaction();
        }

        /// <summary>
        /// Indicates whether at least one entity matches with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// S
        /// The predicate.
        /// </param>
        /// <returns>
        /// <c>True</c> if at least one entity matches with the predicates otherwise <c>False</c>.
        /// </returns>
        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            return this._context.Set<TEntity>().Any(predicate);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Delete(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            this._context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Delete entities match with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicate
        /// </param>
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            this._context.Set<TEntity>().RemoveRange(this.Find(predicate));
        }

        /// <summary>
        /// Finds entities match with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicates.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            return this._context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// Save changes async.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();

            await this.SynchronizeEntitiesAsync();
        }

        public TEntity TryAddOrUpdate(TEntity entity, params string[] ignoreProperties)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var keyValues = this._context.GetPrimaryKeyValues(entity).ToArray();

            if (keyValues.Length > 0)
            {
                var storedEntity = this._context.Set<TEntity>().Find(keyValues);
                if (storedEntity is not null)
                {
                    this._context.UpdateEntity(storedEntity, entity, ignoreProperties);
                    return storedEntity;
                }
            }

            return this._context.Add(entity).Entity;
        }

        /// <summary>
        /// Finds a single entity matches with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicates
        /// </param>
        /// <returns>
        /// The entity.
        /// </returns>
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            return this._context.Set<TEntity>().Single(predicate);
        }

        /// <summary>
        /// Sync dirty entities.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public Task SynchronizeEntityAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            return this._context.Entry(entity).ReloadAsync();
        }

        /// <summary>
        /// Sync dirty entities with database values.
        /// </summary>
        public async Task SynchronizeEntitiesAsync()
        {
            foreach (var dirtyEntity in this._dirtyEntities)
            {
                await this.SynchronizeEntityAsync(dirtyEntity);
            }

            this._dirtyEntities.Clear();
        }

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var keyValues = this._context.GetPrimaryKeyValues(entity).ToArray();
            var storedEntity = this._context.Set<TEntity>().Find(keyValues);
            if (storedEntity is not null)
            {
                this._context.UpdateEntity(storedEntity, entity);
            }
        }
    }
}
