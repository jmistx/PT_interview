using System;

namespace RestClient
{
    public interface IFibonacciServiceClient
    {
        void RequestNextNumber(UInt64 number);
    }
}