using System;
using AutoMapper;
using CQRS;
using Kadry.Db;
using Kadry.Web.Business.Commands.Person;
using Kadry.Web.Data.Context;
using Kadry.Web.Data.Repository;
using Kadry.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Kadry.Web.Controllers
{
    public abstract class GenericBaseController<T, Q>  : Controller where T : MyEntity where Q : BaseViewModel
    {
        #region Class Members
        protected readonly ILogger<BaseController> _logger;
        protected readonly KadryDbContext _context;
        protected readonly IMapper mapper;
        protected readonly IQueryDispatcher queryDispatcher;
        protected readonly ICommandDispatcher commandDispatcher;
        protected readonly SignInManager<AppUser> signInManager;
        protected readonly UserManager<AppUser> userManager;
        protected readonly IConfiguration config;
        #endregion

        #region Constructor
        public GenericBaseController(
            ILogger<BaseController> logger
            , KadryDbContext context
            , IMapper mapper
            , IQueryDispatcher queryDispatcher
            , ICommandDispatcher commandDispatcher
            , SignInManager<AppUser> signInManager
            , UserManager<AppUser> userManager
            , IConfiguration config
        )
        {
            _logger = logger;
            this._context = context;
            this.mapper = mapper;
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.config = config;
        }
        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult EntityGet(int id) 
        {
            var model = mapper.Map<T, Q>(new KadryRepository<T>(_context).GetById(id)); 
            return View(model);
        }
        public IEnumerable<Q> GenericEntityList()
        {
            var model = mapper.Map<IEnumerable<T>, IEnumerable<Q>>(new KadryRepository<T>(_context).GetAll());
            return model;
        }
        public IEnumerable<Q> GenericEntityFilteredList(Func<T, bool> expression)
        {
            var model = mapper.Map<IEnumerable<T>, IEnumerable<Q>>(new KadryRepository<T>(_context).Filter(expression));
            return model;
        }
        #region Views

        #endregion
        //protected IEnumerable<Q> _getViewModelList<Q>() where Q:BaseViewModel
        //{
        //    var listDb = new KadryRepository<T>(_context).GetAll();
        //    var model = mapper.Map< IEnumerable<T> , IEnumerable<Q>>(listDb);
        //    return model;
        //}
        //protected Q _getModelEntity<Q>(int id) where Q : BaseViewModel
        //{
        //    var modelDb = new KadryRepository<T>(_context).GetById(id);
        //    var model = mapper.Map<T, Q>(modelDb);
        //    return model;
        //}

        //protected async Task<List<Q>> _getViewModelListAsync<T, Q>() where T : MyEntity where Q : BaseViewModel
        //{
        //    var listDb = new KadryRepository<T>(_context).GetAllAsync();
        //    var model = mapper.Map< Task<List<T>>, List<Q>> (listDb);
        //    return model;
        //}
    }


}
