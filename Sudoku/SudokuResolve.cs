using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sudoku.Const;

namespace Sudoku
{
    class SudokuResolve
    {
        private SudokuBoard sudokuBoard;
        Stack<SudokuBackTrack> backTracks = new Stack<SudokuBackTrack>();

        public SudokuResolve(SudokuBoard board)
        {
            this.sudokuBoard = board;
        }

        private List<SudokuElement> Row(int rowNo)
        {
            return sudokuBoard.Rows[rowNo].SudokuRows;
        }

        private List<SudokuElement> Column(int colNo)
        {
            List<SudokuElement> elements = new List<SudokuElement>();
            for (int i = MIN_INDEX; i < MAX_INDEX; i++)
            {
                elements.Add(sudokuBoard.Rows[i].SudokuRows[colNo]);
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
                    section.Add(sudokuBoard.Rows[i + secColNo].SudokuRows[j + secRowNo]);
                }
            }
            return section;
        }

        public int CheckInsertValue(int y, int x, int value)
        {
            for (int j = 0; j < 9; j++)
            {
                if (Row(y - 1)[j].Value == value)
                {
                    return EMPTY;
                }
                if (Column(x - 1)[j].Value == value)
                {
                    return EMPTY;
                }
                if (Section(SetXY(y - 1), SetXY(x - 1))[j].Value == value)
                {
                    return EMPTY;
                }
            }
            return value;
        }

        private int SetXY(int i)
        {
            if (i == 1 || i == 4 || i == 7)
            {
                return i - 1;
            }
            else if ((i == 2 || i == 5 || i == 8))
            {
                return i - 2;
            }
            else { return i; }
        }

