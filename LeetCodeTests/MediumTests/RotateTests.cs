using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.MediumTests
{
    [TestClass]
    public class RotateTests
    {
        private readonly Medium _sut;
        public RotateTests()
        {
            _sut = new Medium();
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 } )]
        [DataRow(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
        public void Rotate_ReturnsResult(int[] nums, int k, int[] expected)
        {
            _sut.Rotate(nums, k);
            nums.Should().BeEquivalentTo(expected);
        }
    }
}
