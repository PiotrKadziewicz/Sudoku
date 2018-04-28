using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuRow
    {
        public readonly static int MIN_INDEX = 0;
        public readonly static int MAX_INDEX = 9;
        public List<SudokuElement> sudokuRow { get; set; }

        public void setElement(SudokuElement sudokuElement)
        {
            sudokuRow = new List<SudokuElement>();
            for (int i= MIN_INDEX; i < MAX_INDEX; i++)
            {
                sudokuRow.Add(new SudokuElement());
            }
        }

        public override string ToString()
        {
            return "SudokuRow{" +

                "sudokuRow=" + sudokuRow +

                '}'; ;
        }
    }
}
