using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class WarrantFundController : ApiController
    {
        // GET api/warrantfund
        public IEnumerable<WarrantFundProvider> Get()
        {
            eisEntities ctx = new eisEntities();
            var providers = from provider in ctx.WarrantFundProviders
                           select provider;
            return providers;
        }
        
    }
}
