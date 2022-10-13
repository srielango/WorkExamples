using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.MediumTests
{
    [TestClass]
    public class TrailingZeroesTests : BaseMediumTests
    {
        [TestMethod]
        [DataRow(19, 3)]
        [DataRow(5, 1)]
        [DataRow(3, 0)]
        [DataRow(0, 0)]
        public void Factorial_ReturnsTrailingZeroes(int num, int expected)
        {
            var result = _sut.TrailingZeroes(num);
            result.Should().Be(expected);
        }
    }
}
