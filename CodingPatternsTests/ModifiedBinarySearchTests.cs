using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class ModifiedBinarySearchTests
    {
        private readonly ModifiedBinarySearch _sut = new ModifiedBinarySearch();

        [TestMethod]
        [DataRow(new int[] {3, 4, 5, 1, 2}, 1)]
        [DataRow(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
        public void int_array_returns_min_value(int[] arr, int expected)
        {
            var result = _sut.FindMinElement(arr);
            result.Should().Be(expected);
        }
    }
}
