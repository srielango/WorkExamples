using FluentAssertions;
using LeetCodeTests.HardTests;

namespace LeetCodeTests.Hard_Tests
{
    [TestClass]
    public class ReconstructItineraryTests : BaseHardTests
    {
        [TestMethod]
        public void ResultStartsWithJFK()
        {
            var expected = "JFK";

            var source = new List<IList<string>> 
            {
                new List<string>() { "MUC", "LHR" }, 
                new List < string >() { "JFK", "MUC" }, 
                new List < string >() { "SFO", "SJC" }, 
                new List < string >() { "LHR", "SFO" } 
            };

            var result = _sut.ReconstructItinerary(source);
            result[0].Should().Be(expected);
        }

        [TestMethod]
        public void FourTicketsResultInItineryWithFiveCities()
        {
            var expected = new List<string>
            { "JFK", "MUC", "LHR", "SFO", "SJC" };

            var source = new List<IList<string>>
            {
                new List < string >() { "MUC", "LHR" },
                new List < string >() { "JFK", "MUC" },
                new List < string >() { "SFO", "SJC" },
                new List < string >() { "LHR", "SFO" }
            };

            var result = _sut.ReconstructItinerary(source);
            result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }

        [TestMethod]
        public void ResultFollowsShortestLexicalOrderForDuplicate()
        {
            var expected = new List<string>
            { "JFK","ATL","JFK","SFO","ATL","SFO" };

            var source = new List<IList<string>>
            {
                new List < string >() { "JFK", "SFO" },
                new List < string >() { "JFK", "ATL" },
                new List < string >() { "SFO", "ATL" },
                new List < string >() { "ATL", "JFK" },
                new List < string >() { "ATL", "SFO" }
            };

            var result = _sut.ReconstructItinerary(source);
            result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }
    }
}
