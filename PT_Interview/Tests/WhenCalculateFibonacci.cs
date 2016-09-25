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

        [TestCase(-1, ExpectedResult = 0)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 2)]
        [TestCase(2, ExpectedResult = 3)]
        [TestCase(3, ExpectedResult = 5)]
        [TestCase(4181, ExpectedResult = 6765)]
        [Test]
        public int ReturnFibonacciNumberByPreviousFibonacciNumber(int previousNumber)
        {
            return _fibonacciCalculator.GetNumberByPreviousNumber(previousNumber);
        }

        [TestCase(6)]
        [TestCase(54)]
        public void ThrowsForNonFibonaccyNumbers(int previousNumber)
        {
            Assert.Throws<ArgumentException>(() => _fibonacciCalculator.GetNumberByPreviousNumber(previousNumber));
        }
    }
}