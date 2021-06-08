using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Kadry.Web.Data.Context;
using Microsoft.EntityFrameworkCore;
using Kadry.Db;
using Kadry.Web.Data.Repository;

namespace Kadry.Tests
{
    

    //[TestClass]
    //public class BaseTestClass
    //{
    //    protected string TestCountryNameAssignInTestBaseClass { get; set; }
    //    protected Guid TestContrahentGuidAssignInTestBaseClass { get; set; }
    //    protected int TestCountryIdAssignInTestBaseClass { get; set; }

    //    [TestInitialize]
    //    public void RepositoryTestInit()
    //    {
    //        TestCountryNameAssignInTestBaseClass = "testcikowy Kraj";
    //        TestContrahentGuidAssignInTestBaseClass = Guid.NewGuid();
    //        TestCountryIdAssignInTestBaseClass = -1300;
    //        ContextOptions = new DbContextOptionsBuilder<KadryDbContext>()
    //            .UseInMemoryDatabase<KadryDbContext>("inMemoryTestDataBase")//.UseSqlite("Filename=Test.db")
    //            .Options;
    //        Seed();
    //    }
    //    protected DbContextOptions<KadryDbContext> ContextOptions { get; set; }

    //    private void Seed()
    //    {
    //        using var context = new KadryDbContext(ContextOptions);
    //        context.Database.EnsureDeleted();
    //        context.Database.EnsureCreated();
    //        var user = default(AppUser);
    //        var country1 = new CountryDb
    //        {
    //            Name = TestCountryNameAssignInTestBaseClass
    //            ,
               
    //            CreatedBy = user
    //            ,
    //            CreatedOn = DateTime.Now
                
    //            ,
    //            Id = TestCountryIdAssignInTestBaseClass
    //            ,
    //            ObjectGuid = TestContrahentGuidAssignInTestBaseClass
    //        };
    //        var country2 = new CountryDb
    //        {
    //            Name = string.Format("Inna nazwa: {0}", TestCountryNameAssignInTestBaseClass)
                
    //            ,
    //            CreatedBy = user
    //            ,
    //            CreatedOn = DateTime.Now
    //            ,
                
    //            Id = TestCountryIdAssignInTestBaseClass + 28
    //            ,
    //            ObjectGuid = Guid.NewGuid()
    //        };
    //        var country3 = new CountryDb
    //        {
    //            Name = "Zupełnie różny klient"
    //           ,
    //            CreatedBy = user
    //            ,
    //            CreatedOn = DateTime.Now
                
    //            ,
    //            Id = 9998799
    //            ,
    //            ObjectGuid = Guid.NewGuid()
    //        };
    //        var repository = new KadryRepository<CountryDb>(context);

    //        repository.Insert(country1);
    //        repository.Insert(country2);
    //        repository.Insert(country3);

    //        context.SaveChanges();
    //    }
    //}
}
