using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EfCoreUtils.TestUtilities
{
    public static class DatabaseFacadeExtensions
    {
        public static bool EnsureCreatedResiliently(this DatabaseFacade facade)
            => facade.CreateExecutionStrategy().Execute(facade, f => f.EnsureCreated());

        public static Task<bool> EnsureCreatedResilientlyAsync(this DatabaseFacade façade, CancellationToken cancellationToken = default)
            => façade.CreateExecutionStrategy().ExecuteAsync(façade, (f, ct) => f.EnsureCreatedAsync(ct), cancellationToken);
    }
}
