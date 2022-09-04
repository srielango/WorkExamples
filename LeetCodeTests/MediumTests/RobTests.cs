using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.MediumTests
{
    [TestClass]
    public class RobTests
    {
        private readonly Medium _sut;
        public RobTests()
        {
            _sut = new Medium();
        }

        [TestMethod]
        [DataRow(new int[] { 2, 1, 1, 2 }, 4)]
        [DataRow(new int[] { 1, 2, 3, 1 }, 4)]
        [DataRow(new int[] { 2, 7, 9, 3, 1 }, 12)]
        public void RobArray_ReturnsMaxGain(int[] num, int expected)
        {
            var result = _sut.Rob(num);
            result.Should().Be(expected);
        }
    }
}
