using System;

namespace Domain
{
    public class FibonacciCalculator
    {
        public int GetNumberByPreviousNumber(int previousNumber)
        {
            if (previousNumber <= 0)
            {
                return 0;
            }

            int prev = 1;
            int current = 1;
            int next = 2;
            while (current < previousNumber)
            {
                prev = current;
                current = next;
                next = prev + current;
            }

            if (current == previousNumber)
            {
                return next;
            }

            throw new ArgumentException();
        }
    }
}