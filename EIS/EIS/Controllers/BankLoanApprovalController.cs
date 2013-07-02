using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class BankLoanApprovalController : ApiController
    {
        // GET api/bankloanapproval
        public IEnumerable<BankLoanApproval> Get(int year)
        {
            eisEntities ctx = new eisEntities();
            var result = from record in ctx.BankLoanApprovals1
                         where record.Year == year
                         select record;
            return result;
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        public void Update([FromBody]BankLoanApproval model) {
            var ctx = new eisEntities();
            ctx.ExecuteStoreCommand("UPDATE BankLoanApproval " +
                                    "   SET NumberOfPeople = {0} " +
                                    "      ,Amount = {1} " +
                                    "      ,LastUpdated = {2} " +
                                    " WHERE Id = {3} ",
                                    model.NumberOfPeople,
                                    model.Amount,
                                    DateTime.Now,
                                    model.Id);
        }
    }
}
