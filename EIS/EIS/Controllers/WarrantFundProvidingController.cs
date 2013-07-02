using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class WarrantFundProvidingController : ApiController
    {
        // GET api/warrantfundproviding
        public IEnumerable<WarrantFundProviding> Get(int year)
        {
            var ctx = new eisEntities();
            var result = from record in ctx.WarrantFundProvidings1
                         where record.Year == year
                         select record;
            return result;
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        public void Update([FromBody]WarrantFundProviding model) {
            var ctx = new eisEntities();
            ctx.ExecuteStoreCommand("UPDATE WarrantFundProviding " +
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
