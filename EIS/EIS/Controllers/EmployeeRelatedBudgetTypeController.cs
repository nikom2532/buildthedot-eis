using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class EmployeeRelatedBudgetTypeController : ApiController
    {
        // GET api/employeerelatedbudgettype
        public IEnumerable<EmployeeRelatedBudgetType> Get()
        {
            eisEntities ctx = new eisEntities();
            var types = from type in ctx.EmployeeRelatedBudgetTypes1
                        select type;
            return types;
        }       
    }
}
