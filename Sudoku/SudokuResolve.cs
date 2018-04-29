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

        public void SprawdzanieWiersza()
        {
            for (int r = 0; r < 9; r++)
            {
                for (int i = 0; i < Row(r).Count; i++)
                {
                    if (Row(r)[i].Value == -1)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (Row(r)[i].PossibleValues.Contains(Row(r)[j].Value))
                            {
                                Row(r)[i].PossibleValues.Remove(Row(r)[j].Value);
                            }
                        }
                        Row(r)[i].Value = Row(r)[i].PossibleValues[0];
                    }
                }
            }
        }
        public void ColumnCheck()
        {

        }
    }
}

