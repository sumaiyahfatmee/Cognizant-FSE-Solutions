using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator = null!;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null!;
        }

        [TestCase(10, 20, 30)]
        [TestCase(5, 7, 12)]
        [TestCase(-10, 15, 5)]
        [TestCase(0, 0, 0)]
        public void Add_ValidInputs_ReturnsExpectedResult(int a, int b, int expected)
        {
            // Act
            int result = _calculator.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}