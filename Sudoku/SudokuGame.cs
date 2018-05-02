using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuGame
    {
        SudokuBoard sudokuBoard = new SudokuBoard();

        public void UserValue()
        {

            ConsoleKey s = ConsoleKey.A;
            Console.Write("Example data press E; Own Data press O; Press eny key to quiq: ");
            ConsoleKey k = Console.ReadKey().Key;
            if (k == ConsoleKey.E)
            {
                Example();
            }
            else if (k == ConsoleKey.O)
            {
                while (s != ConsoleKey.Q)
                {
                    Console.Write("\n Podaj X: ");
                    int x = Convert.ToInt32(Console.ReadKey().Key) - 48;
                    Console.Write(" | Podaj Y: ");
                    int y = Convert.ToInt32(Console.ReadKey().Key) - 48;
                    Console.Write(" | Podaj wartość 1 - 9: ");
                    int v = Convert.ToInt32(Console.ReadKey().Key) - 48;
                    Console.Write(" | Contiuniue press Enter; Quiq press Q");
                    s = Console.ReadKey().Key;
                    sudokuBoard.SetValueToFiled(y, x, v);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public void PrintBoard()
        {
            Console.WriteLine(sudokuBoard.ToString());
            SudokuResolve sudokuResolve = new SudokuResolve(sudokuBoard);

            Console.WriteLine(sudokuResolve.Resolve().ToString());
            Console.WriteLine("END");
        }

        private void Example()
        {
            //sudokuBoard.SetValueToFiled(1, 1, 4);
            sudokuBoard.SetValueToFiled(1, 5, 7);
            sudokuBoard.SetValueToFiled(1, 2, 2);
            sudokuBoard.SetValueToFiled(1, 4, 5);
            sudokuBoard.SetValueToFiled(1, 6, 1);
            sudokuBoard.SetValueToFiled(1, 8, 9);
            //sudokuBoard.SetValueToFiled(2, 1, 8);
            sudokuBoard.SetValueToFiled(2, 4, 2);
            sudokuBoard.SetValueToFiled(2, 6, 3);
            sudokuBoard.SetValueToFiled(2, 9, 6);
            //sudokuBoard.SetValueToFiled(3, 2, 3);
            sudokuBoard.SetValueToFiled(3, 5, 6);
            sudokuBoard.SetValueToFiled(3, 8, 7);
            sudokuBoard.SetValueToFiled(4, 3, 1);
            sudokuBoard.SetValueToFiled(4, 7, 6);
            sudokuBoard.SetValueToFiled(5, 1, 5);
            //sudokuBoard.SetValueToFiled(5, 2, 4);
            sudokuBoard.SetValueToFiled(5, 8, 1);
            sudokuBoard.SetValueToFiled(5, 9, 9);
            sudokuBoard.SetValueToFiled(6, 3, 2);
            sudokuBoard.SetValueToFiled(6, 7, 7);
            sudokuBoard.SetValueToFiled(7, 2, 9);
            sudokuBoard.SetValueToFiled(7, 5, 3);
            sudokuBoard.SetValueToFiled(7, 8, 8);
           sudokuBoard.SetValueToFiled(8, 1, 2);
            sudokuBoard.SetValueToFiled(8, 4, 8);
            sudokuBoard.SetValueToFiled(8, 6, 4);
            sudokuBoard.SetValueToFiled(8, 9, 7);
            sudokuBoard.SetValueToFiled(9, 2, 1);
            sudokuBoard.SetValueToFiled(9, 4, 9);
            sudokuBoard.SetValueToFiled(9, 6, 7);
            sudokuBoard.SetValueToFiled(9, 8, 6);
        }
    }
}
