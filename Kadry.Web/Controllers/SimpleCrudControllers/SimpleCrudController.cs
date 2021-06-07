using Microsoft.Extensions.Logging;
using Kadry.Web.Data.Context;
using AutoMapper;
using CQRS;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Kadry.Db;

namespace Kadry.Web.Controllers.SimpleCrudControllers
{
    public partial class SimpleCrudController: BaseController 
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

        
    }
}
