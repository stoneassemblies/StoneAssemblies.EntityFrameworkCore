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
        int Count(ISpecification<TEntity> specification);

        /// <summary>
        /// Counts entity matches with the specified specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        Task<int> CountAsync(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <returns>
        /// The entities.
        /// </returns>
        IEnumerable<TEntity>? Find(ISpecification<TEntity> specification);

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
        /// Finds entities by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TEntity Single(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds entities by specification async.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TEntity> SingleAsync(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TEntity? SingleOrDefault(ISpecification<TEntity> specification);

        /// <summary>
        /// Finds entities by specification async.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification);

        /// <summary>
        /// Delete entities match with the specified predicate.
        /// </summary>
        /// <param name="specification">
        /// The specification
        /// </param>
        void Delete(ISpecification<TEntity> specification);
    }
}
