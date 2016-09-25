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
        private readonly IBusControl _busControl;

        public FibonacciController(IBusControl busControl)
        {
            _busControl = busControl;
        }

        [HttpPost]
        public void Post(FibonacciNumberRequest request)
        {
            _busControl.Publish(new CalculateNextFibonacciNumber
            {
                Number = request.Number + 1
            });
        }
    }
}