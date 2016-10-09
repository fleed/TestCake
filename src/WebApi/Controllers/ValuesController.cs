using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class ValuesController
    {
        [HttpGet]
        public string[] Get()
        {
            return new[] { "value1", "value2" };
        }
    }
}
