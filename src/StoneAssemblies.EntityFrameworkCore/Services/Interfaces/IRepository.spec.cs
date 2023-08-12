namespace StoneAssemblies.EntityFrameworkCore.Services.Interfaces
{
    using System.Linq.Expressions;

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
        /// <param name="enumerableResultSpecification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        IEnumerable<TEntity>? Find(IEnumerableResultSpecification<TEntity> enumerableResultSpecification);

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <param name="listAsyncResultSpecification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<List<TEntity>?> FindAsync(IListAsyncResultSpecification<TEntity> listAsyncResultSpecification);

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <param name="singleResultSpecification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TEntity Single(ISingleResultSpecification<TEntity> singleResultSpecification);

        /// <summary>
        /// Finds entities by specification async.
        /// </summary>
        /// <param name="singleResultAsyncSpecification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TEntity> SingleAsync(ISingleResultAsyncSpecification<TEntity> singleResultAsyncSpecification);

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <param name="singleResultSpecification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        TEntity? SingleOrDefault(ISingleResultSpecification<TEntity> singleResultSpecification);

        /// <summary>
        /// Finds entities by specification async.
        /// </summary>
        /// <param name="singleResultAsyncSpecification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        Task<TEntity?> SingleOrDefaultAsync(ISingleResultAsyncSpecification<TEntity> singleResultAsyncSpecification);

        /// <summary>
        /// Delete entities match with the specified predicate.
        /// </summary>
        /// <param name="specification">
        /// The specification
        /// </param>
        void Delete(IQueryableSpecification<TEntity> specification);

        /// <summary>
        /// Finds a single entity matches with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicates
        /// </param>
        /// <returns>
        /// The entity.
        /// </returns>
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Finds a single entity matches with the specified predicate.
        /// </summary>
        /// <param name="predicate">
        /// The predicates
        /// </param>
        /// <returns>
        /// The entity.
        /// </returns>
        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
