using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuResolve
    {
        private SudokuBoard board;
        public SudokuResolve(SudokuBoard board)
        {
            this.board = board;
        }

        public List<SudokuElement> Row(int rowNo)
        {
            return board.columns[rowNo].sudokuRow;
        }

        public List<SudokuElement> Column(int colNo)
        {
            List<SudokuElement> elements = new List<SudokuElement>();
            for (int i = 0; i < 9; i++)
            {
                elements.Add(board.columns[i].sudokuRow[colNo]);
            }
            return elements;
        }
    }
}
