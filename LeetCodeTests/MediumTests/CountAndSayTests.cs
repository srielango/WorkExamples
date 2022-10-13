using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.MediumTests
{
    [TestClass]
    public class CountAndSayTests
    {
        private readonly Medium _sut;
        public CountAndSayTests()
        {
            _sut = new Medium();
        }

        [TestMethod]
        [DataRow(4, "1211")]
        [DataRow(1, "1")]
        public void CountAndSay_ReturnsResult(int num, string expected)
        {
            var result = _sut.CountAndSay(num);
            result.Should().Be(expected);
        }
    }
}
