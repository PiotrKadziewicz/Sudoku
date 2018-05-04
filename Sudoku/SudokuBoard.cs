using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuBoard : ICloneable
    {
        public readonly static int MIN_INDEX = 0;
        public readonly static int MAX_INDEX = 9;
        public static int EMPTY = -1;

        public List<SudokuRow> Rows { get; set; }

        public SudokuBoard()
        {
            this.Rows = new List<SudokuRow>();
            for (int i = MIN_INDEX; i < MAX_INDEX; i++)
            {
                Rows.Add(new SudokuRow());
            }
        }

        public void SetValueToField(int row, int column, int value)
        {
            Rows[row - 1].SudokuRows[column - 1].Value = value; 
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
                    if (Rows[i].SudokuRows[j].Value == EMPTY)
                    {
                        board += "  | ";
                    }
                    else
                    {
                        board += Rows[i].SudokuRows[j].Value + " | ";
                    }

                }
                board += "\n    -------------------------------------\n";
            }

            return board;
        }

        public object Clone()
        {
            SudokuBoard clonedBoard = new SudokuBoard();
            clonedBoard.Rows = new List<SudokuRow>();

            foreach (SudokuRow row in Rows)
            {
                SudokuRow clonedRow = new SudokuRow();
                clonedRow.SudokuRows.Clear();
                foreach (SudokuElement element in row.SudokuRows)
                {
                    SudokuElement clonedElemnt = new SudokuElement();
                    clonedElemnt.Value = element.Value;
                    clonedElemnt.PossibleValues.Clear();
                    element.PossibleValues.ForEach(e => clonedElemnt.PossibleValues.Add(e));
                    clonedRow.SudokuRows.Add(clonedElemnt);
                }
                clonedBoard.Rows.Add(clonedRow);
            }
            return clonedBoard;
        }
    }
}
