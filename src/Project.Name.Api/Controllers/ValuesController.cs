using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Cors;
using Microsoft.AspNet.Mvc;

namespace Project.Name.Controllers
{
    [Route("[controller]")]
    [EnableCors("Allow")]
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
}
