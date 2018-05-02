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
        Stack<SudokuBackTrack> backTracks = new Stack<SudokuBackTrack>();

        public SudokuResolve(SudokuBoard board)
        {
            this.board = board;
        }

        private List<SudokuElement> Row(int rowNo)
        {
            return board.columns[rowNo].sudokuRow;
        }

        private List<SudokuElement> Column(int colNo)
        {
            List<SudokuElement> elements = new List<SudokuElement>();
            for (int i = 0; i < 9; i++)
            {
                elements.Add(board.columns[i].sudokuRow[colNo]);
            }
            return elements;
        }

        private List<SudokuElement> Section(int secColNo, int secRowNo)
        {
            List<SudokuElement> section = new List<SudokuElement>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    section.Add(board.columns[i + secColNo].sudokuRow[j + secRowNo]);
                }
            }
            return section;
        }

        private void RowCheck()
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
                            else if ((Row(r)[i].PossibleValues.Count == 1 && Row(r)[i].PossibleValues.Contains(Row(r)[j].Value)) || Row(r)[i].PossibleValues.Count == 0)
                            {
                                throw new SudokuException();
                            }

                        }
                        if (Row(r)[i].PossibleValues.Count == 1)
                        {
                            Row(r)[i].Value = Row(r)[i].PossibleValues[0];
                        }
                    }

                }
            }
        }
        private void ColumnCheck()
        {
            for (int c = 0; c < 9; c++)
            {
                HashSet<int> set = new HashSet<int>();
                for (int i = 0; i < Column(c).Count; i++)
                {
                    if (Column(c)[i].Value == -1)
                    {
                        for (int j = 0; j < 9; j++)
                        {

                            if (Column(c)[i].PossibleValues.Contains(Column(c)[j].Value))
                            {
                                Column(c)[i].PossibleValues.Remove(Column(c)[j].Value);
                            }
                            else if ((Column(c)[i].PossibleValues.Count == 1 && Column(c)[i].PossibleValues.Contains(Column(c)[j].Value)) || Column(c)[i].PossibleValues.Count == 0)
                            {
                                throw new SudokuException();
                            }
                        }
                        if (Column(c)[i].PossibleValues.Count == 1)
                        {
                            Column(c)[i].Value = Column(c)[i].PossibleValues[0];
                        }

                        ////ColumnCheckPossibilities
                        //Column(c)[i].PossibleValues.ForEach(p => set.Add(p));

                        //for (int j = 0; j < 9; j++)
                        //{
                        //    if (Column(c)[j].Value == -1)
                        //    {
                        //        for (int p = 0; p < Column(c)[j].PossibleValues.Count; p++)
                        //        {
                        //            if (!set.Contains(Column(c)[j].PossibleValues[p]))
                        //            {
                        //                Column(c)[i].Value = Column(c)[j].PossibleValues[p];
                        //            }
                        //        }

                        //    }
                        //}
                    }
                }
            }
        }

        private void SectionCheck()
        {
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    HashSet<int> set = new HashSet<int>();
                    for (int c = 0; c < 9; c++)
                    {
                        if (Section(i, j)[c].Value == -1)
                        {
                            for (int e = 0; e < 9; e++)
                            {
                                if ((Section(i, j)[c].PossibleValues.Count == 1 && Section(i, j)[c].PossibleValues.Contains(Section(i, j)[e].Value)) || Section(i, j)[c].PossibleValues.Count == 0)
                                {
                                    throw new SudokuException();
                                }
                                else if (Section(i, j)[c].PossibleValues.Contains(Section(i, j)[e].Value))
                                {
                                    Section(i, j)[c].PossibleValues.Remove(Section(i, j)[e].Value);
                                }
                            }
                        }
                        if (Section(i, j)[c].PossibleValues.Count == 1)
                        {
                            Section(i, j)[c].Value = Section(i, j)[c].PossibleValues[0];
                        }
                        //Section(i, j)[c].PossibleValues.ForEach(p => set.Add(p));
                        //for (int g = 0; g < 9; g++)
                        //{
                        //    if (Section(i, j)[g].Value == -1)
                        //    {
                        //        for (int p = 0; p < Section(i, j)[g].PossibleValues.Count; p++)
                        //        {
                        //            if (!set.Contains(Section(i, j)[g].PossibleValues[p]))
                        //            {
                        //                Section(i, j)[c].Value = Section(i, j)[g].PossibleValues[p];
                        //            }
                        //        }
                        //    }
                        //}
                    }

                }
            }
        }

        private bool Solved()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Row(i)[j].Value == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool Solving(int counter, int counterTemp)
        {
            if (counter == counterTemp)
            {
                return false;
            }
            return true;
        }

        private void StandardResolve()
        {
            try
            {
                int counter = 0;
                int counterTemp = 0;
                do
                {
                    counter = 0;
                    counterTemp = 0;

                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (Row(i)[j].Value == -1)
                            {
                                counter++;
                            }
                        }
                    }

                    RowCheck();
                    ColumnCheck();
                    SectionCheck();

                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (Row(i)[j].Value == -1)
                            {
                                counterTemp++;
                            }
                        }
                    }
                } while (Solving(counter, counterTemp) == true);
            }
            catch (SudokuException exp)
            {
                BackTrack();
            }
        }

        public SudokuBoard Resolve()
        {
            while (!Solved())
            {

                StandardResolve();
                try
                {
                    Guess();
                }
                catch (SudokuException exp)
                {
                    StandardResolve();
                }
            }
            return board;
        }

        private bool Guess()
        {
            int value = 0;
            for (int r = 0; r < 9; r++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (Row(r)[i].Value == -1)
                    {
                        if (Row(r)[i].PossibleValues.Count >= 1)
                        {
                            value = Row(r)[i].PossibleValues[0];
                            backTracks.Push(new SudokuBackTrack((SudokuBoard)board.Clone(), value, i, r));
                            Console.WriteLine("Insert: " + value);

                            Row(r)[i].Value = value;
                            Console.WriteLine(board.ToString());
                            return true;
                        }
                        else
                        {
                            throw new SudokuException();
                        }
                    }
                }
            }
            return true;
        }

        private void BackTrack()
        {
            if (backTracks.Count != 0)
            {
                SudokuBackTrack back = backTracks.Pop();
                board = back.SudokuBoard;
                Console.WriteLine("\nBACKTRACK | Value: " + back.Value + " | Posision: " + back.Y + " | " + back.X + "\n" + back.SudokuBoard);
                board.columns[back.Y].sudokuRow[back.X].PossibleValues.Remove(back.Value);
                board.columns[back.Y].sudokuRow[back.X].PossibleValues.ForEach(p => Console.Write(p + " | "));
            }
            else
            {
                throw new SudokuException();
            }

        }
    }
}
