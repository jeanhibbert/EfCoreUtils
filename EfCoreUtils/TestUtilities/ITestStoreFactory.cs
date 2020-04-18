using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreUtils.TestUtilities
{
    public interface ITestStoreFactory
    {
        TestStore Create(string storeName);
        TestStore GetOrCreate(string storeName);
        IServiceCollection AddProviderServices(IServiceCollection serviceCollection);
        //ListLoggerFactory CreateListLoggerFactory(Func<string, bool> shouldLogCategory);
    }
}
