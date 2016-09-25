using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using CommonContract;
using MassTransit;

namespace RestService.Controllers
{
    public class FibonacciController : ApiController
    {
        [HttpPost]
        public void Post(FibonacciNumberRequest request)
        {
            WebApiApplication.BusControl.Publish<CalculateNextFibonacciNumber>(new CalculateNextFibonacciNumber
            {
                Number = request.Number + 1
            });
        }
    }
}