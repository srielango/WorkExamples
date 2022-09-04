using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class MissingNumberTests : BaseTests
    {
        [TestMethod]
        [DataRow(new int[] {3, 0, 1}, 2)]
        [DataRow(new int[] { 0, 1 }, 2)]
        [DataRow(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
        public void IntArray_ReturnsMissingNumber(int[] nums, int expected)
        {
            var result = _sut.MissingNumber(nums);
            result.Should().Be(expected);
        }
    }
}
