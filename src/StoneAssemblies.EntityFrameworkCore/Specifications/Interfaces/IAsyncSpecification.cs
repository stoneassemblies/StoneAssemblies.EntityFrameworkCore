namespace StoneAssemblies.EntityFrameworkCore.Specifications.Interfaces
{
    /// <summary>
    /// The Specification interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// The result
    /// </typeparam>
    public interface IAsyncSpecification<in TEntity, TResult>
    {
        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="Func{TQueryable, Task}"/>.
        /// </returns>
        Func<IQueryable<TEntity>, Task<TResult?>> Build();
    }
}