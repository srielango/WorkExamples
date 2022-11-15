using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class SmallestPositiveIntTests : BaseTests
    {
        [TestMethod]
        [DataRow(new int[] { -1, -2, 10, 5 }, 1)]
        [DataRow(new int[] { 4, 3, 6, 1, 1, 5, 8 }, 2)]
        [DataRow(new int[] { 1000, -1 }, 1)]
        public void IntArray_returnsSmallestPositiveInt(int[] nums, int expected)
        {
            var result = _sut.SmallestPositiveInt(nums);
            result.Should().Be(expected);
        }
    }
}
