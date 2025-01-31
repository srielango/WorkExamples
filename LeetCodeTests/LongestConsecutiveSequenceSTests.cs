using FluentAssertions;
using LeetCode;

namespace LeetCodeTests
{
    [TestClass]
    public class LongestConsecutiveSequenceSTests
    {
        [TestMethod]
        //[DataRow(new int[] { 100, 4, 200, 1, 3, 2 }, 4)]
        [DataRow(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
        public void Array_Returns_Length(int[] nums, int expected)
        {
            var _sut = new LongestConsecutiveSequence();
            var actual = _sut.LCS(nums);
            actual.Should().Be(expected);
        }
    }
}
