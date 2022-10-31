using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class IsPalindromeSentenceTests : BaseTests
    {
        [TestMethod]
        [DataRow("A man, a plan, a canal: Panama", true)]
        [DataRow("race a car", false)]
        [DataRow(" ", true)]
        public void string_returnsResult(string s, bool expected)
        {
            var result = _sut.IsPalindrome(s);
            result.Should().Be(expected);
        }
    }
}
