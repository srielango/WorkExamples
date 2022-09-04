using FluentAssertions;
using System.Text.Json;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class GeneratePascalTriangleTests : BaseTests
    {
        [TestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void GeneratePascalTriangleTests_ReturnsTrue(int num, string expected)
        {
            var result = _sut.GeneratePascalTriangle(num);
            var resultJson = JsonSerializer.Serialize(result);
            resultJson.Should().Be(expected);
        }

        private static IEnumerable<object[]> GetData()
        {
            //var num = 1;
            //var expected = "[[1]]";
            //yield return new object[] { num, expected };

            var num = 5;
            var expected = "[[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]";
            yield return new object[] { num, expected };
        }
    }
}
