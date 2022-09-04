using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class HammingWeightTests : BaseTests
    {

        [TestMethod]
        [DataRow(00000000000000000000000000001011, 3)]
        public void Integer_ReturnsHammingWeight(uint num, int expected)
        {
            var result = _sut.HammingWeight(num);
            result.Should().Be(expected);
        }

    }
}
