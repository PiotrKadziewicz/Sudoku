using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuRow
    {
        public List<SudokuElement> sudokuRow = new List<SudokuElement>();

        public void setElement(SudokuElement sudokuElement)
        {
            for (int i=0; i < 10; i++)
            {
                sudokuRow.Add(new SudokuElement(-1));
            }
        }
    }
}
