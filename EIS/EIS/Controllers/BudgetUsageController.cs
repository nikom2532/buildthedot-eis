using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class BudgetUsageController : ApiController
    {
        // GET api/budgetusage
        public IEnumerable<BudgetUsage> Get(int year)
        {
            var ctx = new eisEntities();
            var result = from record in ctx.BudgetUsages1
                         where record.Year == year
                         select record;
            return result;
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        public void Update([FromBody]BudgetUsage model) {
            var ctx = new eisEntities();
            ctx.ExecuteStoreCommand("UPDATE BudgetUsage " +
                                    "   SET BudgetAmount = {0} " +
                                    "      ,Used = {1} " +
                                    "      ,LastUpdated = {2} " +
                                    " WHERE Id = {3} ",
                                    model.BudgetAmount,
                                    model.Used,
                                    DateTime.Now,
                                    model.Id);
        }
    }
}
