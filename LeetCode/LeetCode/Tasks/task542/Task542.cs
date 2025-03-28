using LeetCode.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task542
{
    /*
     542. 01 Матрица
    Учитывая m x n двоичную матрицу mat, верните расстояние до ближайшей 0 для каждой ячейки.
    Расстояние между двумя ячейками, имеющими общее ребро, равно 1.
    Ограничения:
        m == mat.length
        n == mat[i].length
        1 <= m, n <= 10^4
        1 <= m * n <= 10^4
        mat[i][j] является либо 0, либо 1.
        Есть по крайней мере один 0 в mat.
    https://leetcode.com/problems/01-matrix/description/
     */
    public class Task542 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Nothing = 0,
            Stupid = 1,
            BFS_first_type = 2,
            BFS_second_type = 3,
            All = 4
        }
        public Task542(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] mat = new int[][] {
                new int[] { 0,0,0 },
                new int[] { 0,1,0 },
                new int[] { 1,1,1 },
            };
            printTwoDimensionalArray(mat, "Исходная двумерная матрица");
            if (isValid(mat))
            {
                int[][] res = null;
                TypeSolution typeSolution = askUserTypeSolution();
                switch (typeSolution)
                {
                    case TypeSolution.Stupid:
                        res =  updateMatrix(mat);
                        printTwoDimensionalArray(res, "Полученная результирующая двумерная матрица с помощью неоптимального метода");
                        break;
                    case TypeSolution.BFS_first_type:
                        res = updateMatrixSecondMethod(mat);
                        printTwoDimensionalArray(res, "Полученная результирующая двумерная матрица с помощью применения BFS (поиска в ширину) для каждой единицы в матрице");
                        break;
                    case TypeSolution.BFS_second_type:
                        res = updateMatrixThirdMethod(mat);
                        printTwoDimensionalArray(res, "Полученная результирующая двумерная матрица с помощью применения оптимизированной версии с использованием мульти-источникового BFS (Multi-Source BFS)");
                        break;
                    case TypeSolution.All:
                        res = updateMatrix(mat);
                        printTwoDimensionalArray(res, "Полученная результирующая двумерная матрица с помощью неоптимального метода");
                        res = updateMatrixSecondMethod(mat);
                        printTwoDimensionalArray(res, "Полученная результирующая двумерная матрица с помощью применения BFS (поиска в ширину) для каждой единицы в матрице");
                        res = updateMatrixThirdMethod(mat);
                        printTwoDimensionalArray(res, "Полученная результирующая двумерная матрица с помощью применения оптимизированной версии с использованием мульти-источникового BFS (Multi-Source BFS)");
                        break;
                }
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
        private bool isValid(int[][] mat)
        {
            int countZeros = 0;
            int lowLimitDimension = 1;
            int highLimitDimension = (int)Math.Pow(10,4);
            int countRows = mat.Length;
            if (countRows < lowLimitDimension || countRows > highLimitDimension)
            {
                return false;
            }
            int countColumns = mat[0].Length;
            foreach (int[] row in mat)
            {
                if (row.Length < lowLimitDimension || row.Length > highLimitDimension || row.Length!=countColumns)
                {
                    return false;
                }
                foreach (int val in row)
                {
                    if (val < 0 || val > 1)
                    {
                        return false;
                    }
                    if (val == 0)
                    {
                        countZeros++;
                    }
                }
            }
            int prod = countRows * countColumns;
            if (prod < lowLimitDimension || prod > highLimitDimension)
            {
                return false;
            }
            if (countZeros == 0)
            {
                return false;
            }
            return true;
        }
        private int[][] updateMatrixThirdMethod(int[][] mat)
        {
            int countRows = mat.Length;
            int countCols = mat[0].Length;
            int[][] res = new int[countRows][];
            bool[][] visitedCells = new bool[countRows][];
            for (int i = 0; i < countRows; i++)
            {
                visitedCells[i] = new bool[countCols];
                res[i] = new int[countCols];
            }
            Queue<int[]> queue = new Queue<int[]>();
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countCols; indexColumn++)
                {
                    if (mat[indexRow][indexColumn] == 0)
                    {
                        queue.Enqueue(new int[] { indexRow, indexColumn, 0 });
                    }
                }
            }
            while (queue.Count > 0)
            {
                int[] currentCoordinate = queue.Dequeue();
                int indexRowCell = currentCoordinate[0];
                int indexColumnCell = currentCoordinate[1];
                int currentLevel = currentCoordinate[2];
                
                if (mat[indexRowCell][indexColumnCell] == 1 && !visitedCells[indexRowCell][indexColumnCell])
                {
                    res[indexRowCell][indexColumnCell] = currentCoordinate[2];
                }
                visitedCells[indexRowCell][indexColumnCell] = true;
                List<int[]> nextCells = new List<int[]> {
                                new int[] { indexRowCell + 1,indexColumnCell, currentLevel+1 },
                                new int[] { indexRowCell, indexColumnCell + 1, currentLevel+1 },
                                new int[] { indexRowCell - 1,indexColumnCell, currentLevel+1 },
                                new int[] { indexRowCell, indexColumnCell - 1, currentLevel + 1 }
                };
                foreach (int[] nextCell in nextCells)
                {
                    int nextIndexRow = nextCell[0];
                    int nextIndexColumn = nextCell[1];
                    int nextLevel = nextCell[2];
                    if (nextIndexRow >= 0 && nextIndexRow < countRows && nextIndexColumn >= 0 && nextIndexColumn < countCols)
                    {
                        if (!visitedCells[nextIndexRow][nextIndexColumn])
                        {
                            queue.Enqueue(new int[] { nextIndexRow, nextIndexColumn, nextLevel });
                        }
                    }
                }
            }
            return res;
        }

        private int[][] updateMatrixSecondMethod(int[][] mat)
        {
            int countRows = mat.Length;
            int countCols = mat[0].Length;
            int[][] res = new int[countRows][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new int[countCols];
            }
            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countCols; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        res[i][j] = 0;
                    }
                    else
                    {

                        bool[][] visitedCells = new bool[countRows][];
                        for (int index = 0; index < countRows; index++)
                        {
                            visitedCells[index] = new bool[countCols];
                        }
                        int level = 1;
                        Queue<int[]> queue = new Queue<int[]>();
                        queue.Enqueue(new int[] { i, j });
                        queue.Enqueue(new int[] { -1, -1 });
                        while (queue.Count > 0)
                        {
                            int[] currentCoordinate = queue.Dequeue();
                            if (currentCoordinate[0] == -1 && currentCoordinate[1] == -1)
                            {
                                level++;
                                if (queue.Count != 0)
                                {
                                    queue.Enqueue(new int[] { -1, -1 });
                                }
                                continue;
                            }
                            visitedCells[currentCoordinate[0]][currentCoordinate[1]] = true;
                            List<int[]> nextCells = new List<int[]> {
                                new int[] { currentCoordinate[0] + 1,currentCoordinate[1] },
                                new int[] { currentCoordinate[0], currentCoordinate[1] + 1 },
                                new int[] { currentCoordinate[0] - 1,currentCoordinate[1] },
                                new int[] { currentCoordinate[0], currentCoordinate[1] - 1 }
                            };
                            foreach (int[] nextCell in nextCells)
                            {
                                int indexRow = nextCell[0];
                                int indexColumn = nextCell[1];
                                if (indexRow >= 0 && indexRow < countRows && indexColumn >= 0 && indexColumn < countCols)
                                {
                                    if (mat[indexRow][indexColumn] == 0)
                                    {
                                        res[i][j] = level;
                                        break;
                                    }
                                    else
                                    {
                                        if (!visitedCells[indexRow][indexColumn])
                                        {
                                            queue.Enqueue(new int[] { indexRow, indexColumn });
                                        }
                                    }
                                }
                            }
                            if (res[i][j] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return res;
        }
        private int[][] updateMatrix(int[][] mat)
        {
            int countRows = mat.Length;
            int countCols = mat[0].Length;
            int[][] res = new int[countRows][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new int[countCols];
            }
            List<int[]> coordinatesZero = new List<int[]>();
            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countCols; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        coordinatesZero.Add(new int[] { i, j });
                    }
                }
            }
            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countCols; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        res[i][j] = 0;
                    }
                    else
                    {
                        int min = int.MaxValue;
                        foreach (int[] coordinate in coordinatesZero)
                        {
                            int currentCoordinateRow = i;
                            int currentCoordinateColumn = j;
                            int countStep = 0;
                            while (true)
                            {
                                countStep++;
                                if (currentCoordinateRow != coordinate[0])
                                {
                                    if (currentCoordinateRow > coordinate[0])
                                    {
                                        currentCoordinateRow--;
                                    }
                                    else
                                    {
                                        currentCoordinateRow++;
                                    }
                                }
                                else
                                {
                                    if (currentCoordinateColumn != coordinate[1])
                                    {
                                        if (currentCoordinateColumn > coordinate[1])
                                        {
                                            currentCoordinateColumn--;
                                        }
                                        else
                                        {
                                            currentCoordinateColumn++;
                                        }
                                    }
                                }
                                if (currentCoordinateRow == coordinate[0] && currentCoordinateColumn == coordinate[1])
                                {
                                    break;
                                }
                            }
                            if (countStep < min)
                            {
                                min = countStep;
                            }
                        }
                        res[i][j] = min;
                    }
                }
            }
            return res;
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Неоптимальный (Вычисление расстояние от каждой клетки с 1 до ближайшего нуля)\n" +
                    "2 - BFS (поиска в ширину) для каждой единицы в матрице \n" +
                    "3 - Оптимизированная версия с использованием мульти-источникового BFS (Multi-Source BFS) \n" +
                    "4 - Протестировать все решения\n" +
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 4)
                    {
                        throw new FormatException();
                    }
                    switch (choiceUser)
                    {
                        case 0:
                            return TypeSolution.Nothing;
                        case 1:
                            return TypeSolution.Stupid;
                        case 2:
                            return TypeSolution.BFS_first_type;
                        case 3:
                            return TypeSolution.BFS_second_type;
                        case 4:
                            return TypeSolution.All;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
        }
    }
}
