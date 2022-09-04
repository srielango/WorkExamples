using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class IntersectionOfTwoArraysTests : BaseTests
    {
        [TestMethod]
        [DataRow(new int[] { 1, 2, 2, 1 }, new int[] {2, 2}, new int[] {2,2})]
        [DataRow(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }, new int[] { 4, 9 })]
        public void TwoArrays_ReturnsCommonNumbers(int[] num1, int[] num2, int[] expected)
        {
            var result = _sut.IntersectionOfTwoArrays(num1, num2);
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 2, 1 }, new int[] { 2 }, new int[] { 2 })]
        public void FirstArrayHasRepeatedNumber_ReturnsRepeatedNumberOnce(int[] num1, int[] num2, int[] expected)
        {
            var result = _sut.IntersectionOfTwoArrays(num1, num2);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
