using Microsoft.Extensions.Logging;
using Kadry.Web.Data.Context;
using AutoMapper;
using CQRS;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Kadry.Db;
using Kadry.Db.Data;
using Kadry.Web.Models.BusinessLogicViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Kadry.Web.Data.Repository;
using Kadry.Web.Business.Commands.Person;
using System;
using Kadry.Web.Models;
using System.Linq;
namespace Kadry.Web.Controllers.SimpleCrudControllers
{
    public partial class PersonController : GenericBaseController<PersonDb, PersonViewModel>
    {
        #region Constructor
        public PersonController(ILogger<CountryController> logger
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

        public IActionResult PersonGet(int id)
        {
            return View(EntityGet(id));
        }
        [HttpPost]
        public IActionResult PersonGet(PersonViewModel personVm)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var personToAdd = mapper.Map<PersonViewModel, PersonDb>(personVm);
            var personAddCommand = new PersonAddCommand { Person = personToAdd, Host = ip };
            var commandResult = commandDispatcher.Execute<PersonAddCommand>(personAddCommand);
            if (commandResult.IsError)
            {
                ModelState.AddModelError("Person command error occurred.", commandResult.CommandError);
                ViewBag.Error = commandResult.CommandError;
                return View("PersonGet", personVm);
            }
            var list = mapper.Map<IEnumerable<PersonDb>, IEnumerable<PersonViewModel>>(new KadryRepository<PersonDb>(_context).GetAll());
            return View("PersonList", list);

            //var dbModel = mapper.Map<PersonViewModel, PersonDb>(personVm);
            //var repo = new KadryRepository<PersonDb>(_context);
            //repo.Attache(dbModel);
            //repo.Save();
            //var list = mapper.Map<IEnumerable<PersonDb>, IEnumerable<PersonViewModel>>(new KadryRepository<PersonDb>(_context).GetAll());
            //return View("List", list);
        }

        public IActionResult PersonList()
        {
            return View(GenericEntityList());
        }
        public IActionResult PersonAdd()
        {
            var model = new PersonViewModel
            {
                FirstName = "",
                Name = "",
                ObjectGuid = Guid.NewGuid(),
                SocialNumber = ""
            };
            return View("PersonGet", model);
        }


        [HttpGet]
        public JsonResult PersonsJson(string text)
        {
            var list = new List<ListModelItem>();
            var b = 
                            (
                            from PersonViewModel item in GenericEntityFilteredList(x => x.Name.StartsWith(text))
                            select new ListModelItem { value = item.Id.ToString(), text = item.Description }
                            ).ToList()
                         ;

            return Json(b);
        }
    }
}
