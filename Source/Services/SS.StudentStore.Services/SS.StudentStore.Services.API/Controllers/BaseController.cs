using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SS.StudentStore.Services.API.Controllers
{
    
    [ApiController]
    [ApplciationExceptinoFilter]
    //[ApiVersion]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [Produces("application/Json")]
    public class BaseController : Controller
    {

    }

    public class ApplciationExceptinoFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
        }

    }
}
