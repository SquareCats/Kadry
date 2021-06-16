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
using Kadry.Db.Dictionaries;

namespace Kadry.Web.Controllers
{
    public class PositionDictionaryController : BaseController
    {
        #region constructor
        public PositionDictionaryController(ILogger<CountryController> logger
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
            var list = _getViewModelList<PositionDictionaryDb, PositionDictionaryViewModel>();
            return View(list);
        }
        public IActionResult Get(int id)
        {
            var dbObject = new KadryRepository<PositionDictionaryDb>(_context).GetById(id);
            var model = mapper.Map<PositionDictionaryDb, PositionDictionaryViewModel>(dbObject);
            return View(model);
        }
        [HttpPost]
        public IActionResult Get(PositionDictionaryViewModel positionVm)
        {
            var dbModel = mapper.Map<PositionDictionaryViewModel, PositionDictionaryDb>(positionVm);
            var repo = new KadryRepository<PositionDictionaryDb>(_context);
            repo.Attache(dbModel);
            repo.Save();
            var list = _getViewModelList<PositionDictionaryDb, PositionDictionaryViewModel>();
            return View("List", list);
        }
        #endregion
    }
}
