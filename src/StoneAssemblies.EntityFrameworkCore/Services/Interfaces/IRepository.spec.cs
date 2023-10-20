namespace StoneAssemblies.EntityFrameworkCore.Services.Interfaces
{
    using StoneAssemblies.EntityFrameworkCore.Specifications.Interfaces;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity.
    /// </typeparam>
    public partial interface IRepository<TEntity> 
    {
        /// <summary>
        /// Indicates whether at least one entity matches with the specified specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// <c>True</c> if at least one entity matches with the predicates otherwise <c>False</c>.
        /// </returns>
        public bool Contains(ISpecification<TEntity> specification);

        /// <summary>
        /// Indicates whether at least one entity matches with the specified specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// <c>True</c> if at least one entity matches with the predicates otherwise <c>False</c>.
        /// </returns>
        public Task<bool> ContainsAsync(ISpecification<TEntity> specification);

        /// <summary>
        /// Counts entity matches with the specified specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Count(ISpecification<TEntity> specification);

        /// <summary>
        /// Counts entity matches with the specified specification.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The output type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Count<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Counts entity matches with the specified specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> CountAsync(ISpecification<TEntity> specification);
        
        /// <summary>
        /// Counts entity matches with the specified specification.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The output type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> CountAsync<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        IEnumerable<TEntity>? Find(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds entities by specification async.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The output type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        IEnumerable<TOutput> Find<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds entities by specification async.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The output type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<IEnumerable<TOutput>> FindAsync<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Finds single entity by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TEntity Single(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds single entity by specification.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The entity type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TOutput Single<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Finds single entity by specification async.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TEntity> SingleAsync(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds single entity by specification.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The output type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TOutput> SingleAsync<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Finds single or default entity by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TEntity? SingleOrDefault(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds single or default entity by specification.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The output type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TOutput? SingleOrDefault<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Finds single or default entity by specification async.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds single or default entity by specification async.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The output type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TOutput?> SingleOrDefaultAsync<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Finds first entity by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TEntity First(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds first entity by specification.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The entity type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TOutput First<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Finds first entity by specification async.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TEntity> FirstAsync(ISpecification<TEntity> specification);
        
        /// <summary>
        /// Finds first entity by specification async.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The output type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TOutput> FirstAsync<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Finds first or default entity by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TEntity? FirstOrDefault(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds first or default by specification.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The output type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TOutput? FirstOrDefault<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Finds first or default by specification async.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification);
        
        /// <summary>
        /// Finds first or default by specification async.
        /// </summary>
        /// <typeparam name="TOutput">
        /// The output type.
        /// </typeparam>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TOutput?> FirstOrDefaultAsync<TOutput>(ISpecification<TEntity, TOutput> specification);

        /// <summary>
        /// Delete entities match with the specified predicate.
        /// </summary>
        /// <param name="specification">
        /// The specification
        /// </param>
        void Delete(ISpecification<TEntity> specification);
    }
}
