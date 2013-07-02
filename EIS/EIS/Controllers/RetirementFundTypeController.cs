using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class RetirementFundTypeController : ApiController
    {
        // GET api/retirementfundtype
        public IEnumerable<RetirementFundType> Get()
        {
            eisEntities ctx = new eisEntities();
            var types = from type in ctx.RetirementFundTypes1
                        select type;
            return types;
        }       
    }
}
