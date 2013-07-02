using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class EmployeeTypeController : ApiController
    {
        // GET api/employeetype
        public IEnumerable<EmployeeType> Get()
        {
            eisEntities ctx = new eisEntities();
            var types = from type in ctx.EmployeeTypes1
                        select type;
            return types;
        }
    }
}
