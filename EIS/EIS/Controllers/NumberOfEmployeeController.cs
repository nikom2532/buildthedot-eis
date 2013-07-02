using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class NumberOfEmployeeController : ApiController
    {
        // GET api/numberofemployee/get
        public IEnumerable<NumberOfEmployee> Get(int year)
        {
            var ctx = new eisEntities();
            var result = from record in ctx.NumberOfEmployees1
                         where record.Year == year
                         select record;
            return result;
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        public void Update([FromBody]NumberOfEmployee model) {
            var ctx = new eisEntities();
            ctx.ExecuteStoreCommand("UPDATE NumberOfEmployee "+
                                    "   SET GovernmentOfficer = {0} "+
                                    "      ,PermanentContractor = {1} "+
                                    "      ,GeneralOfficer = {2} "+
                                    "      ,LastUpdated = {3} " +
                                    " WHERE Id = {4} ", 
                                    model.GovernmentOfficer,
                                    model.PermanentContractor,
                                    model.GeneralOfficer,
                                    DateTime.Now,
                                    model.Id);
        }
        
    }
}
