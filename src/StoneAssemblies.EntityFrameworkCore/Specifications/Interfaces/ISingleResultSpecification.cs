namespace StoneAssemblies.EntityFrameworkCore.Specifications.Interfaces
{
    /// <summary>
    /// The SingleResultSpecification interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    public interface ISingleResultSpecification<TEntity> : ISpecification<TEntity, TEntity>
    {
    }
}
