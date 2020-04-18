using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreUtils.TestUtilities
{
    [Flags]
    public enum SqlServerCondition
    {
        IsSqlAzure = 1 << 0,
        IsNotSqlAzure = 1 << 1,
        SupportsMemoryOptimized = 1 << 2,
        SupportsAttach = 1 << 3,
        SupportsHiddenColumns = 1 << 4,
        IsNotCI = 1 << 5,
        SupportsFullTextSearch = 1 << 6,
        SupportsOnlineIndexes = 1 << 7,
    }
}
