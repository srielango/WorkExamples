using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class PlusOneTests : BaseTests
    {
        [TestMethod]
        [DataRow(new int[] { 9 }, new int[] { 1, 0 })]
        [DataRow(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 })]
        [DataRow(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 2 })]
        [DataRow(new int[] { 1,2,3 }, new int[] {1,2,4 })]
        public void IntArray_returnsPlusOne(int[] nums, int[] expected)
        {
            var result = _sut.PlusOne(nums);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
