using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Cors;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using AuthorizationContext = Microsoft.AspNet.Mvc.Filters.AuthorizationContext;

namespace Project.Name.Controllers
{
    [Route("[controller]")]
    [EnableCors("AllowAny")]
    [RequiresToken]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

    public class RequiresTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("Bearer"))
            {
                var key = context.HttpContext.Request.Headers["Bearer"];
                if (key.Equals("abc"))
                {
                    base.OnActionExecuting(context);
                    return;
                }
                    
            }
            context.Result = new BadRequestResult();

            
        }
    }
}
