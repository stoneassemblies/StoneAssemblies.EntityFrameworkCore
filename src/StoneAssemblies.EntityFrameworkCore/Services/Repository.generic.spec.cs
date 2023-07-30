namespace StoneAssemblies.EntityFrameworkCore.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            return specification.Build().Invoke(_context.Set<TEntity>()).Any();
        }

        /// <summary>
        /// Finds entities by specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        public IEnumerable<TEntity>? Find(IEnumerableSpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(_context.Set<TEntity>());
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

            _context.Set<TEntity>().RemoveRange(specification.Build().Invoke(_context.Set<TEntity>()));
        }
    }
}
