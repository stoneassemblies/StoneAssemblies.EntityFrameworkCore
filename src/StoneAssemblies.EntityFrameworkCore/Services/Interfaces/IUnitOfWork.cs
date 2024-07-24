namespace StoneAssemblies.EntityFrameworkCore.Services.Interfaces
{
    using Microsoft.EntityFrameworkCore.Storage;

    /// <summary>
    /// The UnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets a repository instance.
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <returns>
        /// The repository instance.
        /// </returns>
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;

        /// <summary>
        /// Save changes.
        /// </summary>
        Task SaveChangesAsync();

        /// <summary>
        /// The begin transaction.
        /// </summary>
        /// <returns>
        /// The <see cref="IDbContextTransaction" />.
        /// </returns>
        IDbContextTransaction BeginTransaction();

        /// <summary>
        /// Gets the current transaction.
        /// </summary>
        IDbContextTransaction? CurrentTransaction { get; }

        /// <summary>
        /// Gets a value indicating whether the unit of work is in a transaction.
        /// </summary>
        bool IsInTransaction { get; }
    }

    /// <summary>
    /// The UnitOfWork interface.
    /// </summary>
    /// <typeparam name="TDbContext">
    /// The db context type.
    /// </typeparam>
    public interface IUnitOfWork<TDbContext> : IUnitOfWork
    {
    }
}
