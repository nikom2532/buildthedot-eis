using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class EstimatedFundMemberController : ApiController
    {
        // GET api/estimatedfundmember
        public IEnumerable<EstimatedFundMember> Get(int year)
        {
            var ctx = new eisEntities();
            var result = from record in ctx.EstimatedFundMembers1
                         where record.Year == year
                         select record;
            return result;
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        public void Update([FromBody]EstimatedFundMember model) {
            var ctx = new eisEntities();
            ctx.ExecuteStoreCommand("UPDATE EstimatedFundMember " +
                                    "   SET EstimatedValue = {0} " +
                                    "      ,LastUpdated = {1} " +
                                    " WHERE Id = {2} ",
                                    model.EstimatedValue,
                                    DateTime.Now,
                                    model.Id);
        }
       
    }
}
