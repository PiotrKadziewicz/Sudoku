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
        List<SudokuBackTrack> backTracks = new List<SudokuBackTrack>();

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
                            if (Row(r)[i].PossibleValues.Count == 1 && Row(r)[i].PossibleValues.Contains(Row(r)[j].Value))
                            {
                                throw new SudokuException();
                            }
                            else if (Row(r)[i].PossibleValues.Contains(Row(r)[j].Value))
                            {
                                Row(r)[i].PossibleValues.Remove(Row(r)[j].Value);
                            }
                        }
                    }
                }
            }
        }

        private void RowCheckPossibilities()
        {

            for (int r = 0; r < 9; r++)
            {
                HashSet<int> set = new HashSet<int>();
                for (int i = 0; i < 9; i++)
                {
                    if (Row(r)[i].Value == -1)
                    {
                        foreach (int pos in Row(r)[i].PossibleValues)
                        {
                            set.Add(pos);
                        }
                    }
                }

                for (int i = 0; i < 9; i++)
                {
                    if (Row(r)[i].Value == -1)
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

        private void InsertValueRow()
        {
            for (int r = 0; r < 9; r++)
            {
                for (int i = 0; i < Row(r).Count; i++)
                {
                    if (Row(r)[i].Value == -1)
                    {
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
                for (int i = 0; i < Column(c).Count; i++)
                {
                    if (Column(c)[i].Value == -1)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (Column(c)[i].PossibleValues.Count == 1 && Column(c)[i].PossibleValues.Contains(Column(c)[j].Value))
                            {
                                throw new SudokuException();
                            }
                            else if (Column(c)[i].PossibleValues.Contains(Column(c)[j].Value))
                            {
                                Column(c)[i].PossibleValues.Remove(Column(c)[j].Value);
                            }
                        }

                    }
                }
            }
        }

        private void ColumnCheckPossibilities()
        {

            for (int c = 0; c < 9; c++)
            {
                HashSet<int> set = new HashSet<int>();
                for (int i = 0; i < 9; i++)
                {
                    if (Column(c)[i].Value == -1)
                    {
                        foreach (int pos in Column(c)[i].PossibleValues)
                        {
                            set.Add(pos);
                        }
                    }
                }

                for (int i = 0; i < 9; i++)
                {
                    if (Column(c)[i].Value == -1)
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

        private void InsertValueColumn()
        {
            for (int c = 0; c < 9; c++)
            {
                for (int i = 0; i < Column(c).Count; i++)
                {
                    if (Column(c)[i].Value == -1)
                    {
                        if (Column(c)[i].PossibleValues.Count == 1)
                        {
                            Column(c)[i].Value = Column(c)[i].PossibleValues[0];
                        }
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
                    for (int c = 0; c < 9; c++)
                    {
                        if (Section(i, j)[c].Value == -1)
                        {
                            for (int e = 0; e < 9; e++)
                            {
                                if (Section(i, j)[c].PossibleValues.Count == 1 && Section(i, j)[c].PossibleValues.Contains(Section(i, j)[e].Value))
                                {
                                    throw new SudokuException();
                                }
                                else if (Section(i, j)[c].PossibleValues.Contains(Section(i, j)[e].Value))
                                {
                                    Section(i, j)[c].PossibleValues.Remove(Section(i, j)[e].Value);
                                }
                            }
                        }
                    }

                }
            }
        }

        private void SecionCheckPossibilities()
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
                            foreach (int pos in Section(i, j)[c].PossibleValues)
                            {
                                set.Add(pos);
                            }

                        }
                    }

                    for (int c = 0; c < 9; c++)
                    {
                        if (Section(i, j)[c].Value == -1)
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

        private void InsertValueSection()
        {
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        if (Section(i, j)[c].Value == -1)
                        {
                            if (Section(i, j)[c].PossibleValues.Count == 1)
                            {
                                Section(i, j)[c].Value = Section(i, j)[c].PossibleValues[0];
                            }
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

        public void Resolve()
        {
            int counter = 0;
            int counterTemp = 0;
            int count = 1;
            try
            {
                do
                {
                    counter = 0;
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {

                            RowCheck();
                            ColumnCheck();
                            SectionCheck();
                            InsertValueRow();
                            InsertValueColumn();
                            InsertValueSection();
                            RowCheckPossibilities();
                            ColumnCheckPossibilities();
                            SecionCheckPossibilities();

                            if (Row(i)[j].Value == -1)
                            {
                                counter++;
                            }
                        }
                    }
                    count++;
                    counterTemp = counter;
                } while (Solving(counter, counterTemp) == true);
            }
            catch (SudokuException exp)
            {
                BackTrack();
            }
            if (!Solved())
            {
                try
                {
                    Guess();
                }
                catch (SudokuException exp)
                {
                    Resolve();
                }
            }

            Console.WriteLine("Ilość pętli: " + count);
        }

        private void Guess()
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
                            backTracks.Add(new SudokuBackTrack((SudokuBoard)board.Clone(), value, i, r));
                            Console.WriteLine("Insert: " + value);

                            Row(r)[i].Value = value;
                            Console.WriteLine(board.ToString());
                            Resolve();
                        }
                        else
                        {
                            throw new SudokuException();
                        }
                    }
                }
            }
        }

        private void BackTrack()
        {
            SudokuBackTrack back = backTracks[backTracks.Count - 1];
            backTracks.Remove(back);
            board = back.SudokuBoard;
            //Console.WriteLine("\nBACKTRACK | Value: " + back.Value + " | Posision: " + back.Y + " | " + back.X + "\n" + back.SudokuBoard);
            board.columns[back.Y].sudokuRow[back.X].PossibleValues.Remove(back.Value);
            // board.columns[back.Y].sudokuRow[back.X].PossibleValues.ForEach(p => Console.Write(p + " | "));
        }
    }
}