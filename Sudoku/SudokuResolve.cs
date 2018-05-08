using System;
using System.Collections.Generic;
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

            for (int r = MIN_INDEX; r < MAX_INDEX; r++)
            {
                for (int i = MIN_INDEX; i < Row(r).Count; i++)
                {
                    if (Row(r)[i].Value == EMPTY)
                    {
                        for (int j = MIN_INDEX; j < MAX_INDEX; j++)
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

                        Row(r).Where(v => v.Value == EMPTY).ToList().ForEach(x => x.PossibleValues.ForEach(p => set.Add(p)));


                        if (Row(r)[i].PossibleValues.Count == 1)
                        {
                            Row(r)[i].Value = Row(r)[i].PossibleValues[0];
                        }
                        else
                        {
                            for (int p = 0; p < Row(r)[i].PossibleValues.Count; p++)
                            {
                                if (!set.Contains(Row(r)[i].PossibleValues[p]))
                                {
                                    Row(r)[i].Value = Row(r)[i].PossibleValues[p];
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ColumnCheck()
        {
            HashSet<int> set = new HashSet<int>();

            for (int c = MIN_INDEX; c < MAX_INDEX; c++)
            {
                for (int i = MIN_INDEX; i < Column(c).Count; i++)
                {
                    if (Column(c)[i].Value == EMPTY)
                    {
                        for (int j = MIN_INDEX; j < MAX_INDEX; j++)
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

                        Column(c).Where(v => v.Value == EMPTY).ToList().ForEach(x => x.PossibleValues.ForEach(p => set.Add(p)));

                        if (Column(c)[i].PossibleValues.Count == 1)
                        {
                            Column(c)[i].Value = Column(c)[i].PossibleValues[0];
                        }
                        else
                        {
                            for (int p = 0; p < Column(c)[i].PossibleValues.Count; p++)
                            {
                                if (!set.Contains(Column(c)[i].PossibleValues[p]))
                                {
                                    Column(c)[i].Value = Column(c)[i].PossibleValues[p];
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SectionCheck()
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = MIN_INDEX; i < MAX_INDEX; i += 3)
            {
                for (int j = MIN_INDEX; j < MAX_INDEX; j += 3)
                {
                    for (int c = MIN_INDEX; c < 9; c++)
                    {
                        if (Section(i, j)[c].Value == EMPTY)
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

                            Section(i, j).Where(v => v.Value == EMPTY).ToList().ForEach(x => x.PossibleValues.ForEach(p => set.Add(p)));

                            if (Section(i, j)[c].PossibleValues.Count == 1)
                            {
                                Section(i, j)[c].Value = Section(i, j)[c].PossibleValues[0];
                            }
                            else
                            {
                                for (int p = 0; p < Section(i, j)[c].PossibleValues.Count; p++)
                                {
                                    if (!set.Contains(Section(i, j)[c].PossibleValues[p]))
                                    {
                                        Section(i, j)[c].Value = Section(i, j)[c].PossibleValues[p];
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool Solved()
        {
            for (int i = MIN_INDEX; i < MAX_INDEX; i++)
            {
                for (int j = MIN_INDEX; j < MAX_INDEX; j++)
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
            catch (SudokuException exp)
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
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            start = DateTime.Now;

            while (!Solved())
            {
                StandardResolve();
                try
                {
                    Guess();
                }
                catch (SudokuException exp)
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
                counter++;
            }
            end = DateTime.Now;
            Console.WriteLine("Loops: " + counter);
            Console.WriteLine("Solving Time: " + (end - start));
            return sudokuBoard;
        }

        private bool Guess()
        {
            int value = 0;
            for (int r = MIN_INDEX; r < MAX_INDEX; r++)
            {
                for (int i = MIN_INDEX; i < MAX_INDEX; i++)
                {
                    if (Row(r)[i].Value == EMPTY)
                    {
                        if (Row(r)[i].PossibleValues.Count >= 1)
                        {
                            value = Row(r)[i].PossibleValues[0];
                            backTracks.Push(new SudokuBackTrack((SudokuBoard)sudokuBoard.Clone(), value, i, r));
                            Row(r)[i].Value = value;
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