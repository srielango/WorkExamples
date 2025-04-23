using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass()]
    public class PascalsTriangleTests : BaseTests
    {

        [TestMethod()]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 3)]
        [DataRow(4, 4)]
        public void Output_ReturnsRowsMatchingInput(int numRows, int expected)
        {
            var result = _sut.GeneratePascalsTriangle(numRows);
            result.Count.Should().Be(expected);
        }

        [TestMethod()]
        [DataRow(5, new int[] { 1, 4, 6, 4, 1 })]
        public void LastRow_ReturnsCorrectRow(int numRows, int[] expected)
        {
            var result = _sut.GeneratePascalsTriangle(numRows);
            result.Last().Should().BeEquivalentTo(expected.ToList());
        }
    }
}