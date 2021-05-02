using Kadry.Db;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kadry.Web.Data.Context
{
    public class KadryDbContext : IdentityDbContext
    {
        public KadryDbContext(DbContextOptions<KadryDbContext> options)
            : base(options)
        {
        }

        private void ConfigureModel(ModelBuilder modelBuider)
        {
            var entityMethodCollection = typeof(ModelBuilder)
                .GetMethods()
                .Where(x =>
                            x.Name == "Entity"
                            && x.IsGenericMethod
                            && x.ToString().Contains("Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder")
                );
            var entityMethod = entityMethodCollection.FirstOrDefault();

            var entityTypes = Assembly.GetAssembly(typeof(MyEntity)).GetTypes().Where(x => x.IsSubclassOf(typeof(MyEntity)) && !x.IsAbstract);

            foreach (var entityType in entityTypes)
            {
                entityMethod.MakeGenericMethod(entityType).Invoke(modelBuider, new object[] { });
            }
        }
    }
}
