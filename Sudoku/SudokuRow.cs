using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sudoku.Const;

namespace Sudoku
{
    class SudokuRow
    {

        public List<SudokuElement> SudokuRows { get; set; }

        public SudokuRow()
        {
            this.SudokuRows = new List<SudokuElement>();
            for (int i = MIN_INDEX; i < MAX_INDEX; i++)
            {
                SudokuRows.Add(new SudokuElement());
            }
        }

        public SudokuRow(int clone)
        {
            this.SudokuRows = new List<SudokuElement>();
        }
    }
}
