using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class ClimbStairsTests : BaseTests
    {
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 3)]
        [DataRow(4, 5)]
        [DataRow(7, 21)]
        public void Numbers_ReturnsFibonacci(int n, int expected)
        {
            var result = _sut.ClimbStairs(n);
            result.Should().Be(expected);
        }
    }
}
