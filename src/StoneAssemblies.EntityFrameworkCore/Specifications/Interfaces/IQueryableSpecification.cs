namespace StoneAssemblies.EntityFrameworkCore.Specifications.Interfaces
{
    using System.Linq;

    /// <summary>
    /// The QueryableSpecification interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    public interface IQueryableSpecification<TEntity> : ISpecification<TEntity, IQueryable<TEntity>>
    {
    }
}
