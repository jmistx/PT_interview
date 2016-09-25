using System;
using System.Threading.Tasks;
using CommonContract;
using MassTransit;

namespace RestClient
{
    public class FibonacciConsumer : IConsumer<CalculateNextFibonacciNumber>
    {
        public async Task Consume(ConsumeContext<CalculateNextFibonacciNumber> context)
        {
            await Console.Out.WriteLineAsync($"Received: {context.Message.Number}");
            Program.RequestNumber(context.Message.Number + 1);
        }
    }
}