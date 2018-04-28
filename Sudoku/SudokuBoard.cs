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
        public static int EMPTY = -1;

        public List<SudokuRow> columns{ get; set; }

        public SudokuBoard()
        {
            columns = new List<SudokuRow>();
            for (int i = MIN_INDEX; i < MAX_INDEX; i++)
            {
                columns.Add(new SudokuRow());
            }
        }

        public void SetValueToFiled(int row, int column, int value)
        {
            columns[row - 1].sudokuRow[column - 1].Value = value;
        }

        public override string ToString()
        {

            string board = "\n\n  X   1   2   3   4   5   6   7   8   9 \n";
            board += "Y   -------------------------------------\n";

            for (int i = 0; i < MAX_INDEX; i++)
            {
                board += (i + 1) + "   | ";

                for (int j = 0; j < MAX_INDEX; j++)
                {
                    if (columns[i].sudokuRow[j].Value == EMPTY)
                    {
                        board += "  | ";
                    }
                    else
                    {
                        board += columns[i].sudokuRow[j].Value + " | ";
                    }
                        
                }
                board += "\n    -------------------------------------\n";
            }

            return board;
        }
    }
}
