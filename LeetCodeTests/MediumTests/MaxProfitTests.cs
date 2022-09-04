using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.MediumTests
{
    [TestClass]
    public class MaxProfitTests
    {
        private readonly Medium _sut;
        public MaxProfitTests()
        {
            _sut = new Medium();
        }

        [TestMethod]
        [DataRow(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [DataRow(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void PrizesArray_ReturnsMaxProfit(int[] num, int expected)
        {
            var result = _sut.MaxProfit(num);
            result.Should().Be(expected);
        }
    }
}
