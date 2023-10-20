namespace StoneAssemblies.EntityFrameworkCore.Specifications.Interfaces
{
    using System;
    using System.Linq;

    /// <summary>
    /// The Specification interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    public interface ISpecification<TEntity>
    {
        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="Func{TQueryable, TResult}"/>.
        /// </returns>
        Func<IQueryable<TEntity>, IQueryable<TEntity>> Build();
    }

    /// <summary>
    /// The Specification interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// The output type.
    /// </typeparam>
    public interface ISpecification<in TEntity, out TOutput>
    {
        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="Func{TQueryable, TResult}"/>.
        /// </returns>
        Func<IQueryable<TEntity>, IQueryable<TOutput>> Build();
    }
}
