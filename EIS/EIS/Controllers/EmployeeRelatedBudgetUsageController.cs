using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class EmployeeRelatedBudgetUsageController : ApiController
    {
        // GET api/employeerelatedbudgetusage
        public IEnumerable<EmployeeRelatedBudgetUsage> Get(int year)
        {
            var ctx = new eisEntities();
            var result = from record in ctx.EmployeeRelatedBudgetUsages1
                         where record.Year == year
                         select record;
            return result;
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        public void Update([FromBody]EmployeeRelatedBudgetUsage model) {
            var ctx = new eisEntities();
            ctx.ExecuteStoreCommand("UPDATE EmployeeRelatedBudgetUsage " +
                                    "   SET Amount = {0} " +
                                    "      ,LastUpdated = {1} " +
                                    " WHERE Id = {2} ",
                                    model.Amount,
                                    DateTime.Now,
                                    model.Id);
        }
    }
}
