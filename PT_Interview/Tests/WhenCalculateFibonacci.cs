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

        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 2)]
        [TestCase(15, ExpectedResult = 610)]
        public int ReturnFibonacciNumberBySerialNumber(int serialNumber)
        {
            return _fibonacciCalculator.GetNumberBySerialNumber(serialNumber);
        }
    }
}