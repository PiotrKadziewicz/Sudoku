using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    static void Main(string[] args)
    {
        bool gameFinished = false;
        while (!gameFinished)
        {
            SudokuGame theGame = new SudokuGame();
            gameFinished = theGame.resolveSudoku();

        }
    }
}
