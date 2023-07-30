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
    }

    /// <summary>
    /// The UnitOfWork interface.
    /// </summary>
    /// <typeparam name="TDbContext">
    /// The db context type.
    /// </typeparam>
    public interface IUnitOfWork<TDbContext> : IUnitOfWork
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
    }
}
