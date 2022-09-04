using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class FizzBuzzTests : BaseTests
    {
        [TestMethod]
        [DataRow(3, "Fizz")]
        [DataRow(6, "Fizz")]
        [DataRow(9, "Fizz")]
        [DataRow(12, "Fizz")]
        public void DivisibleBy3_ReturnsFizz(int num, string expected)
        {
            var result = _sut.FizzBuzz(num);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(0, "0")]
        [DataRow(1, "1")]
        [DataRow(2, "2")]
        [DataRow(4, "4")]
        public void NonDivisibleBy3_ReturnsNumber(int num, string expected)
        {
            var result = _sut.FizzBuzz(num);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(5, "Buzz")]
        [DataRow(10, "Buzz")]
        [DataRow(20, "Buzz")]
        public void DivisibleBy5_ReturnsBuzz(int num, string expected)
        {
            var result = _sut.FizzBuzz(num);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(15, "FizzBuzz")]
        [DataRow(30, "FizzBuzz")]
        [DataRow(45, "FizzBuzz")]
        public void NonDivisibleBy3And5_ReturnsFizzBuzz(int num, string expected)
        {
            var result = _sut.FizzBuzz(num);
            result.Should().Be(expected);
        }
    }
}
