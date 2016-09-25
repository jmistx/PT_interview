using System;
using System.Threading.Tasks;
using CommonContract;
using Domain;
using MassTransit;

namespace RestClient
{
    public class FibonacciConsumer : IConsumer<CalculateNextFibonacciNumber>
    {
        private readonly IFibonacciServiceClient _client;
        private readonly IFibonacciCalculator _fibonacci;

        public FibonacciConsumer(IFibonacciServiceClient client, IFibonacciCalculator fibonacci)
        {
            _client = client;
            _fibonacci = fibonacci;
        }

        public async Task Consume(ConsumeContext<CalculateNextFibonacciNumber> context)
        {
            UInt64 recievedNumber = context.Message.Number;
            await Console.Out.WriteLineAsync($"Received: {context.Message.Number}");

            try
            {
                UInt64 nextFibonacciNumber = _fibonacci.GetNumberByPreviousNumber(recievedNumber);
                _client.RequestNumber(nextFibonacciNumber);
            }
            catch (ArgumentException ex)
            {
                await Console.Out.WriteLineAsync($"Argument exception: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                await Console.Out.WriteLineAsync($"Overflow exception: {ex.Message}");
            }
        }
    }
}