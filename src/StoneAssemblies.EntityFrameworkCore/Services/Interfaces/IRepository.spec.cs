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
        public bool Contains(IQueryableSpecification<TEntity> specification);

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        IEnumerable<TEntity>? Find(IEnumerableSpecification<TEntity> specification);

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TEntity? Single(ISingleResultSpecification<TEntity> specification);

        /// <summary>
        /// Delete entities match with the specified predicate.
        /// </summary>
        /// <param name="specification">
        /// The specification
        /// </param>
        void Delete(IQueryableSpecification<TEntity> specification);
    }
}
