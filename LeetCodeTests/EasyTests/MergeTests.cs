using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class MergeTests : BaseTests
    {
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 })]
        public void TwoIntArrays_MergeToFirstArray(int[] nums1, int m, int[] nums2, int n, int[] expected)
        {
            var result = _sut.Merge(nums1, m, nums2, n);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
