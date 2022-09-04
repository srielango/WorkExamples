using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.MediumTests
{
    [TestClass]
    public class MaxSubArrayTests
    {
        private readonly Medium _sut;
        public MaxSubArrayTests()
        {
            _sut = new Medium();
        }

        [TestMethod]
        [DataRow(new int[] { 5 }, 5)]
        [DataRow(new int[] { 1 }, 1)]
        [DataRow(new int[] { -1 }, -1)]
        public void SingleDigit_ReturnsSameNumer(int[] nums, int expected)
        {
            var result = _sut.MaxSubArray(nums);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        [DataRow(new int[] { 5, 4, -1, 7, 8 }, 23)]
        public void ArrayWithNegativeValues_ReturnsMaxSubArray(int[] nums, int expected)
        {
            var result = _sut.MaxSubArray(nums);
            result.Should().Be(expected);
        }
    }
}
