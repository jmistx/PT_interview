using System;
using System.Threading.Tasks;
using CommonContract;
using Domain;
using log4net;
using MassTransit;

namespace RestClient
{
    public class FibonacciConsumer : IConsumer<CalculateNextFibonacciNumber>
    {
        private readonly IFibonacciServiceClient _client;
        private readonly IFibonacciCalculator _fibonacci;
        private readonly ILog _log;

        public FibonacciConsumer(IFibonacciServiceClient client, IFibonacciCalculator fibonacci, ILog log)
        {
            _client = client;
            _fibonacci = fibonacci;
            _log = log;
        }

        public async Task Consume(ConsumeContext<CalculateNextFibonacciNumber> context)
        {
            UInt64 recievedNumber = context.Message.Number;
            _log.Info($"Received: {context.Message.Number}");

            try
            {
                UInt64 nextFibonacciNumber = _fibonacci.GetNumberByPreviousNumber(recievedNumber);
                _client.RequestNextNumber(nextFibonacciNumber);
                _log.Info($"Sent: {nextFibonacciNumber}");
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
            }
        }
    }
}