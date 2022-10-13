using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class RemoveDuplicatesTests : BaseTests
    {
        [TestMethod]
        [DataRow(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
        [DataRow(new int[] { 1, 1, 2 }, 2)]
        public void IntArray_returnsArrayLengthWithoutDuplicates(int[] nums, int expected)
        {
            var result = _sut.RemoveDuplicates(nums);
            result.Should().Be(expected);
        }
    }
}
