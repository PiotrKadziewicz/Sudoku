using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuGame
    {
        private SudokuBoard sudokuBoard = new SudokuBoard();

        public void UserValue()
        {
            SudokuResolve sudokuResolve = new SudokuResolve(sudokuBoard);
            ConsoleKey s = ConsoleKey.A;
            Console.Write("Example data press E; Own Data press O; Press eny key to quit: ");
            ConsoleKey k = Console.ReadKey().Key;
            if (k == ConsoleKey.E)
            {
                Example();
                Console.WriteLine(sudokuBoard.ToString());
            }
            else if (k == ConsoleKey.O)
            {
                Console.WriteLine(sudokuBoard.ToString());
                while (s != ConsoleKey.S)
                {
                    int x = 0, y = 0, v = 0;
                    while (!(x > 0 && x <= 9) || !(y > 0 && y <= 9) || !(v > 0 && v <= 9))
                    {

                        Console.Write("\n Podaj X: ");
                        x = Convert.ToInt32(Console.ReadKey().KeyChar) - 48;
                        Console.Write(" | Podaj Y: ");
                        y = Convert.ToInt32(Console.ReadKey().KeyChar) - 48;
                        Console.Write(" | Podaj wartość 1 - 9: ");
                        v = Convert.ToInt32(Console.ReadKey().KeyChar) - 48;
                        if (!(x > 0 && x <= 9) || !(y > 0 && y <= 9) || !(v > 0 && v <= 9))
                        {
                            Console.WriteLine("Wprowadziłeś złą wartość. Spróbuj jeszcze raz");
                        }
                    }
                    
                    sudokuBoard.SetValueToField(y, x, sudokuResolve.CheckInsertValue(y,x,v));
                    Console.WriteLine();
                    Console.Write("Contiuniue press Enter; Start SOLVING SUDOKU press S");
                    s = Console.ReadKey().Key;
                    Console.WriteLine();
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public bool ResolveSudoku()
        {
            SudokuResolve sudokuResolve = new SudokuResolve(sudokuBoard);
            Console.Write("To start SUODKU press S; To QUIT press q");
            ConsoleKey s = ConsoleKey.A;
            s = Console.ReadKey().Key;
            if (s == ConsoleKey.S)
            {
                Console.WriteLine();
                UserValue();
                Console.WriteLine(sudokuBoard.ToString());
                Console.WriteLine("Press any key to continiue...");
                Console.ReadKey();
                Console.WriteLine(sudokuResolve.Resolve().ToString());
                return false;
            }
            else if (s == ConsoleKey.Q)
            {
                return true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Wrong KEY!");
                return false;
            }
        }

        private void Example()
        {
            sudokuBoard.SetValueToField(1, 1, 4);
            sudokuBoard.SetValueToField(1, 2, 2);
            sudokuBoard.SetValueToField(1, 4, 5);
            sudokuBoard.SetValueToField(1, 6, 1);
            sudokuBoard.SetValueToField(1, 8, 9);
            sudokuBoard.SetValueToField(2, 1, 8);
            sudokuBoard.SetValueToField(2, 4, 2);
            sudokuBoard.SetValueToField(2, 6, 3);
            sudokuBoard.SetValueToField(2, 9, 6);
            sudokuBoard.SetValueToField(3, 2, 3);
            sudokuBoard.SetValueToField(3, 5, 6);
            sudokuBoard.SetValueToField(3, 8, 7);
            sudokuBoard.SetValueToField(4, 3, 1);
            sudokuBoard.SetValueToField(4, 7, 6);
            sudokuBoard.SetValueToField(5, 1, 5);
            sudokuBoard.SetValueToField(5, 2, 4);
            sudokuBoard.SetValueToField(5, 8, 1);
            sudokuBoard.SetValueToField(5, 9, 9);
            sudokuBoard.SetValueToField(6, 3, 2);
            sudokuBoard.SetValueToField(6, 7, 7);
            sudokuBoard.SetValueToField(7, 2, 9);
            sudokuBoard.SetValueToField(7, 5, 3);
            sudokuBoard.SetValueToField(7, 8, 8);
            sudokuBoard.SetValueToField(8, 1, 2);
            sudokuBoard.SetValueToField(8, 4, 8);
            sudokuBoard.SetValueToField(8, 6, 4);
            sudokuBoard.SetValueToField(8, 9, 7);
            sudokuBoard.SetValueToField(9, 2, 1);
            sudokuBoard.SetValueToField(9, 4, 9);
            sudokuBoard.SetValueToField(9, 6, 7);
            sudokuBoard.SetValueToField(9, 8, 6);
            sudokuBoard.SetValueToField(9, 9, 1);
        }
    }
}
