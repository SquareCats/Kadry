using Microsoft.AspNetCore.Mvc;
using CQRS;
using Kadry.Db;
using Kadry.Web.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Kadry.Web.Data.Repository;
using AutoMapper;
using Kadry.Web.Models.BusinessLogicViewModel;

namespace Kadry.Web.Controllers
{
    public class CountryController : BaseController
    {

        #region constructor
        public CountryController(ILogger<CountryController> logger
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

        #region Views
        public IActionResult List()
        {
            
            var model = new KadryRepository<CountryDb>(_context).GetAll();
            return View(model);
        }
        public IActionResult Get(int id)
        {
            var dbObject = new KadryRepository<CountryDb>(_context).GetById(id);
            var model = mapper.Map<CountryDb, CountryViewModel>(dbObject);
            return View(model);
        }
        #endregion
    }
}
