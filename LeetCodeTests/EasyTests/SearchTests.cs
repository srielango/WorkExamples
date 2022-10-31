using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class SearchTests : BaseTests
    {
        [TestMethod]
        [DataRow(new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4)]
        [DataRow(new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
        public void Search_ReturnsIndex(int[] nums, int target, int expected)
        {
            var result = _sut.Search(nums, target);
            result.Should().Be(expected);
        }
    }
}
