﻿using System;
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
                //int r = 0;
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
                        }
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
                                if (Section(i, j)[c].PossibleValues.Contains(Section(i, j)[e].Value))
                                {
                                    Section(i, j)[c].PossibleValues.Remove(Section(i, j)[e].Value);
                                }
                            }
                            if (Section(i, j)[c].PossibleValues.Count == 1)
                            {
                                Section(i, j)[c].Value = Section(i, j)[c].PossibleValues[0];
                            }
                        }
                    }

                }
            }
        }

        public void Resolve()
        {
            bool check = true;
            int emptyValue = 0;
            int emptyValueTemp = 0;
            int count = 1;
            while (check == true)
            {
                check = false;
                emptyValue = 0;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        RowCheck();
                        ColumnCheck();
                        SectionCheck();

                        if (Row(i)[j].Value == -1)
                        {
                            emptyValue++;
                            check = true;
                        }
                    }
                }
                if (emptyValueTemp == emptyValue)
                {
                    //check = false;
                }
                count++;
                emptyValueTemp = emptyValue;

            }
            Console.WriteLine("Ilość pętli: " + count);
        }

        public void guess()
        {
            SudokuBoard boardCopy = new SudokuBoard();
            boardCopy = (SudokuBoard)board.Clone();
            int i = 0;
            int j = 0;
            int value = 0;

            if (backTracks == null)
            {
                for (i = 0; i < 9; i++)
                {
                    for (j = 0; j < 9; j++)
                    {
                        if (Row(i)[j].Value == -1)
                        {
                            for (int e = 0; e < Row(i)[j].PossibleValues.Count; e++)
                            {
                                value = Row(i)[j].PossibleValues[e];
                                Row(i)[j].PossibleValues.Remove(e);
                                Row(i)[j].Value = value;
                                break;
                            }

                        }
                    }
                }
            }
            else
            {
            }
            backTracks.Add(new SudokuBackTrack(boardCopy, value, i, j));
        }
    }
}