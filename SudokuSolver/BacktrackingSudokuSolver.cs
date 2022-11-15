using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    public class BacktrackingSudokuSolver : AbstractSudokuSolver
    {
        List<Cell> EmptyCells = new List<Cell>();
        int emptyCellIndex = 0;
        public override void Solve()
        {

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (sudokuGrid[i, j].Number == 0)
                    {
                        EmptyCells.Add(new Cell() { Row = i, Column = j });
                    }
                }
            }

            //FillPossibleValues();

            Backtrack(emptyCellIndex);
        }

        private bool Backtrack(int emptyCellIndex)
        {
            if(emptyCellIndex >= EmptyCells.Count)
            {
                return true;
            }
            var emptyCell = EmptyCells[emptyCellIndex];

            foreach(var possibleValue in Enumerable.Range(1,9))
            {
                if (IsValidInCell(emptyCell.Row, emptyCell.Column, possibleValue))
                {
                    AddToCell(emptyCell.Row, emptyCell.Column, possibleValue);
                    emptyCellIndex++;
                    if (Backtrack(emptyCellIndex)) return true;
                    else
                    {
                        emptyCellIndex--;
                        sudokuGrid[emptyCell.Row, emptyCell.Column].Number = 0;
                        //FillPossibleValues();
                    }
                }
            }
            return false;
        }
    }
}
