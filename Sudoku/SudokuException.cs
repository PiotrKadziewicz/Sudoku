using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuException : Exception
    {
        public SudokuException()
        {
        }

        public SudokuException(string message) : base("Get back" + message)
        {
        }
    }
}
