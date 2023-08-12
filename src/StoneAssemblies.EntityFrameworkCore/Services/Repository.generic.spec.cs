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
        public bool Contains(ISpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>()).Any();
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
        public Task<bool> ContainsAsync(ISpecification<TEntity> specification)
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
        public int Count(ISpecification<TEntity> specification)
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
        public Task<int> CountAsync(ISpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>())!.CountAsync();
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
        public IEnumerable<TEntity> Find(ISpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>())?.ToList()!;
        }

        /// <summary>
        /// Finds entities by specification async.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The entities.
        /// </returns>
        public async Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return await specification.Build().Invoke(this.context.Set<TEntity>())!.ToListAsync();
        }

        /// <summary>
        /// The single.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public TEntity Single(ISpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>())!.Single();
        }

        /// <summary>
        /// Gets a single by spec.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public Task<TEntity> SingleAsync(ISpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>())!.SingleAsync();
        }

        /// <summary>
        /// Gets a single or default by spec.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public TEntity? SingleOrDefault(ISpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>())!.SingleOrDefault();
        }

        /// <summary>
        /// Gets a single or default by spec async.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);

            return specification.Build().Invoke(this.context.Set<TEntity>())!.SingleOrDefaultAsync();
        }

        /// <summary>
        /// Delete entities match with the specified predicate.
        /// </summary>
        /// <param name="specification">
        /// The specification
        /// </param>
        public void Delete(ISpecification<TEntity> specification)
        {
            ArgumentNullException.ThrowIfNull(specification);
            var entities = specification.Build().Invoke(this.context.Set<TEntity>())?.ToList();
            if (entities is not null)
            {
                this.context.Set<TEntity>().RemoveRange(entities);
            }
        }
    }
}
