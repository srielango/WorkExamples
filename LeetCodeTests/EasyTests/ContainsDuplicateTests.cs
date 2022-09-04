using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class ContainsDuplicateTests : BaseTests
    {
        [TestMethod]
        [DataRow(new int[] {1, 2, 3, 1}, true)]
        [DataRow(new int[] { 1, 2, 3, 4,1, 2, 1}, true)]
        public void DuplicateNums_ReturnsTrue(int[] nums, bool expected)
        {
            var result = _sut.ContainsDuplicate(nums);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, false)]
        [DataRow(new int[] { 1, 2, 3, 4 }, false)]
        public void UniqueNums_ReturnsFalse(int[] nums, bool expected)
        {
            var result = _sut.ContainsDuplicate(nums);
            result.Should().Be(expected);
        }
    }
}
