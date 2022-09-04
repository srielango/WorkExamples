using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class FirstUniqueCharTests : BaseTests
    {
        [TestMethod]
        [DataRow("test",1)]
        [DataRow("LeetCode",0)]
        [DataRow("uniqueness", 2)]
        public void UniqueChars_ReturnsCharIndex(string s, int expected)
        {
            var result = _sut.FirstUniqChar(s);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("testes", -1)]
        [DataRow("LeetCodeLtoCd", -1)]
        [DataRow("uniquenessiqn", -1)]
        public void NonUniqueChars_ReturnsMinusOne(string s, int expected)
        {
            var result = _sut.FirstUniqChar(s);
            result.Should().Be(expected);
        }
    }
}
