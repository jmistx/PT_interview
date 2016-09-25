using System;

namespace Domain
{
    public interface IFibonacciCalculator
    {
        UInt64 GetNumberByPreviousNumber(UInt64 previousNumber);
    }
}