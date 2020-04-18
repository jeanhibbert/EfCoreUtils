using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreUtils.TestUtilities
{
    public static class SqlServerDbContextOptionsBuilderExtensions
    {
        public static SqlServerDbContextOptionsBuilder ApplyConfiguration(this SqlServerDbContextOptionsBuilder optionsBuilder)
        {
            var maxBatch = TestEnvironment.GetInt(nameof(SqlServerDbContextOptionsBuilder.MaxBatchSize));
            if (maxBatch.HasValue)
            {
                optionsBuilder.MaxBatchSize(maxBatch.Value);
            }

            optionsBuilder.ExecutionStrategy(d => new TestSqlServerRetryingExecutionStrategy(d));

            optionsBuilder.CommandTimeout(SqlServerTestStore.CommandTimeout);

            return optionsBuilder;
        }
    }
}
