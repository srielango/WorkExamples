using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.MediumTests
{
    [TestClass]
    public class CountPrimesTests : BaseMediumTests
    {
        [TestMethod]
        [DataRow(10, 4)]
        //[DataRow(0, 0)]
        //[DataRow(1, 0)]
        //[DataRow(499979, 123)]
        [DataRow(5000000, 348513)]
        public void N_ReturnsAllPrimesLessThanN(int num, int expected)
        {
            var result = _sut.CountPrimes(num);
            result.Should().Be(expected);
        }
    }
}
