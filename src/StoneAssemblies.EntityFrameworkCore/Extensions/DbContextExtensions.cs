namespace StoneAssemblies.EntityFrameworkCore.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    using StoneAssemblies.EntityFrameworkCore.Exceptions;

    /// <summary>
    /// 
    /// </summary>
    public static class DbContextExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static IEnumerable<object?> GetPrimaryKeyValues<TEntity>(this DbContext context, TEntity entity) 
            where TEntity : class
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(entity);

            var entityType = typeof(TEntity);
            var modelEntityType = context.GetModelEntityType(entityType);

            var primaryKey = modelEntityType.GetKeys().FirstOrDefault(key => key.IsPrimaryKey());
            if (primaryKey is not null)
            {
                foreach (var primaryKeyProperty in primaryKey.Properties)
                {
                    var propertyInfo = entityType.GetProperty(primaryKeyProperty.Name);
                    if (propertyInfo is not null)
                    {
                        yield return propertyInfo.GetValue(entity);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storedEntity"></param>
        /// <param name="entity"></param>
        /// <param name="ignoreProperties"></param>
        /// <typeparam name="TEntity"></typeparam>
        public static void UpdateEntity<TEntity>(this DbContext context, TEntity storedEntity, TEntity entity, params string[] ignoreProperties)
            where TEntity : class
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(storedEntity);
            ArgumentNullException.ThrowIfNull(entity);

            var entityType = typeof(TEntity);
            var modelEntityType = context.GetModelEntityType(entityType);

            foreach (var property in modelEntityType.GetProperties())
            {
                if (!ignoreProperties.Contains(property.Name))
                {
                    var propertyInfo = entityType.GetProperty(property.Name);
                    if (propertyInfo is not null)
                    {
                        propertyInfo.SetValue(storedEntity, propertyInfo.GetValue(entity));
                    }
                }
            }

            context.Set<TEntity>().Update(storedEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entityType"></param>
        /// <returns></returns>
        /// <exception cref="EntityTypeException"></exception>
        public static IEntityType GetModelEntityType(this DbContext context, Type entityType)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(entityType);

            var modelEntityType = context.Model.FindEntityType(entityType);
            if (modelEntityType is null)
            {
                throw new EntityTypeException($"The entity type '{entityType.FullName}' is not available in this context");
            }

            return modelEntityType;
        }
    }
}
