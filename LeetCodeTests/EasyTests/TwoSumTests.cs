using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class TwoSumTests : BaseTests
    {
        [TestMethod]
        [DataRow(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new int[] { 5, 11 })]
        [DataRow(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [DataRow(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
        [DataRow(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
        public void IntArray_returnsIndicesOfSum(int[] nums, int target, int[] expected)
        {
            var result = _sut.TwoSum(nums, target);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
