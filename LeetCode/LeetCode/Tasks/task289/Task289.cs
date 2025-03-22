using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task289
{
    /*
     289. Игра в жизнь
    Согласно статье в Википедии: «Игра жизни, также известная просто как Жизнь, — это клеточный автомат, разработанный британским математиком Джоном Хортоном Конвеем в 1970 году».
    Поле состоит из m x n ячеек, каждая из которых имеет начальное состояние: живая (обозначается 1) или мёртвая (обозначается 0). Каждая ячейка взаимодействует со своими восемью соседями (по горизонтали, вертикали и диагонали) по следующим четырём правилам (взятым из вышеупомянутой статьи в Википедии):
        Любая живая клетка, у которой меньше двух живых соседей, умирает, как будто из-за перенаселения.
        Любая живая клетка с двумя или тремя живыми соседями продолжает жить в следующем поколении.
        Любая живая клетка, у которой более трёх живых соседей, погибает, как будто из-за перенаселения.
        Любая мёртвая клетка, у которой ровно три живые соседки, становится живой клеткой, как будто размножившись.
    Следующее состояние доски определяется путём одновременного применения приведённых выше правил к каждой ячейке в текущем состоянии m x n сетки board. В этом процессе рождение и смерть происходят одновременно.
    Учитывая текущее состояние board, обновитеboard так, чтобы оно отражало следующее состояние.
    Обратите внимание, что вам не нужно ничего возвращать.
    Ограничения:
        m == board.length
        n == board[i].length
        1 <= m, n <= 25
        board[i][j] является 0 или 1.
    https://leetcode.com/problems/game-of-life/description/
     */
    public class Task289 : InfoBasicTask
    {
        public Task289(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] { 
                new int[] { 0,1,0 },
                new int[] { 0,0,1 }, 
                new int[] { 1,1,1 },
                new int[] { 0, 0, 0 }
            };
            printTwoDimensionalArray(grid, "Исходная двумерная матрица");
            if (isValid(grid))
            {
                gameOfLife(grid);
                printTwoDimensionalArray(grid, "Следующее состояние двумерной матрицы");
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
        private bool isValid(int[][] grid)
        {
            int lowLimitSizeDimension = 1;
            int highLimitSizeDimension = 25;
            int countRows = grid.Length;
            if (countRows < lowLimitSizeDimension || countRows > highLimitSizeDimension)
            {
                return false;
            }
            int countColumns = grid[0].Length;
            foreach (int[] row in grid)
            {
                if (row.Length != countColumns || row.Length < lowLimitSizeDimension || row.Length > highLimitSizeDimension)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < 0 || item > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void gameOfLife(int[][] board)
        {
            int countRows = board.Length;
            int countColumns = board[0].Length;
            int[][] copyBoard = new int[board.Length][];
            for (int i = 0; i < copyBoard.Length; i++)
            {
                copyBoard[i] = new int[countColumns];
                for (int j = 0; j < countColumns; j++)
                {
                    copyBoard[i][j] = board[i][j];
                }
            }
            for (int indexRow = 0; indexRow < copyBoard.Length; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    int numberLivingNeighbors = 0;
                    if (indexRow - 1 >= 0 && indexRow - 1 < countRows && indexColumn - 1 >= 0 && indexColumn - 1 < countColumns)
                    {
                        if (copyBoard[indexRow - 1][indexColumn - 1] == 1)
                        {
                            numberLivingNeighbors++;
                        }
                    }
                    if (indexRow - 1 >= 0 && indexRow - 1 < countRows)
                    {
                        if (copyBoard[indexRow - 1][indexColumn] == 1)
                        {
                            numberLivingNeighbors++;
                        }
                    }
                    if (indexRow - 1 >= 0 && indexRow - 1 < countRows && indexColumn + 1 >= 0 && indexColumn + 1 < countColumns)
                    {
                        if (copyBoard[indexRow - 1][indexColumn + 1] == 1)
                        {
                            numberLivingNeighbors++;
                        }
                    }
                    if  (indexColumn - 1 >= 0 && indexColumn - 1 < countColumns)
                    {
                        if (copyBoard[indexRow][indexColumn - 1] == 1)
                        {
                            numberLivingNeighbors++;
                        }
                    }
                    if (indexColumn + 1 >= 0 && indexColumn + 1 < countColumns)
                    {
                        if (copyBoard[indexRow][indexColumn + 1] == 1)
                        {
                            numberLivingNeighbors++;
                        }
                    }
                    if (indexRow + 1 >= 0 && indexRow + 1 < countRows && indexColumn - 1 >= 0 && indexColumn - 1 < countColumns)
                    {
                        if (copyBoard[indexRow + 1][indexColumn - 1] == 1)
                        {
                            numberLivingNeighbors++;
                        }
                    }
                    if (indexRow + 1 >= 0 && indexRow + 1 < countRows)
                    {
                        if (copyBoard[indexRow + 1][indexColumn] == 1)
                        {
                            numberLivingNeighbors++;
                        }
                    }
                    if (indexRow + 1 >= 0 && indexRow + 1 < countRows && indexColumn + 1 >= 0 && indexColumn + 1 < countColumns)
                    {
                        if (copyBoard[indexRow + 1][indexColumn + 1] == 1)
                        {
                            numberLivingNeighbors++;
                        }
                    }
                    if (board[indexRow][indexColumn] == 1)
                    {
                        if (numberLivingNeighbors < 2)
                        {
                            board[indexRow][indexColumn] = 0;
                        }
                        else if (numberLivingNeighbors >= 2 && numberLivingNeighbors <= 3)
                        {
                            board[indexRow][indexColumn] = 1;
                        }
                        else
                        {
                            board[indexRow][indexColumn] = 0;
                        }
                    }
                    else
                    {
                        if (numberLivingNeighbors == 3)
                        {
                            board[indexRow][indexColumn] = 1;
                        }
                    }
                }
            }
        }
    }
}
