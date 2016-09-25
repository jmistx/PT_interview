using System;
using System.Web.Http;
using CommonContract;
using Domain;
using log4net;
using MassTransit;

namespace RestService.Controllers
{
    public class FibonacciController : ApiController
    {
        private readonly IBusControl _busControl;
        private readonly IFibonacciCalculator _fibonacci;
        private readonly ILog _log;

        public FibonacciController(IBusControl busControl, IFibonacciCalculator fibonacci, ILog log)
        {
            _busControl = busControl;
            _fibonacci = fibonacci;
            _log = log;
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
            catch (Exception ex)
            {
                _log.Debug(ex);
            }
        }
    }
}