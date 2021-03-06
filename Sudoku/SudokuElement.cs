﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sudoku.Const;

namespace Sudoku
{
    class SudokuElement
    {
        public int Value { get; set; }
        public List<int> PossibleValues { get; set; }
        public SudokuElement()
        {
            Value = EMPTY;
            PossibleValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
        public override string ToString()
        {
            return Value + " | ";
        }
    }
}
