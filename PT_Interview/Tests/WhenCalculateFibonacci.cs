using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WhenCalculateFibonacci
    {
        [SetUp]
        public void SetUp()
        {
            _fibonacciCalculator = new FibonacciCalculator();
        }

        private FibonacciCalculator _fibonacciCalculator;

        [TestCase(1, ExpectedResult = 2)]
        [TestCase(2, ExpectedResult = 3)]
        [TestCase(3, ExpectedResult = 5)]
        [Test]
        public UInt64 ReturnFibonacciNumberByPreviousFibonacciNumber(int previousNumber)
        {
            return _fibonacciCalculator.GetNumberByPreviousNumber((UInt64)previousNumber);
        }

        [TestCase(0)]
        [TestCase(6)]
        [TestCase(54)]
        public void ThrowsForNonFibonaccyNumbers(int previousNumber)
        {
            Assert.Throws<ArgumentException>(() => _fibonacciCalculator.GetNumberByPreviousNumber((UInt64)previousNumber));
        }

        [Test]
        public void ThrowsOverflowExceptionForBigNumbers()
        {
            Assert.Throws<OverflowException>(() => _fibonacciCalculator.GetNumberByPreviousNumber(12200160415121876738));
        }
    }
}