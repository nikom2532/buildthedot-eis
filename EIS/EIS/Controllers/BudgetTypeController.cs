using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class BudgetTypeController : ApiController
    {
        // GET api/budgettype
        public IEnumerable<BudgetType> Get()
        {
            eisEntities ctx = new eisEntities();
            var types = from type in ctx.BudgetTypes1
                        select type;
            return types;
        }
        
    }
}
