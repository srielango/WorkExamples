using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class MaxProfit2Tests : BaseTests
    {
        [TestMethod]
        [DataRow(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [DataRow(new int[] { 7, 6, 4, 3, 1 }, 0)]
        [DataRow(new int[] { 2, 9, 1, 5 }, 7)]
        public void Array_returnsMaxProfit(int[] nums, int expected)
        {
            var result = _sut.MaxProfit2(nums);
            result.Should().Be(expected);
        }
    }
}
