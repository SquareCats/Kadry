using Kadry.Db;
using Kadry.Db.Data;
using Kadry.Web.Data.Context;
using Kadry.Web.Data.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kadry.Web.Data.SeedData
{
    public class KadrySeeder
    {
        private readonly KadryDbContext ctx;
        private readonly IWebHostEnvironment hosting;
        private readonly UserManager<AppUser> userManager;

        public KadrySeeder(KadryDbContext ctx, IWebHostEnvironment hosting, UserManager<AppUser> userManager)
        {
            this.ctx = ctx;
            this.hosting = hosting;
            this.userManager = userManager;
        }
        public async Task SeedAsync()
        {
            //ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            AppUser user = await userManager.FindByEmailAsync("admin@squarecats.pl");
            if (user == null)
            {
                user = new AppUser
                {
                    FirstName = "Jim",
                    LastName = "Black",
                    UserName = "admin@squarecats.pl",
                    Email = "admin@squarecats.pl",
                    Id = "admin@squarecats.pl"
                };

                var result = await userManager.CreateAsync(user, "CustomPaa$$w0rd)98");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create admin user in Seeder.");
                }

            }
            SeedCountries(user);
            SeedCurrency(user);
            SeedLogLevel(user);
            SeedPersons(user);
        }

        private void SeedPersons(AppUser user)
        {
            var personRepository = new KadryRepository<PersonDb>(ctx);
            if (!personRepository.GetAll().Any())
            {
                personRepository.InsertRange(
                    new List<PersonDb>
                    {
                        new PersonDb{ Name="Kowalski", FirstName="Jan" , DateOfBirth=new DateTime(1976,2,2), CreatedBy=user, SocialNumber="11111111119", CreatedOn=DateTime.Now }
                    }
                    );
                ctx.Database.OpenConnection();
                try
                {
                    ctx.SaveChanges();
                }
                finally
                {
                    ctx.Database.CloseConnection();
                }
            }
        }

        private void SeedCountries(AppUser user)
        {
            var countryRepository = new KadryRepository<CountryDb>(ctx);
            if (!countryRepository.GetAll().Any())
            {
                countryRepository.InsertRange(
                        new List<CountryDb>
                        {
                                new CountryDb { Name = "Polska", Sort=1, CreatedBy=user, CreatedOn=DateTime.Now, Description="" },
                                new CountryDb { Name = "Niemcy", Sort=3, CreatedBy=user, CreatedOn=DateTime.Now, Description="" },
                                new CountryDb { Name = "Czechy", Sort=5, CreatedBy=user, CreatedOn=DateTime.Now, Description="" },
                                new CountryDb { Name = "Litwa", Sort=7, CreatedBy=user, CreatedOn=DateTime.Now, Description="" },
                                new CountryDb { Name = "Słowacja", Sort=9, CreatedBy=user, CreatedOn=DateTime.Now, Description="" },
                                new CountryDb { Name = "Irlandia", Sort=11, CreatedBy=user, CreatedOn=DateTime.Now, Description="" },
                                new CountryDb { Name = "Wlk. Brytania", Sort=11, CreatedBy=user, CreatedOn=DateTime.Now, Description="" },
                                new CountryDb { Name = "-- Nie określono --", Sort=90, CreatedBy=user, CreatedOn=DateTime.Now, Description="" },
                        }
                        );
                ctx.Database.OpenConnection();
                try
                {
                    ctx.SaveChanges();
                }
                finally
                {
                    ctx.Database.CloseConnection();
                }
            }
        }

        private void SeedLogLevel(AppUser user)
        {
            //level
            var levelsRepository = new KadryRepository<LevelDictionaryDb>(ctx);
            if (!levelsRepository.GetAll().Any())
            {
                using var tran1 = ctx.Database.BeginTransaction();
                try
                {
                    ctx.Database.OpenConnection();
                    ctx.Database.ExecuteSqlRaw("dbcc checkident ('dbo.LevelDictionary', reseed, -1)");
                    levelsRepository.InsertRange(
                        new List<LevelDictionaryDb>
                        {
                                new LevelDictionaryDb { /*Id = 0,*/ Name = "Brak Informacji", CreatedBy=user, CreatedOn=DateTime.Now  },
                                new LevelDictionaryDb { /*Id = 1,*/ Name = "Informacja", CreatedBy=user, CreatedOn=DateTime.Now  },
                                new LevelDictionaryDb { /*Id = 2,*/ Name = "Ostrzeżenie", CreatedBy=user, CreatedOn=DateTime.Now  },
                                new LevelDictionaryDb { /*Id = 3,*/ Name = "Błąd", CreatedBy=user, CreatedOn=DateTime.Now  },
                                new LevelDictionaryDb { /*Id = 4,*/ Name = "Błąd Krytyczny", CreatedBy=user, CreatedOn=DateTime.Now   }

                        }
                        );
                    ctx.SaveChanges();
                    tran1.Commit();
                }

                catch (Exception)
                {
                    tran1.Rollback();
                }
                finally
                {
                    ctx.Database.CloseConnection();
                }
            }
        }

        private void SeedCurrency(AppUser user)
        {
            var currenciesRepository = new KadryRepository<CurrencyDb>(ctx);
            //currency
            if (!currenciesRepository.GetAll().Any())
            {
                ctx.Database.ExecuteSqlRaw("dbcc checkident ('dbo.CurrencyDictionary', reseed, -1)");
                currenciesRepository.InsertRange(
                        new List<CurrencyDb>
                        {
                            new CurrencyDb { Name = "No Information", CreatedBy=user, CreatedOn=DateTime.Now },
                            new CurrencyDb { Name = "Zloty", CreatedBy=user , CreatedOn=DateTime.Now},
                            new CurrencyDb { Name = "Euro", CreatedBy=user, CreatedOn=DateTime.Now },
                            new CurrencyDb { Name = "Dolar", CreatedBy=user, CreatedOn=DateTime.Now } }
                        );
                ctx.Database.OpenConnection();
                try
                {
                    ctx.SaveChanges();
                }
                finally
                {
                    ctx.Database.CloseConnection();
                }
            }
        }
    }
}
