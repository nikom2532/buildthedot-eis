using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class FundMemberTypeController : ApiController
    {
        // GET api/fundmembertype
        public IEnumerable<FundMemberType> Get()
        {
            eisEntities ctx = new eisEntities();
            var types = from type in ctx.FundMemberTypes
                        select type;
            return types;
        }

    }
}
