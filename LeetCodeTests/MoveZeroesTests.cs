using LeetCode;
using FluentAssertions;

namespace LeetCodeTests
{
    [TestClass]
    public class MoveZeroesTests
    {
        private readonly Easy _sut;
        public MoveZeroesTests()
        {
            _sut = new Easy();
        }

        [TestMethod]
        [DataRow(new int[] {1,0,1,1}, new int[] { 1, 1, 1, 0 })]
        [DataRow(new int[] { 1, 0, 1, 0, 1 }, new int[] { 1, 1, 1, 0, 0 })]
        [DataRow(new int[] { 0, 0, 1, 0, 1 }, new int[] { 1, 1, 0, 0, 0 })]
        [DataRow(new int[] { 0, 1 }, new int[] { 1, 0 })]
        public void ArrayWithZeroes_ReturnsArrayWithZeroesInTheEnd(int[] nums, int[] expected)
        {
            var result = _sut.MoveZeroes(nums);
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 5, 2, 1 }, new int[] { 1, 5, 2, 1 })]
        public void ArrayWithNoZeroes_ReturnsSameArray(int[] nums, int[] expected)
        {
            var result = _sut.MoveZeroes(nums);
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 0, 0 }, new int[] { 0, 0 })]
        [DataRow(new int[] { 0 }, new int[] { 0 })]
        [DataRow(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 })]
        public void ArrayWithAllZeroes_ReturnsSameArray(int[] nums, int[] expected)
        {
            var result = _sut.MoveZeroes(nums);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
