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

        public List<SudokuRow> sudokuRows { get; set; }

        public SudokuBoard()
        {
            sudokuRows = new List<SudokuRow>();
            for (int i = MIN_INDEX; i <= MAX_INDEX; i++)
            {
                sudokuRows.Add(new SudokuRow());
            }
        }

        public void SetValueToFiled(int row, int column, int value)
        {
            sudokuRows[row - 1].sudokuRow[column - 1].Value = value;
        }
    }
}
