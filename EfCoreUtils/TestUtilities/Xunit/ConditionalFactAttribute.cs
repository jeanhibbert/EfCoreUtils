using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace EfCoreUtils.TestUtilities.Xunit
{
    [AttributeUsage(AttributeTargets.Method)]
    [XunitTestCaseDiscoverer(
        "Microsoft.EntityFrameworkCore.TestUtilities.Xunit.ConditionalFactDiscoverer",
        "Microsoft.EntityFrameworkCore.Specification.Tests")]
    public sealed class ConditionalFactAttribute : FactAttribute
    {
    }
}
