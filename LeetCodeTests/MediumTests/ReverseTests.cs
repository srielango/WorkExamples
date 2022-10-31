using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.MediumTests
{
    [TestClass]
    public class ReverseTests : BaseMediumTests
    {
        [TestMethod]
        //[DataRow(123, 321)]
        //[DataRow(-123, -321)]
        //[DataRow(120, 21)]
        //[DataRow(7463847412,3147483647)]
        [DataRow(-2147483648, -8463847412)]
        public void Integer_ReturnsReverseInt(int num, int expected)
        {
            var result = _sut.Reverse(num);
            result.Should().Be(expected);
        }
    }
}
