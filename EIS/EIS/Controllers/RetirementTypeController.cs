using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class RetirementTypeController : ApiController
    {
        // GET api/retirementtype
        public IEnumerable<RetirementType> Get()
        {
            eisEntities ctx = new eisEntities();
            var types = from type in ctx.RetirementTypes1
                        select type;
            return types;
        }
    }
}
