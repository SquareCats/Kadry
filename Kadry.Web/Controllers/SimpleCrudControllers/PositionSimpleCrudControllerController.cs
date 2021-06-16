using Kadry.Db.Data;
using Kadry.Web.Data.Repository;
using Kadry.Web.Models.BusinessLogicViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Kadry.Web.Controllers.SimpleCrudControllers
{
    public partial class SimpleCrudController : BaseController
    {
        #region Person
        public IActionResult PositionList()
        {
            var list = _getViewModelList<PositionDb, PositionViewModel>();
            return View(list);
        }
        public IActionResult PositionGet(int id)
        {
            var model = _getModelEntity<PositionDb, PositionViewModel>(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult PositionGet(PositionViewModel personVm)
        {
            var dbModel = mapper.Map<PositionViewModel, PositionDb>(personVm);
            var repo = new KadryRepository<PositionDb>(_context);
            repo.Attache(dbModel);
            repo.Save();
            var list = _getViewModelList<PositionDb, PositionViewModel>();
            return View("List", list);
        }
        public IActionResult PositionAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PositionAdd(PositionViewModel positionVm)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var positionToAdd = mapper.Map<PositionViewModel, PositionDb>(positionVm);
            //var positionAddCommandHandler = new PositionAddCommandHandler(_context);
            //var positionAddCommand = new PositionAddCommand { position = positionToAdd, Host = ip };
            //positionAddCommandHandler.Execute(positionAddCommand);
            //if (positionAddCommand.IsError)
            //{
            //    ModelState.AddModelError("position command error occurred.", positionAddCommand.CommandError);
            //    return View("positionAdd", positionVm);
            //}
            var list = _getViewModelList<PositionDb, PositionViewModel>();
            return View("PositionList", list);
        }
        #endregion
    }
}
