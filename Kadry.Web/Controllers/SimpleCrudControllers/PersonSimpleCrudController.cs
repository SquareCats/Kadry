using Microsoft.AspNetCore.Mvc;
using Kadry.Db.Data;
using Kadry.Web.Models.BusinessLogicViewModel;
using Kadry.Web.Business.Commands.Person;
using Kadry.Web.Data.Repository;
using System;

namespace Kadry.Web.Controllers.SimpleCrudControllers
{
    public partial class SimpleCrudController : BaseController
    {
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
        public IActionResult PersonAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PersonAdd(PersonViewModel personVm)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var personToAdd = mapper.Map<PersonViewModel, PersonDb>(personVm);
            var personAddCommandHandler = new PersonAddCommandHandler(_context);
            var personAddCommand = new PersonAddCommand { Person = personToAdd, Host = ip };
            personAddCommandHandler.Execute(personAddCommand);
            if(personAddCommand.IsError)
            {
                ModelState.AddModelError("Person command error occurred.", personAddCommand.CommandError);
                return View("PersonAdd", personVm);
            }
            var list = _getViewModelList<PersonDb, PersonViewModel>();
            return View("PersonList", list);
        }
        #endregion
    }
}
