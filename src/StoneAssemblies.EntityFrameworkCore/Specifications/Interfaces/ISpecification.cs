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
    /// <typeparam name="TResult">
    /// The result
    /// </typeparam>
    public interface ISpecification<in TEntity, out TResult>
    {
        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="Func"/>.
        /// </returns>
        Func<IQueryable<TEntity>, TResult?> Build();
    }
}
