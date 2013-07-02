using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class RetirementFundUsageController : ApiController
    {
        // GET api/retirementfundusage
        public IEnumerable<RetirementFundUsage> Get(int year)
        {
            var ctx = new eisEntities();
            var result = from record in ctx.RetirementFundUsages1
                         where record.Year == year
                         select record;
            return result;
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        public void Update([FromBody]RetirementFundUsage model) {
            var ctx = new eisEntities();
            ctx.ExecuteStoreCommand("UPDATE RetirementFundUsage " +
                                    "   SET NumberOfPeople = {0} " +
                                    "      ,NumberOfUsage = {1} " +
                                    "      ,LastUpdated = {2} " +
                                    " WHERE Id = {3} ",
                                    model.NumberOfPeople,
                                    model.NumberOfUsage,
                                    DateTime.Now,
                                    model.Id);
        }
    }
}
