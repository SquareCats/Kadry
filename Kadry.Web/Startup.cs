using CQRS;
using Kadry.Db;
using Kadry.Web.Data.Context;
using Kadry.Web.Data.Repository;
using Kadry.Web.Data.SeedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Kadry.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(
                cfg =>
                {
                    cfg.User.RequireUniqueEmail = true;
                }
                ).AddEntityFrameworkStores<KadryDbContext>();

            services.AddDbContext<KadryDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("KadryDb")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<KadryDbContext>();
            services.AddScoped<IRepository<MyEntity>, KadryRepository<MyEntity>>();

            services.AddScoped<DbContextOptionsBuilder>();
            //var provider = services.BuildServiceProvider();
            //services.add<IServiceProvider, ServiceProvider>();
            services.AddSingleton<IServiceProvider>(w => services.BuildServiceProvider());
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            //Register Commands
            Assembly.GetExecutingAssembly()
           .GetTypes()
           .Where(item => item.GetInterfaces()
           .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)) && !item.IsAbstract && !item.IsInterface)
           .ToList()
           .ForEach(assignedTypes =>
           {
               var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));
               services.AddScoped(serviceType, assignedTypes);
           });
            //Register Queries
            Assembly.GetExecutingAssembly()
           .GetTypes()
           .Where(item => item.GetInterfaces()
           .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)) && !item.IsAbstract && !item.IsInterface)
           .ToList()
           .ForEach(assignedTypes =>
           {
               var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>));
               services.AddScoped(serviceType, assignedTypes);
           });

            //Add seeder Class
            services.AddTransient<KadrySeeder>();


            //Configure Automapper
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddControllersWithViews();
            services.AddRazorPages();
            //object p = services.AddMvc().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<KadryDbContext>())
                context.Database.Migrate();
        }
    }
}
