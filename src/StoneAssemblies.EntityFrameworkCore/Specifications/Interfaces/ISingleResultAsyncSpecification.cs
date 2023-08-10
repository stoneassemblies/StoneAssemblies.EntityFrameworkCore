namespace StoneAssemblies.EntityFrameworkCore.Specifications.Interfaces
{
    /// <summary>
    /// The SingleResultAsyncSpecification interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    public interface ISingleResultAsyncSpecification<TEntity> : IAsyncSpecification<TEntity, TEntity>
    {
    }
}