        private void RowCheck()
        {
            HashSet<int> set = new HashSet<int>();
            for (int r = 0; r < 9; r++)
            {
                List<SudokuElement> row = Row(r);
                for (int i = 0; i < row.Count; i++)
                {
                    if (row[i].Value == -1)
                    {
                        for (int j = 0; j < 9; j++)
                        {

                            if (row[i].PossibleValues.Contains(row[j].Value))
                            {
                                row[i].PossibleValues.Remove(row[j].Value);
                            }
                            else if ((row[i].PossibleValues.Count == 1 && row[i].PossibleValues.Contains(Row(r)[j].Value)) || row[i].PossibleValues.Count == 0)
                            {
                                throw new SudokuException();
                            }
                        }

                        Row(r).Where(v => v.Value == EMPTY).ToList().ForEach(x => x.PossibleValues.ForEach(p => set.Add(p)));

                        if (Row(r)[i].PossibleValues.Count == 1)
                        {
                            row[i].Value = row[i].PossibleValues[0];
                        }
                        //else
                        //{
                        //    for (int p = 0; p < Row(r)[i].PossibleValues.Count; p++)
                        //    {
                        //        if (!set.Contains(Row(r)[i].PossibleValues[p]))
                        //        {
                        //            Row(r)[i].Value = Row(r)[i].PossibleValues[p];
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }

        private void ColumnCheck()
        {
            HashSet<int> set = new HashSet<int>();
            for (int c = 0; c < 9; c++)
            {
                List<SudokuElement> col = Column(c);
                for (int i = 0; i < col.Count; i++)
                {
                    if (col[i].Value == -1)
                    {
                        for (int j = 0; j < 9; j++)
                        {

                            if (col[i].PossibleValues.Contains(col[j].Value))
                            {
                                col[i].PossibleValues.Remove(col[j].Value);
                            }
                            else if ((col[i].PossibleValues.Count == 1 && col[i].PossibleValues.Contains(col[j].Value)) || col[i].PossibleValues.Count == 0)
                            {
                                throw new SudokuException();
                            }
                        }

                        col.Where(v => v.Value == EMPTY).ToList().ForEach(x => x.PossibleValues.ForEach(p => set.Add(p)));

                        if (col[i].PossibleValues.Count == 1)
                        {
                            col[i].Value = col[i].PossibleValues[0];
                        }
                        //else
                        //{
                        //    for (int p = 0; p < Column(c)[i].PossibleValues.Count; p++)
                        //    {
                        //        if (!set.Contains(Column(c)[i].PossibleValues[p]))
                        //        {
                        //            Column(c)[i].Value = Column(c)[i].PossibleValues[p];
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }

        private void SectionCheck()
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    List<SudokuElement> section = Section(i, j);
                    for (int c = 0; c < 9; c++)
                    {
                        if (section[c].Value == -1)
                        {
                            for (int e = 0; e < 9; e++)
                            {
                                if ((section[c].PossibleValues.Count == 1 && section[c].PossibleValues.Contains(section[e].Value)) || section[c].PossibleValues.Count == 0)
                                {
                                    throw new SudokuException();
                                }
                                else if (section[c].PossibleValues.Contains(section[e].Value))
                                {
                                    section[c].PossibleValues.Remove(section[e].Value);
                                }
                            }

                            section.Where(v => v.Value == EMPTY).ToList().ForEach(x => x.PossibleValues.ForEach(p => set.Add(p)));

                            if (section[c].PossibleValues.Count == 1)
                            {
                                section[c].Value = section[c].PossibleValues[0];
                            }
                            //else
                            //{
                            //    for (int p = 0; p < Section(i, j)[c].PossibleValues.Count; p++)
                            //    {
                            //        if (!set.Contains(Section(i, j)[c].PossibleValues[p]))
                            //        {
                            //            Section(i, j)[c].Value = Section(i, j)[c].PossibleValues[p];
                            //        }
                            //    }
                            //}
                        }
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
                    if (Row(i)[j].Value == EMPTY)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool Solving(int counter, int counterTemp)
        {
            return !(counter == counterTemp);
        }

        private int Progress()
        {
            return sudokuBoard.Rows.Sum(s => s.SudokuRows.Count(r => r.Value == EMPTY));
        }

        private void StandardResolve()
        {
            try
            {
                int start = 0;
                int end = 0;
                do
                {
                    start = Progress();
                    RowCheck();
                    ColumnCheck();
                    SectionCheck();
                    end = Progress();
                } while (Solving(start, end) == true);
            }
            catch
            {
                try
                {
                    BackTrack();
                }
                catch
                {
                    Console.WriteLine("Brak rozwiązania");
                }
            }
        }

        public SudokuBoard Resolve()
        {
            int counter = 1;
            bool error = true;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (!Solved() && error)
            {

                StandardResolve();

                try
                {
                    Guess();
                }
                catch
                {
                    try
                    {
                        BackTrack();
                    }
                    catch
                    {
                        Console.WriteLine("Brak rozwiązania");
                        error = false;
                    }
                }
                counter++;
            }
            stopwatch.Stop();
            double time4 = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine("Loops: " + counter);
            Console.WriteLine($"Resolve Time: {time4} ms");
            return sudokuBoard;
        }

        private bool Guess()
        {
            Random radnom = new Random();
            int value = 0;
            for (int r = 0; r < 9; r++)
            {
                List<SudokuElement> row = Row(r);
                for (int i = 0; i < 9; i++)
                {
                    if (row[i].Value == -1)
                    {
                        if (row[i].PossibleValues.Count >= 1)
                        {
                            int p = radnom.Next(0, row[i].PossibleValues.Count);
                            value = row[i].PossibleValues[p];
                            backTracks.Push(new SudokuBackTrack((SudokuBoard)sudokuBoard.Clone(), value, i, r));
                            row[i].Value = value;
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
                sudokuBoard = back.SudokuBoard;
                sudokuBoard.Rows[back.Y].SudokuRows[back.X].PossibleValues.Remove(back.Value);
            }
            else
            {
                throw new SudokuException();
            }

        }
    }
}