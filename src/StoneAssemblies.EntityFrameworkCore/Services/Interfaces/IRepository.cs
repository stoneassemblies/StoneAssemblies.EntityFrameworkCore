namespace StoneAssemblies.EntityFrameworkCore.Services.Interfaces
{
    using System.Data;

    using Microsoft.EntityFrameworkCore;

    using System.Linq.Expressions;

    using Microsoft.EntityFrameworkCore.Storage;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Synchronize dirty entities.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SynchronizeEntitiesAsync();
    }

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity.
    /// </typeparam>
    public partial interface IRepository<TEntity> : IRepository
        where TEntity : class
    {
        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Add(TEntity entity);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>
        /// The entities.
        /// </returns>
        IQueryable<TEntity> All();

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
        bool Contains(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete entities match with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicate
        /// </param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Finds entities match with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicates.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Finds a single entity matches with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicates
        /// </param>
        /// <returns>
        /// The entity.
        /// </returns>
        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Synchronize dirty entity.
        /// </summary>
        Task SynchronizeEntityAsync(TEntity entity);

        /// <summary>
        /// The begin transaction.
        /// </summary>
        /// <returns>
        /// The <see cref="IDbTransaction" />.
        /// </returns>
        IDbContextTransaction BeginTransaction();

        /// <summary>
        /// The begin transaction.
        /// </summary>
        /// <param name="isolationLevel">
        /// The isolation Level.
        /// </param>
        /// <returns>
        /// The <see cref="IDbTransaction"/>.
        /// </returns>
        IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// Save changes async
        /// </summary>
        /// <returns>Task</returns>
        Task SaveChangesAsync();

        /// <summary>
        /// Try add or update
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="ignoreProperties"></param>
        TEntity TryAddOrUpdate(TEntity entity, params string[] ignoreProperties);

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Update(TEntity entity);
    }

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    /// <typeparam name="TDbContext">
    /// The db context.
    /// </typeparam>
    public interface IRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class where TDbContext : DbContext
    {
    }
}
