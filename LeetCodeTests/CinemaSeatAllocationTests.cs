using FluentAssertions;
using LeetCode;

namespace LeetCodeTests
{
    [TestClass]
    public class CinemaSeatAllocationTests
    {
        [TestMethod]
        [DataRow(2)]
        public void RowsWithNoReservations_ReturnsRowsTimesTwo(int expected)
        {
            //Arrange
            var cinemaSeatAllocation = new CinemaSeatAllocation();
            //Act
            var seats = cinemaSeatAllocation.MaxNumberOfFamilies(1, Array.Empty<int[]>());
            //Assert
            seats.Should().Be(2);
        }

        [TestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void RowsWithReservations_ReturnsExpectedValue(int rows, int[][] reservedSeats, int expected)
        {
            var cinemaSeatAllocation = new CinemaSeatAllocation();
            //Act
            var seats = cinemaSeatAllocation.MaxNumberOfFamilies(rows, reservedSeats);
            //Assert
            seats.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetData()
        {
            var reservedSeats = new int[6][];
            reservedSeats[0] = new int[2] { 1, 2 };
            reservedSeats[1] = new int[2] { 1, 8 };
            reservedSeats[2] = new int[2] { 2, 6 };
            reservedSeats[3] = new int[2] { 3, 1 };
            reservedSeats[4] = new int[2] { 3, 10 };
            reservedSeats[5] = new int[2] { 4, 4 };
            yield return new object[] {4, reservedSeats, 5 };

            reservedSeats = new int[1][];
            reservedSeats[0] = new int[2] { 1, 2 };
            yield return new object[] {2, reservedSeats, 3 };

            reservedSeats = new int[1][];
            reservedSeats[0] = new int[2] { 1, 4 };
            yield return new object[] { 2, reservedSeats, 3 };

            reservedSeats = new int[1][];
            reservedSeats[0] = new int[2] { 1, 7 };
            yield return new object[] { 2, reservedSeats, 3 };

            reservedSeats = new int[1][];
            reservedSeats[0] = new int[2] { 1, 9 };
            yield return new object[] { 2, reservedSeats, 3 };
            //yield return new object[] { 12, 30, 42 };
            //yield return new object[] { 14, 1, 15 };
        }
    }
}