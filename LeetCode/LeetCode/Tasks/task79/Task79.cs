using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task79
{
    /*
     79. Поиск по слову
    Учитывая m x n сетку символов board и строку word, верните true если word она существует в сетке.
    Слово может быть составлено из букв последовательно расположенных ячеек, где соседние ячейки расположены по горизонтали или вертикали. Одна и та же ячейка с буквой не может использоваться более одного раза.
     Ограничения:
        m == board.length
        n = board[i].length
        1 <= m, n <= 6
        1 <= word.length <= 15
        board и word состоит только из строчных и заглавных английских букв.
     https://leetcode.com/problems/word-search/description/
     */
    public class Task79 : InfoBasicTask
    {
        public Task79(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            char[][] board = new char[][] {
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'C', 'S' },
                new char[] { 'A', 'D', 'E', 'E' }
            }; 
            printTwoDimensionalArray(board);
            string word = "SEE";
            Console.WriteLine($"Слово для поиска: \"{word}\"");
            if (isValid(board, word))
            {
                Console.WriteLine(exist(board, word) ? "Возможно составить слово" : "Невозможно составить слово");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(char[][] board, string word)
        {
            int m = board.Length;
            if (m < 1 || m > 6)
            {
                return false;
            }
            int n = board[0].Length;
            foreach (char[] row in board)
            {
                if (row.Length != n)
                {
                    return false;
                }
            }
            if (word.Length < 1 || word.Length > 15)
            {
                return false;
            }
            foreach (char[] row in board)
            {
                foreach (char item in row)
                {
                    if (!((item >= 'a' && item <= 'z') || (item >= 'A' && item <= 'Z')))
                    {
                        return false;
                    }
                }
            }
            foreach (char item in word)
            {
                if (!((item >= 'a' && item <= 'z') || (item >= 'A' && item <= 'Z')))
                {
                    return false;
                }
            }
            return true;
        }
        private bool exist(char[][] board, string word)
        {
            int countRows = board.Length;
            int countColumns = board[0].Length;
            bool[][] usedCellsOnBoard = new bool[board.Length][];
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                usedCellsOnBoard[indexRow] = new bool[countColumns];
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    usedCellsOnBoard[indexRow][indexColumn] = false;
                }
            }
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    if (board[indexRow][indexColumn] == word[0])
                    {
                        List<int[]> previousPositions = new List<int[]>() { new int[] { indexRow, indexColumn } };
                        usedCellsOnBoard[indexRow][indexColumn] = true;
                        bool res = recursive(board, usedCellsOnBoard, new int[] { indexRow, indexColumn }, 1, word, countRows, countColumns);
                        if (res)
                        {
                            return true;
                        }
                        usedCellsOnBoard[indexRow][indexColumn] = false;
                    }
                }
            }
            return false;
        }
        private bool recursive(char[][] board, bool[][] usedCells, int[] currentPosition, int currentIndex, string finalWord, int countRows, int countColumns)
        {
            if (currentIndex == finalWord.Length)
            {
                return true;
            }
            char nextChar = finalWord[currentIndex];
            int[][] nextPositions = new int[][] { 
                new int[] {currentPosition[0], currentPosition[1] - 1 },
                new int[] {currentPosition[0], currentPosition[1] + 1 },
                new int[] {currentPosition[0]-1, currentPosition[1] },
                new int[] { currentPosition[0]+1, currentPosition[1]},
            };
            foreach (int[] arr in nextPositions)
            {
                int nextPositionX = arr[0];
                int nextPositionY = arr[1];
                if (nextPositionX >= 0 && nextPositionX < countRows && nextPositionY >= 0 && nextPositionY < countColumns)
                {
                    if (!usedCells[nextPositionX][nextPositionY])
                    {
                        char currentChar = board[nextPositionX][nextPositionY];
                        if (currentChar == nextChar)
                        {
                            usedCells[nextPositionX][nextPositionY] = true;
                            bool res = recursive(board,usedCells, new int[] { nextPositionX, nextPositionY } , currentIndex + 1, finalWord, countRows, countColumns);
                            if (res)
                            {
                                return res;
                            }
                            usedCells[nextPositionX][nextPositionY] = false;
                        }
                    }
                }  
            }
            return false;
        }
    }
}
