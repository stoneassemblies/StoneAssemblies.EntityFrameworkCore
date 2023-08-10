namespace StoneAssemblies.EntityFrameworkCore.Specifications.Interfaces
{
    /// <summary>
    /// The list async result specification interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    public interface IListAsyncResultSpecification<TEntity> : IAsyncSpecification<TEntity, List<TEntity>>
    {
    }
}