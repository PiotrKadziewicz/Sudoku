using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuBackTrack
    {
        public SudokuBoard SudokuBoard { get; set; }
        public int Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public SudokuBackTrack(SudokuBoard sudokuBoard, int value, int x, int y)
        {
            this.SudokuBoard = sudokuBoard;
            Value = value;
            X = x;
            Y = y;
        }
    }
}
