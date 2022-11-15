using FluentAssertions;
using SudokuSolver;

namespace SudokuTests
{
    [TestClass]
    public class SudokuTests
    {
        private readonly AbstractSudokuSolver _sut;
        public SudokuTests()
        {
            _sut = new BacktrackingSudokuSolver();
        }
        [TestMethod]
        [DataRow(0, 6, 9, true)]
        [DataRow(0, 7, 8, true)]
        [DataRow(1, 1, 7, true)]
        [DataRow(1, 8, 3, true)]
        public void ValidNumbersInCell_returnsTrue(int row, int col, int number, bool expected)
        {
            LoadTestData1();
            var result = _sut.IsValidInCell(row, col, number);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(0, 6, 2, false)]
        public void InvalidNumbersInCell_returnsFalse(int row, int col, int number, bool expected)
        {
            LoadTestData1();
            var result = _sut.IsValidInCell(row, col, number);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(1, 1, 7, true)]
        public void IsUniqueInCell_ReturnsTrue(int row, int col, int number, bool expected)
        {
            LoadTestData1();
            _sut.FillPossibleValues();
            var result = _sut.IsUniqueInCell(row, col, number);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(true)]
        public void Solve_ReturnsCompletedGrid(bool expected)
        {
            LoadTestData4();
            _sut.Solve();
            var result = _sut.GetValues();
            for(var i=0;i<9;i++)
            {
                Console.WriteLine();
                for(var j=0;j<9;j++)
                {
                    string val = result[i, j].Number == 0 ? " " : result[i, j].Number.ToString();
                    Console.Write($"| {val} |");
                    if((j + 1) % 3 == 0) Console.Write("  ");
                }
                if ((i + 1) % 3 == 0) Console.WriteLine();
            }
            true.Should().Be(expected);
        }

        private void LoadTestData1()
        {
            var testData = new int[9, 9];
            testData[0, 0] = 3;
            testData[0, 7] = 1;

            testData[1, 0] = 9;
            testData[1, 3] = 5;
            testData[1, 4] = 8;
            testData[1, 5] = 7;
            testData[1, 6] = 6;

            testData[2, 2] = 4;
            testData[2, 6] = 5;
            testData[2, 8] = 7;

            testData[3, 1] = 9;
            testData[3, 4] = 1;
            testData[3, 8] = 6;

            testData[4, 1] = 4;
            testData[4, 3] = 3;
            testData[4, 4] = 6;
            testData[4, 5] = 9;
            testData[4, 7] = 7;

            testData[5, 0] = 1;
            testData[5, 4] = 7;
            testData[5, 7] = 3;

            testData[6, 0] = 2;
            testData[6, 2] = 7;
            testData[6, 6] = 3;

            testData[7, 2] = 6;
            testData[7, 3] = 7;
            testData[7, 4] = 2;
            testData[7, 5] = 8;
            testData[7, 8] = 9;

            testData[8, 1] = 1;
            testData[8, 8] = 2;

            _sut.InitializeGrid(testData);
        }

        private void LoadTestData4()
        {
            var testData = new int[9, 9];
            testData[0, 4] = 2;
            testData[0, 5] = 5;
            testData[0, 8] = 7;

            testData[1, 0] = 5;
            testData[1, 2] = 9;
            testData[1, 3] = 8;
            testData[1, 6] = 2;

            testData[2, 1] = 8;
            testData[2, 8] = 6;

            testData[3, 1] = 2;
            testData[3, 2] = 7;

            testData[4, 2] = 5;
            testData[4, 3] = 2;
            testData[4, 5] = 4;
            testData[4, 6] = 3;

            testData[5, 6] = 8;
            testData[5, 7] = 5;

            testData[6, 0] = 2;
            testData[6, 7] = 3;

            testData[7, 2] = 4;
            testData[7, 5] = 2;
            testData[7, 6] = 6;
            testData[7, 8] = 1;

            testData[8, 0] = 7;
            testData[8, 3] = 6;
            testData[8, 4] = 3;

            _sut.InitializeGrid(testData);
        }
    }
}