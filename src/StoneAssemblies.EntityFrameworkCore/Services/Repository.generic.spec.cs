namespace StoneAssemblies.EntityFrameworkCore.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using StoneAssemblies.EntityFrameworkCore.Specifications.Interfaces;

    public partial class Repository<TEntity, TDbContext>
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
        public bool Contains(IQueryableSpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>())!.Any();
        }

        /// <summary>
        /// Indicates whether at least one entity matches with the specified specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// <c>True</c> if at least one entity matches with the predicates otherwise <c>False</c>.
        /// </returns>
        public Task<bool> ContainsAsync(IQueryableSpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>())!.AnyAsync();
        }

        /// <summary>
        /// Counts entity matches with the specified specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        public int Count(IQueryableSpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>())!.Count();
        }

        /// <summary>
        /// Counts entity matches with the specified specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        public Task<int> CountAsync(IQueryableSpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>())!.CountAsync();
        }

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <param name="enumerableResultSpecification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        public IEnumerable<TEntity>? Find(IEnumerableResultSpecification<TEntity> enumerableResultSpecification)
        {
            ArgumentNullException.ThrowIfNull(enumerableResultSpecification);

            return enumerableResultSpecification.Build().Invoke(this.context.Set<TEntity>());
        }

        /// <summary>
        /// Finds entities by specification async.
        /// </summary>
        /// <param name="asyncResultSpecification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        public Task<List<TEntity>?> FindAsync(IListAsyncResultSpecification<TEntity> asyncResultSpecification)
        {
            ArgumentNullException.ThrowIfNull(asyncResultSpecification);

            return asyncResultSpecification.Build().Invoke(this.context.Set<TEntity>());
        }

        /// <summary>
        /// The single.
        /// </summary>
        /// <param name="singleResultSpecification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public TEntity? Single(ISingleResultSpecification<TEntity> singleResultSpecification)
        {
            ArgumentNullException.ThrowIfNull(singleResultSpecification);

            return singleResultSpecification.Build().Invoke(this.context.Set<TEntity>());
        }

        /// <summary>
        /// The single.
        /// </summary>
        /// <param name="singleResultAsyncSpecification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public Task<TEntity?> SingleAsync(ISingleResultAsyncSpecification<TEntity> singleResultAsyncSpecification)
        {
            ArgumentNullException.ThrowIfNull(singleResultAsyncSpecification);

            return singleResultAsyncSpecification.Build().Invoke(this.context.Set<TEntity>());
        }

        /// <summary>
        /// Delete entities match with the specified predicate.
        /// </summary>
        /// <param name="specification">
        /// The specification
        /// </param>
        public void Delete(IQueryableSpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            this.context.Set<TEntity>().RemoveRange(specification.Build().Invoke(this.context.Set<TEntity>()));
        }
    }
}
