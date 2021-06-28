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
using Kadry.Web.Business.Commands.Position;
using System;

namespace Kadry.Web.Controllers.SimpleCrudControllers
{
    public class PositionController : GenericBaseController<PositionDb, PositionViewModel>
    {
        #region Constructor
        public PositionController(ILogger<CountryController> logger
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
        [HttpPost]
        public IActionResult PositionAdd(PositionViewModel posiotionVm)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var positionToAdd = mapper.Map<PositionViewModel, PositionDb>(posiotionVm);
            var personAddCommand = new PositionAddCommand { Position = positionToAdd, Host = ip };
            var commandResult = commandDispatcher.Execute<PositionAddCommand>(personAddCommand);
            if (commandResult.IsError)
            {
                ModelState.AddModelError("Position command error occurred.", commandResult.CommandError);
                ViewBag.Error = commandResult.CommandError;
                return View("PositionGet", posiotionVm);
            }
            var list = mapper.Map<IEnumerable<PositionDb>, IEnumerable<PositionViewModel>>(new KadryRepository<PositionDb>(_context).GetAll());
            return View("PositionList", list);
        }

        public IActionResult PositionList()
        {
            return View(GenericEntityList());
        }
        public IActionResult PositionGet(int id)
        {
            return View(EntityGet(id));
        }
        public IActionResult PositionAdd(int id)
        {
            var model = new PositionViewModel();
            var person = new PersonViewModel
            {
                FirstName = "",
                Name = "",
                ObjectGuid = Guid.NewGuid(),
                SocialNumber = ""
            };
            model.Person = person;
            return View("PositionGet", model);
        }
    }
}
