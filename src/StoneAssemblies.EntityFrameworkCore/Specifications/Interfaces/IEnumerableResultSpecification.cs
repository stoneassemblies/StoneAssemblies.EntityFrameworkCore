namespace StoneAssemblies.EntityFrameworkCore.Specifications.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The EnumerableSpecification interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    public interface IEnumerableResultSpecification<TEntity> : ISpecification<TEntity, IEnumerable<TEntity>>
    {
    }
}
