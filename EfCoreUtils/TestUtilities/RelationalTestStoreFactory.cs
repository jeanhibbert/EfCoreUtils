using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreUtils.TestUtilities
{
    public abstract class RelationalTestStoreFactory : ITestStoreFactory
    {
        public abstract TestStore Create(string storeName);
        public abstract TestStore GetOrCreate(string storeName);
        public abstract IServiceCollection AddProviderServices(IServiceCollection serviceCollection);

        //public virtual ListLoggerFactory CreateListLoggerFactory(Func<string, bool> shouldLogCategory)
        //    => new TestSqlLoggerFactory(shouldLogCategory);
    }
}
