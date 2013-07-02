using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class FirstCarStatusTypeController : ApiController
    {
        // GET api/firstcarstatustype
        public IEnumerable<FirstCarStatusType> Get()
        {
            eisEntities ctx = new eisEntities();
            var types = from type in ctx.FirstCarStatusTypes1
                        select type;
            return types;
        }
       
    }
}
