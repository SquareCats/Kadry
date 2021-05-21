using Microsoft.AspNetCore.Mvc;
using CQRS;
using Kadry.Db;
using Kadry.Web.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Threading.Tasks;
using Kadry.Db.Data;
using Kadry.Web.Models.BusinessLogicViewModel;
using Kadry.Web.Data.Repository;

namespace Kadry.Web.Controllers
{
    public class SimpleCrudController : BaseController
    {
        #region constructor
        public SimpleCrudController(ILogger<CountryController> logger
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

        #region Person
        public IActionResult PersonList()
        {
            var list = _getViewModelList<PersonDb, PersonViewModel>();
            return View(list);
        }
        public IActionResult PersonGet(int id)
        {
            var model = _getModelEntity<PersonDb, PersonViewModel>(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult PersonGet(PersonViewModel personVm)
        {
            var dbModel = mapper.Map<PersonViewModel, PersonDb>(personVm);
            var repo = new KadryRepository<PersonDb>(_context);
            repo.Attache(dbModel);
            repo.Save();
            var list = _getViewModelList<PersonDb, PersonViewModel>();
            return View("List", list);
        }
        #endregion
    }
}
