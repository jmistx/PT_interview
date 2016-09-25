using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using CommonContract;
using Domain;
using MassTransit;

namespace RestService.Controllers
{
    public class FibonacciController : ApiController
    {
        private readonly IBusControl _busControl;
        private readonly IFibonacciCalculator _fibonacci;

        public FibonacciController(IBusControl busControl, IFibonacciCalculator fibonacci)
        {
            _busControl = busControl;
            _fibonacci = fibonacci;
        }

        [HttpPost]
        public void Post(FibonacciNumberRequest request)
        {
            try
            {
                UInt64 nextNumber = _fibonacci.GetNumberByPreviousNumber(request.Number);
                _busControl.Publish(new CalculateNextFibonacciNumber
                {
                    Number = nextNumber
                });
            }
            catch (ArgumentException ex)
            {
                //log argument exception
            }
            catch (OverflowException ex)
            {
                //log overflow exception
            }
        }
    }
}