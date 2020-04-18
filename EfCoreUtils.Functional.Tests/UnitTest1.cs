using System;
using System.Collections.Generic;
using System.Linq;
using EfCoreUtils.TestUtilities;
using EfCoreUtils.TestUtilities.Xunit;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EfCoreUtils.Functional.Tests
{
    public class UnitTest1
    {
        [ConditionalFact]
        public void Throws_if_context_used_with_no_connection_or_connection_string()
        {
            using (SqlServerTestStore.GetNorthwindStore())
            {
                using var context = new NoneInOnConfiguringContext();
                
                //WTF
                //context.Database.SetConnectionString(SqlServerNorthwindTestStoreFactory.NorthwindConnectionString);

                Assert.True(context.Customers.Any());
            }
        }
            
        private class NoneInOnConfiguringContext : NorthwindContextBase
        {
            //WTF
            //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //    => optionsBuilder
            //        .EnableServiceProviderCaching(false)
            //        .UseSqlServer(b => b.ApplyConfiguration());
        }

        private class NorthwindContextBase : DbContext
        {
            protected NorthwindContextBase()
            {
            }

            protected NorthwindContextBase(DbContextOptions options)
                : base(options)
            {
            }

            public DbSet<Customer> Customers { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Customer>(
                    b =>
                    {
                        b.HasKey(c => c.CustomerID);
                        b.ToTable("Customers");
                    });
            }
        }

        private class Customer
        {
            public string CustomerID { get; set; }

            // ReSharper disable UnusedMember.Local
            public string CompanyName { get; set; }

            public string Fax { get; set; }
            // ReSharper restore UnusedMember.Local
        }
    }
}
