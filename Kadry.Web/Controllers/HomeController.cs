using AutoMapper;
using CQRS;
using Kadry.Db;
using Kadry.Web.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Kadry.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region constructor
        public HomeController(ILogger<CountryController> logger
            , KadryDbContext context
             , IMapper mapper
            , IQueryDispatcher queryDispatcher
            , ICommandDispatcher commandDispatcher
            , SignInManager<AppUser> signInManager
            , UserManager<AppUser> userManager
            , IConfiguration config
        ) : base(logger, context, mapper, queryDispatcher, commandDispatcher, signInManager, userManager, config)
        {

        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        
    }
}
