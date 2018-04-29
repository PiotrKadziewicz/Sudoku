using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuElement
    {
        public static int EMPTY = -1;
        public int Value { get; set; }
        //public Queue<int> PossibleValues { get; set; }
        public List<int> PossibleValues { get; set; }
        public SudokuElement()
        {
            Value = EMPTY;
            PossibleValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //PossibleValues = new Queue<int>();
            //PossibleValues.Enqueue(1);
            //PossibleValues.Enqueue(2);
            //PossibleValues.Enqueue(3);
            //PossibleValues.Enqueue(4);
            //PossibleValues.Enqueue(5);
            //PossibleValues.Enqueue(6);
            //PossibleValues.Enqueue(7);
            //PossibleValues.Enqueue(8);
            //PossibleValues.Enqueue(9);
        }
        public override string ToString()
        {
            return Value + " | ";
        }
    }
}
