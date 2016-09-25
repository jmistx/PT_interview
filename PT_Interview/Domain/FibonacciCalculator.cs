using System;

namespace Domain
{
    public class FibonacciCalculator : IFibonacciCalculator
    {
        public UInt64 GetNumberByPreviousNumber(UInt64 previousNumber)
        {
            if (previousNumber <= 0)
            {
                throw new ArgumentException("negative or zero argument");
            }

            UInt64 prev = 1;
            UInt64 current = 1;
            UInt64 next = 2;
            while (current < previousNumber)
            {
                prev = current;
                current = next;
                next = checked(prev + current);
            }

            if (current == previousNumber)
            {
                return next;
            }

            throw new ArgumentException($"{previousNumber} not a fibonacci number");
        }
    }
}