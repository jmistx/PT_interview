using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using CommonContract;

namespace RestService.Controllers
{
    public class FibonacciController : ApiController
    {
        [HttpPost]
        public void Post(FibonacciNumberRequest number)
        {
        }
    }
}