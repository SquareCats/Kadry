using Microsoft.AspNetCore.Mvc;
using CQRS;
using Kadry.Db;
using Kadry.Web.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Kadry.Web.Data.Repository;
using AutoMapper;
using Kadry.Web.Models.Dictionaries;
using System.Collections.Generic;
using Kadry.Web.Models;

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
            //var listDb = new KadryRepository<CountryDb>(_context).GetAll();
            //var model = mapper.Map<IEnumerable<CountryDb>, IEnumerable<CountryViewModel>>(listDb);
            var list = _getViewModelList<CountryDb, CountryViewModel>();
            return View(list);
        }
        public IActionResult Get(int id)
        {
            var dbObject = new KadryRepository<CountryDb>(_context).GetById(id);
            var model = mapper.Map<CountryDb, CountryViewModel>(dbObject);
            return View(model);
        }
        [HttpPost]
        public IActionResult Get(CountryViewModel countryVm)
        {
            var dbModel = mapper.Map<CountryViewModel, CountryDb>(countryVm);
            var repo = new KadryRepository<CountryDb>(_context);
            repo.Attache(dbModel);
            repo.Save();
            var list = _getViewModelList<CountryDb, CountryViewModel>();
            return View("List", list);

        }
        #endregion

    }
}
