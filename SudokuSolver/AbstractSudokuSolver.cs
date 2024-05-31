namespace SudokuSolver
{
    public abstract class AbstractSudokuSolver
    {
        protected Cell[,] sudokuGrid = new Cell[9, 9];
        public abstract void Solve();
        public void InitializeGrid(int[,] grid)
        {
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    sudokuGrid[i, j] = Cell.GetInitialValue(grid[i, j]);
                }
            }
        }

        public bool IsValidInCell(int row, int col, int number)
        {
            for (var i = 0; i < 9; i++)
            {
                if (sudokuGrid[i, col].Number == number)
                    return false;
            }

            for (var i = 0; i < 9; i++)
            {
                if (sudokuGrid[row, i].Number == number)
                    return false;
            }

            var rowStart = GetRowBeginning(row);

            var colStart = GetColBeginning(col);

            for (var i = rowStart; i < rowStart + 3; i++)
            {
                for (var j = colStart; j < colStart + 3; j++)
                {
                    if (sudokuGrid[i, j].Number == number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected int GetColBeginning(int col)
        {
            var colStart = 0;
            switch (col)
            {
                case int n when (n >= 3 && n <= 5):
                    colStart = 3;
                    break;
                case int n when (n >= 6 && n <= 8):
                    colStart = 6;
                    break;
            }

            return colStart;
        }
        protected int GetRowBeginning(int row)
        {
            var rowStart = 0;
            switch (row)
            {
                case int n when (n >= 3 && n <= 5):
                    rowStart = 3;
                    break;
                case int n when (n >= 6 && n <= 8):
                    rowStart = 6;
                    break;
            }

            return rowStart;
        }
        public void FillPossibleValues()
        {
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (sudokuGrid[i, j].Number != 0)
                    {
                        continue;
                    }
                    sudokuGrid[i, j].PossibleValues.Clear();
                    for (var num = 1; num < 10; num++)
                    {
                        if (IsValidInCell(i, j, num))
                        {
                            sudokuGrid[i, j].PossibleValues.Add(num);
                        }
                    }
                }
            }
        }
        public void AddToCell(int row, int col, int number)
        {
            if (IsValidInCell(row, col, number))
            {
                sudokuGrid[row, col].Number = number;
                FillPossibleValues();
            }
        }

        public Cell[,] GetCells()
        {
            return sudokuGrid;
        }

        public int[,] GetValues()
        {
            int[,] result = new int[9, 9];
            foreach(var  cell in sudokuGrid)
            {
                result[cell.Row, cell.Column] = cell.Number;
            }
            return result;
        }
        public bool IsUniqueInCell(int row, int col, int number)
        {
            return IsUniqueInSquare(row, col, number) || IsUniqueInRow(row, number, col) || IsUniqueInCol(col, number, row);
        }

        private bool IsUniqueInRow(int row, int number, int selectedCol)
        {
            for (var i = 0; i < 9; i++)
            {
                if (i == selectedCol)
                {
                    continue;
                }
                if (sudokuGrid[row, i].PossibleValues.Contains(number) || sudokuGrid[row, i].Number == number)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsUniqueInCol(int col, int number, int selectedRow)
        {
            for (var i = 0; i < 9; i++)
            {
                if (i == selectedRow)
                {
                    continue;
                }
                if (sudokuGrid[i, col].PossibleValues.Contains(number) || sudokuGrid[i, col].Number == number)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsUniqueInSquare(int row, int col, int number)
        {
            var rowStart = GetRowBeginning(row);
            var colStart = GetColBeginning(col);

            for (var i = rowStart; i < rowStart + 3; i++)
            {
                for (var j = colStart; j < colStart + 3; j++)
                {
                    if (sudokuGrid[i, j].PossibleValues.Contains(number) || sudokuGrid[i, j].Number == number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
