using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.MediumTests
{
    [TestClass]
    public class StrStrTests
    {
        private readonly Medium _sut;
        public StrStrTests()
        {
            _sut = new Medium();
        }

        [TestMethod]
        //[DataRow("sadbutsad", "sad", 0)]
        //[DataRow("leetcode", "leeto", -1)]
        //[DataRow("a", "a", 0)]
        [DataRow("abc", "c", 2)]
        public void StrStrTests_ReturnsResult(string haystack, string needle, int expected)
        {
            var result = _sut.StrStr(haystack, needle);
            result.Should().Be(expected);
        }
    }
}
