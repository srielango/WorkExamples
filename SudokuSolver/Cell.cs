using System.Collections.Generic;

namespace SudokuSolver
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Number { get; set; }
        public List<int> PossibleValues { get; set; } = new List<int>();
        public bool IsInitialValue { get; set; }

        public static Cell GetInitialValue(int number)
        {
            return new Cell() { IsInitialValue = true, Number = number };
        }
    }
}
