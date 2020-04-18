using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreUtils.TestUtilities
{
    public class SqlServerTestStoreFactory : RelationalTestStoreFactory
    {
        public static SqlServerTestStoreFactory Instance { get; } = new SqlServerTestStoreFactory();

        protected SqlServerTestStoreFactory()
        {
        }

        public override TestStore Create(string storeName)
            => SqlServerTestStore.Create(storeName);

        public override TestStore GetOrCreate(string storeName)
            => SqlServerTestStore.GetOrCreate(storeName);

        public override IServiceCollection AddProviderServices(IServiceCollection serviceCollection)
            => serviceCollection.AddEntityFrameworkSqlServer();
    }
}
