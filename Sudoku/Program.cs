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
            //bool gameFinished = false;
            //while (!gameFinished)
            //{
            //    SudokuGame theGame = new SudokuGame();
            //    gameFinished = theGame.resolveSudoku();

            //}

            SudokuGame sudokuGame = new SudokuGame();
            //sudokuGame.PrintBoard();
            sudokuGame.UserValue();
            sudokuGame.PrintBoard();
            Console.ReadLine();
        }
    }

}
