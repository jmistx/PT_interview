using System;

namespace RestClient
{
    public interface IFibonacciServiceClient
    {
        void RequestNumber(UInt64 number);
    }
}