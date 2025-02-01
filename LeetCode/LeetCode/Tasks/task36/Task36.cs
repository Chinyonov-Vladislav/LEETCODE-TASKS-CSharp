using System;
using System.Collections.Generic;
using LeetCode.Basic;
namespace LeetCode.Tasks.task36
{
    public class Task36 : InfoBasicTask
    {
        private char[][] sudokuField;
        public Task36(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
            sudokuField = new char[][] {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };
        }

        public override void execute()
        {
            string result = isValidSudoku(sudokuField) ? "Поле для судоку валидно" : "Поле для судоку не валидно";
            Console.WriteLine(result);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValidSudoku(char[][] board)
        {
            char emptyChar = '.';
            List<char> chars = new List<char>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] != emptyChar)
                    {
                        chars.Add(board[i][j]);
                    }
                }
                if (chars.Count != 0)
                {
                    HashSet<char> set = new HashSet<char>(chars);
                    if (chars.Count != set.Count)
                    {
                        return false;
                    }
                }
                chars.Clear();
            }
            int countColumn = 9;
            int currentColumn = 0;
            while (currentColumn < countColumn)
            {
                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i][currentColumn] != emptyChar)
                    {
                        chars.Add(board[i][currentColumn]);
                    }
                }
                if (chars.Count != 0)
                {
                    HashSet<char> set = new HashSet<char>(chars);
                    if (chars.Count != set.Count)
                    {
                        return false;
                    }
                }
                chars.Clear();
                currentColumn++;
            }
            List<char> square = new List<char>();
            int[][] borders = new int[][]
            {
                new int[] { 0,2,0,2 } ,
                new int[] { 0, 2, 3, 5 } ,
                new int[] { 0, 2, 6, 8 } ,
                new int[] { 3, 5, 0, 2 } ,
                new int[] { 3, 5, 3, 5 } ,
                new int[] { 3, 5, 6, 8 } ,
                new int[] { 6, 8, 0, 2 } ,
                new int[] { 6, 8, 3, 5 } ,
                new int[] { 6, 8, 6, 8 } ,
            };
            foreach (var border in borders)
            {
                for (int i = border[0]; i <= border[1]; i++)
                {
                    for (int j = border[2]; j <= border[3]; j++)
                    {
                        if (board[i][j] != emptyChar)
                        {
                            square.Add(board[i][j]);
                        }
                    }
                }
                if (square.Count != 0)
                {
                    HashSet<char> set = new HashSet<char>(square);
                    if (square.Count != set.Count)
                    {
                        return false;
                    }
                }
                square.Clear();
            }
            return true;
        }
        #region скопировано с leetCode
        private bool bestSolution(char[][] board)
        {
            int[] rowBitSums = new int[9];
            int[] colBitSums = new int[9];
            int[] squareBitSums = new int[9];

            for (int iRow = 0; iRow < 9; iRow++)
            {
                for (int iCol = 0; iCol < 9; iCol++)
                {
                    int iSquare = (3 * (iRow / 3)) + (iCol / 3);
                    char c = board[iRow][iCol];
                    if (c >= '1' && c <= '9')
                    {
                        int value = (int)(c - '1') + 1;
                        if (!AddToBitSum(ref rowBitSums[iRow], value))
                        {
                            return false;
                        }

                        if (!AddToBitSum(ref colBitSums[iCol], value))
                        {
                            return false;
                        }

                        if (!AddToBitSum(ref squareBitSums[iSquare], value))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private bool AddToBitSum(ref int bitSum, int value)
        {
            int origSum = bitSum;
            bitSum = bitSum ^ (1 << value);
            return bitSum > origSum;
        }
        #endregion
    }
}
