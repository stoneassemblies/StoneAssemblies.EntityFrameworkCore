namespace StoneAssemblies.EntityFrameworkCore.Extensions
{
    using System.Linq.Expressions;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;

    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> Include<TEntity, TProperty>(
            this IQueryable<TEntity> source,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath,
            bool contition)
            where TEntity : class
        {
            return contition ? source.Include(navigationPropertyPath) : source;
        }

        public static IQueryable<TEntity> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            this IQueryable<TEntity> source, Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath,
            bool contition)
            where TEntity : class
        {
            return source switch
            {
                IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> includableQueryable when contition =>
                    includableQueryable.ThenInclude(navigationPropertyPath),
                IIncludableQueryable<TEntity, TPreviousProperty> includableQueryable when contition =>
                    includableQueryable.ThenInclude(navigationPropertyPath),
                _ => source
            };
        }

        public static IQueryable<TSource> Where<TSource>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            bool contition)
        {
            return contition ? source.Where(predicate) : source;
        }
    }
}