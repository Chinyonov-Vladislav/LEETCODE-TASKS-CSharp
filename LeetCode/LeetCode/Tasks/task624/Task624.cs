using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task624
{
    /*
     624. Максимальное расстояние в массивах
    Вам дан m arrays массив, в котором каждый элемент отсортирован в порядке возрастания.
    Вы можете выбрать два целых числа из двух разных массивов (из каждого массива выбирается по одному числу) и вычислить расстояние. Мы определяем расстояние между двумя целыми числами a и b как их абсолютную разницу |a - b|.
    Верните максимальное расстояние.
    Ограничения:
        m == arrays.length
        2 <= m <= 10^5
        1 <= arrays[i].length <= 500
        -10^4 <= arrays[i][j] <= 10^4
        arrays[i] сортируется в порядке возрастания.
        Во всех массивах будет не более 10^5 целых чисел.
    https://leetcode.com/problems/maximum-distance-in-arrays/description/
     */
    public class Task624 : InfoBasicTask
    {
        private enum TypeSolution
        {
            None = 0,
            BruteForce = 1,
            Greedy = 2,
            Both = 3
        }
        public Task624(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<IList<int>> arrays = new List<IList<int>>() {
                new List<int>() {1,2,3 },
                new List<int>() {4,5 },
                new List<int> { 1, 2, 3 }
            };
            Console.WriteLine($"Исходный список списков целых чисел");
            printIListIListInt(arrays);
            if (isValid(arrays))
            {
                int res = 0;
                TypeSolution typeSolution = askUserTypeSolution();
                switch (typeSolution)
                {
                    case TypeSolution.BruteForce:
                        res = maxDistance(arrays);
                        Console.WriteLine($"Метод перебора: наибольшее расстояние между двумя элементами различных списков = {res}");
                        break;
                    case TypeSolution.Greedy:
                        res = maxDistanceSecondMethod(arrays);
                        Console.WriteLine($"Жадный алгоритм: наибольшее расстояние между двумя элементами различных списков = {res}");
                        break;
                    case TypeSolution.Both:
                        res = maxDistance(arrays);
                        Console.WriteLine($"Метод перебора: наибольшее расстояние между двумя элементами различных списков = {res}");
                        res = maxDistanceSecondMethod(arrays);
                        Console.WriteLine($"Жадный алгоритм: наибольшее расстояние между двумя элементами различных списков = {res}");
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
        private bool isValid(IList<IList<int>> arrays)
        {
            int lowLimitLengthArrays = 2;
            int highLimitLengthArrays = (int)Math.Pow(10, 5);
            int lowLimitLengthArray = 1;
            int highLimitLengthArray = 500;
            int lowLimitArrayValue = -1 * (int)Math.Pow(10, 4);
            int highLimitArrayValue = (int)Math.Pow(10, 4);
            int highLimitTotalCountVals = (int)Math.Pow(10, 5);
            int totalCountVals = 0;
            if (arrays.Count < lowLimitLengthArrays || arrays.Count > highLimitLengthArrays)
            {
                return false;
            }
            foreach (IList<int> arr in arrays)
            {
                if (arr.Count < lowLimitLengthArray || arr.Count > highLimitLengthArray)
                {
                    return false;
                }
                totalCountVals += arr.Count;
                foreach (int val in arr)
                {
                    if (val < lowLimitArrayValue || val > highLimitArrayValue)
                    {
                        return false;
                    }
                }
                if (arr.Count > 1)
                {
                    for (int i = 1; i < arr.Count; i++)
                    {
                        if (arr[i] < arr[i - 1])
                        {
                            return false;
                        }
                    }
                }
            }
            if (totalCountVals > highLimitTotalCountVals)
            {
                return false;
            }
            return true;
        }

        private int maxDistanceSecondMethod(IList<IList<int>> arrays)
        {
            int minValue = arrays[0][0];
            int maxValue = arrays[0][arrays[0].Count - 1];
            int distance = 0;
            for (int i = 1; i < arrays.Count; i++)
            {
                int minLocalValue = arrays[i][0];
                int maxLocalValue = arrays[i][arrays[i].Count - 1];
                int firstCandidate = Math.Abs(minValue - maxLocalValue);
                int secondCandidate = Math.Abs(minLocalValue - maxValue);
                distance = Math.Max(distance, Math.Max(firstCandidate, secondCandidate));
                minValue = Math.Min(minValue, minLocalValue);
                maxValue = Math.Max(maxValue, maxLocalValue);
            }
            return distance;
        }

        private int maxDistance(IList<IList<int>> arrays)
        {
            int max = int.MinValue;
            for (int i = 0; i < arrays.Count - 1; i++)
            {
                int minFromFirstArr = arrays[i][0];
                int maxFromFirstArr = arrays[i][arrays[i].Count - 1];
                for (int j = i + 1; j < arrays.Count; j++)
                {
                    int minFromSecondArr = arrays[j][0];
                    int maxFromSecondArr = arrays[j][arrays[j].Count - 1];
                    int firstCandidate = Math.Abs(minFromFirstArr - maxFromSecondArr);
                    int secondCandidate = Math.Abs(maxFromFirstArr - minFromSecondArr);
                    if (firstCandidate > max)
                    {
                        max = firstCandidate;
                    }
                    if (secondCandidate > max)
                    {
                        max = secondCandidate;
                    }
                }
            }
            return max;
        }

        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Метод перебора\n" +
                    "2 - Жадный алгоритм\n" +
                    "3 - Протестировать оба решения\n" +
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 3)
                    {
                        throw new FormatException();
                    }
                    switch (choiceUser)
                    {
                        case 0:
                            return TypeSolution.None;
                        case 1:
                            return TypeSolution.BruteForce;
                        case 2:
                            return TypeSolution.Greedy;
                        case 3:
                            return TypeSolution.Both;
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
