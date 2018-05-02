using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameFinished = false;
            while (!gameFinished)
            {
                Console.WriteLine("Welcome to the sudoku game!");
                SudokuGame theGame = new SudokuGame();
                gameFinished = theGame.ResolveSudoku();
            }
        }
    }

}
