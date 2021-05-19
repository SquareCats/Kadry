using Kadry.Db;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Kadry.Web.Models.Dictionaries;
using Kadry.Web.Models;

namespace Kadry.Web.Data.Context
{
    public class KadryDbContext : IdentityDbContext<AppUser>
    {
        public KadryDbContext(DbContextOptions<KadryDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            modelBuilder.Entity<LevelDictionaryDb>().Property(x => x.Id).ValueGeneratedOnAdd();

           
            ConfigureModel(modelBuilder);
            base.OnModelCreating(modelBuilder);
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

            var entityTypes = Assembly.GetAssembly(typeof(MyEntity)).GetTypes().Where(x => (x.IsSubclassOf(typeof(MyEntity)) && !x.IsSubclassOf(typeof(BaseViewModel))) 
                                && !x.IsAbstract 
                               

                                );

            foreach (var entityType in entityTypes)
            {
                entityMethod.MakeGenericMethod(entityType).Invoke(modelBuider, new object[] { });
            }
        }
        
    }
}
