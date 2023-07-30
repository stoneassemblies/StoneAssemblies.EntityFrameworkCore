namespace StoneAssemblies.EntityFrameworkCore.Services
{
    using System;
    using System.Collections.Concurrent;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection;

    using StoneAssemblies.EntityFrameworkCore.Services.Interfaces;

    /// <summary>
    ///     The unit of work base.
    /// </summary>
    /// <typeparam name="TDbContext">
    ///     The database context type.
    /// </typeparam>
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext>
        where TDbContext : DbContext, IDisposable
    {
        /// <summary>
        ///     The database context.
        /// </summary>
        private readonly TDbContext context;

        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        ///     The repository list.
        /// </summary>
        private readonly ConcurrentDictionary<Type, IRepository> repositories = new ConcurrentDictionary<Type, IRepository>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitOfWork{TDbContext}" /> class.
        /// </summary>
        /// <param name="context">
        ///     The db context.
        /// </param>
        /// <param name="serviceProvider">
        ///     The service provider.
        /// </param>
        public UnitOfWork(TDbContext context, IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(serviceProvider);

            this.context = context;
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        ///     Gets a repository instance.
        /// </summary>
        /// <typeparam name="TEntity">
        ///     The entity type.
        /// </typeparam>
        /// <returns>
        ///     The repository instance.
        /// </returns>
        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            return (IRepository<TEntity>)this.repositories.GetOrAdd(
                typeof(TEntity),
                _ => (IRepository)this.serviceProvider.GetRequiredService(typeof(IRepository<TEntity>)));
        }

        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();

            foreach (var repository in this.repositories.Values)
            {
                await repository.SynchronizeEntitiesAsync();
            }
        }

        /// <summary>
        ///     The begin transaction.
        /// </summary>
        /// <returns>
        ///     The <see cref="IDbContextTransaction" />.
        /// </returns>
        public IDbContextTransaction BeginTransaction()
        {
            return this.context.Database.BeginTransaction();
        }
    }
}
