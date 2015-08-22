using EntityFramework.BulkInsert.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace EFAdvancedLib.Extensions
{
    public static class DbSetExtensions
    {
        public static void BulkInsert<TEntity>(this DbSet<TEntity> dbSet, IEnumerable<TEntity> entities, DbContext context, IDbTransaction transaction, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default, int? batchSize = null) where TEntity : class
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.BulkInsert(entities, transaction, sqlBulkCopyOptions, batchSize);
        }
        public static void BulkInsert<TEntity>(this DbSet<TEntity> dbSet, IEnumerable<TEntity> entities, DbContext context, BulkInsertOptions options) where TEntity : class
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.BulkInsert(entities, options);
        }
    }
}
