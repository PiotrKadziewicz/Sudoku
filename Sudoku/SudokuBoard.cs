using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuBoard
    {
        public readonly static int MIN_INDEX = 0;
        public readonly static int MAX_INDEX = 9;
        SudokuRow[] sudokuRows = new SudokuRow[10];

        public SudokuBoard(SudokuRow[] sudokuRows)
        {
            this.sudokuRows = sudokuRows;
        }
    }
}
