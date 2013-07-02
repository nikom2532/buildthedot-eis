using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class BankTypeController : ApiController
    {
        // GET api/banktype
        public IEnumerable<BankType> Get()
        {
            eisEntities ctx = new eisEntities();
            var types = from type in ctx.BankTypes1
                        select type;
            return types;
        }        
    }
}
