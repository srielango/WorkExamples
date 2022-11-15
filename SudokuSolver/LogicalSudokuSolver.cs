using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    public class LogicalSudokuSolver : AbstractSudokuSolver
    {

        public override void Solve()
        {
            bool addedToCell;
            do
            {
                addedToCell = false;
                FillPossibleValues();
                for (var i = 0; i < 9; i++)
                {
                    for (var j = 0; j < 9; j++)
                    {
                        if (sudokuGrid[i, j].Number != 0)
                        {
                            continue;
                        }

                        if (sudokuGrid[i, j].PossibleValues.Count == 1)
                        {
                            AddToCell(i, j, sudokuGrid[i, j].PossibleValues[0]);
                        }

                        for (var num = 1; num < 10; num++)
                        {
                            if (IsUniqueInCell(i, j, num))
                            {
                                AddToCell(i, j, num);
                                addedToCell = true;
                            }
                        }
                        
                    }
                    //SolveSiblingsInRow(i);
                    //SolveSiblingsInColumn(i);

                }
                SolveSiblingsInSquare(0, 0);
                SolveSiblingsInSquare(0, 3);
                SolveSiblingsInSquare(0, 6);
                SolveSiblingsInSquare(3, 0);
                SolveSiblingsInSquare(3, 3);
                SolveSiblingsInSquare(3, 6);
                SolveSiblingsInSquare(6, 0);
                SolveSiblingsInSquare(6, 3);
                SolveSiblingsInSquare(6, 6);

            } while (addedToCell);
        }

        private void SolveSiblingsInRow(int row)
        {
            var siblingPossibilities = new List<Cell>();

            for (int i = 0; i < 9; i++)
            {
                if (sudokuGrid[row,i].Number == 0)
                {
                    sudokuGrid[row, i].Row = row;
                    sudokuGrid[row, i].Column = i;
                    sudokuGrid[row, i].PossibleValues.Sort();
                    siblingPossibilities.Add(sudokuGrid[row, i]);

                }
            }
            SolveSiblings(siblingPossibilities);
        }

        private void SolveSiblingsInColumn(int col)
        {
            var siblingPossibilities = new List<Cell>();
            for (int i = 0; i < 9; i++)
            {
                if (sudokuGrid[i, col].Number == 0)
                {
                    sudokuGrid[i, col].Row = i;
                    sudokuGrid[i, col].Column = col;
                    sudokuGrid[i, col].PossibleValues.Sort();
                    siblingPossibilities.Add(sudokuGrid[i, col]);

                }
            }
            
            SolveSiblings(siblingPossibilities);

            //var rowList = new List<int>();
            //for (int i = 0; i < 9; i++)
            //{
            //    if (sudokuGrid[i, col].Number == 0)
            //    {
            //        sudokuGrid[i, col].PossibleValues.Sort();
            //        rowList.Add(i);
            //    }
            //}

            //for (var i = 0; i < rowList.Count - 1; i++)
            //{
            //    var siblingsCount = sudokuGrid[rowList[i], col].PossibleValues.Count;
            //    var matches = new List<int>();
            //    matches.Add(rowList[i]);
            //    for (var j = i + 1; j < rowList.Count; j++)
            //    {
            //        if (sudokuGrid[rowList[i], col].PossibleValues.SequenceEqual<int>(sudokuGrid[rowList[j],col].PossibleValues))
            //        {
            //            matches.Add(rowList[j]);
            //        }
            //    }
            //    if (matches.Count == siblingsCount)
            //    {
            //        var possibleValuesToRemove = sudokuGrid[rowList[i], col].PossibleValues;
            //        foreach (var row in rowList)
            //        {
            //            if (!matches.Contains(row))
            //            {
            //                foreach (var item in possibleValuesToRemove)
            //                {
            //                    sudokuGrid[row, col].PossibleValues.Remove(item);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void SolveSiblingsInSquare(int rowStart, int colStart)
        {
            var siblingPossibilities = new List<Cell>();

            for (var i = rowStart; i < rowStart + 3; i++)
            {
                for (var j = colStart; j < colStart + 3; j++)
                {
                    if (sudokuGrid[i, j].Number == 0)
                    {
                        sudokuGrid[i, j].Row = i;
                        sudokuGrid[i, j].Column = j;
                        sudokuGrid[i, j].PossibleValues.Sort();
                        siblingPossibilities.Add(sudokuGrid[i, j]);
                    }
                }
            }

            SolveSiblings(siblingPossibilities);
        }

        private void SolveSiblings(List<Cell> siblingPossibilities)
        {
            for (var i = 0; i < siblingPossibilities.Count - 1; i++)
            {
                var siblingsCount = siblingPossibilities[i].PossibleValues.Count;
                var matches = new List<Cell>();
                matches.Add(siblingPossibilities[i]);

                for (var j = i + 1; j < siblingPossibilities.Count; j++)
                {
                    if (siblingPossibilities[i].PossibleValues.SequenceEqual<int>(siblingPossibilities[j].PossibleValues))
                    {
                        matches.Add(siblingPossibilities[j]);
                    }
                }
                if (matches.Count == siblingsCount  && matches.Count > 1)
                {
                    var possibleValuesToRemove = siblingPossibilities[i].PossibleValues;
                    foreach (var sibling in siblingPossibilities)
                    {
                        if (!matches.Contains(sibling))
                        {
                            foreach (var item in possibleValuesToRemove)
                            {
                                sudokuGrid[sibling.Row, sibling.Column].PossibleValues.Remove(item);
                            }
                        }
                    }
                }
            }
        }
    }
}
