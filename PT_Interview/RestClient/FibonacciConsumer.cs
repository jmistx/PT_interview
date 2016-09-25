using System;
using System.Threading.Tasks;
using CommonContract;
using MassTransit;

namespace RestClient
{
    public class FibonacciConsumer : IConsumer<CalculateNextFibonacciNumber>
    {
        private readonly IFibonacciServiceClient _client;

        public FibonacciConsumer(IFibonacciServiceClient client)
        {
            _client = client;
        }

        public async Task Consume(ConsumeContext<CalculateNextFibonacciNumber> context)
        {
            await Console.Out.WriteLineAsync($"Received: {context.Message.Number}");
            _client.RequestNumber(context.Message.Number + 1);
        }
    }
}