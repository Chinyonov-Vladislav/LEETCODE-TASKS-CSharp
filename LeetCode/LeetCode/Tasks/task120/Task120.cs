using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task120
{
    /*
     120. Треугольник
    Учитывая массив triangle, верните минимальную сумму пути сверху вниз.
    На каждом шаге вы можете перейти к соседнему числу в строке ниже. Если говорить более формально, то если вы находитесь на позиции i в текущей строке, вы можете перейти либо на позицию i в текущей строке, либо на позицию i + 1 в следующей строке.
    Ограничения:
        1 <= triangle.length <= 200
        triangle[0].length == 1
        triangle[i].length == triangle[i - 1].length + 1
        -10^4 <= triangle[i][j] <= 10^4
    https://leetcode.com/problems/triangle/description/
     */
    public class Task120 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Recursive = 1,
            Fast = 2
        }
        public Task120(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<IList<int>> triangle = new List<IList<int>>() {
                new List<int>() { -1 },
                new List<int>() { 2,3 },
                new List<int>() { 1,-1,-3 }
            };
            printIListIListInt(triangle);
            if (isValid(triangle))
            {
                int choiceUserTypeSolution = askUserTypeSolution();
                if (choiceUserTypeSolution > 0)
                {
                    int min = minimumTotal(triangle, choiceUserTypeSolution == 1 ? TypeSolution.Recursive : TypeSolution.Fast);
                    Console.WriteLine($"Минимальная сумма пути от вершины треугольника к основанию = {min}");
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
        private bool isValid(IList<IList<int>> triangle)
        {
            if (triangle.Count < 1 || triangle.Count > 200)
            {
                return false;
            }
            if (triangle[0].Count != 1)
            {
                return false;
            }
            for (int indexRow = 1; indexRow < triangle.Count; indexRow++)
            {
                if (triangle[indexRow].Count != triangle[indexRow - 1].Count + 1)
                {
                    return false;
                }
            }
            int lowLimit = -1* (int)Math.Pow(10,4);
            int highLimit = (int)Math.Pow(10,4);
            foreach (IList<int> row in triangle)
            {
                foreach (int item in row)
                {
                    if (item < lowLimit || item > highLimit)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int minimumTotal(IList<IList<int>> triangle, TypeSolution type)
        {
            if (type == TypeSolution.Recursive)
            {
                int min = Int32.MaxValue;
                int sum = triangle[0][0];
                recursive(triangle, ref min, 1, 0, sum);
                return min;
            }
            return minimumTotal(triangle);
        }
        private int minimumTotal(IList<IList<int>> triangle)
        {
            for (int indexRow = triangle.Count - 2; indexRow >= 0; indexRow--)
            {
                for (int indexItem = 0; indexItem < triangle[indexRow].Count; indexItem++)
                {
                    triangle[indexRow][indexItem] += Math.Min(triangle[indexRow + 1][indexItem], triangle[indexRow+1][indexItem + 1]);
                }
            }
            return triangle[0][0];
        }
        private void recursive(IList<IList<int>> triangle, ref int min, int indexCurrentRow, int indexItemInPreviousRow, int currentSum)
        {
            if (indexCurrentRow == triangle.Count)
            {
                if (min > currentSum)
                {
                    min = currentSum;
                }
            }
            else
            {
                recursive(triangle, ref min, indexCurrentRow + 1, indexItemInPreviousRow, currentSum + triangle[indexCurrentRow][indexItemInPreviousRow]);
                recursive(triangle, ref min, indexCurrentRow + 1, indexItemInPreviousRow + 1, currentSum + triangle[indexCurrentRow][indexItemInPreviousRow + 1]);
            }
        }
        private int askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Рекурсивный\n" +
                    "2 - Быстрый\n" +
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 2)
                    {
                        throw new FormatException();
                    }
                    return choiceUser;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
        }
    }
}
