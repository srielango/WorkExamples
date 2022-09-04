using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class IsAnagramTests : BaseTests
    {
        [TestMethod]
        [DataRow("anagram", "nagaram", true)]
        [DataRow("vikram", "ramvik", true)]
        public void Anagram_ReturnsTrue(string s, string t, bool expected)
        {
            var result = _sut.IsAnagram(s, t);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("car", "rat", false)]
        [DataRow("vikram", "ramvika", false)]
        public void NonAnagram_ReturnsFalse(string s, string t, bool expected)
        {
            var result = _sut.IsAnagram(s, t);
            result.Should().Be(expected);
        }
    }
}
