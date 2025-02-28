using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2418
{
    /*
     2418. Рассортируйте людей
    Вам дан массив строк names и массив heights, состоящий из различных положительных целых чисел. Оба массива имеют длину n.
    Для каждого индекса inames[i] и heights[i] обозначьте имя и рост ith человека.
    Верните names отсортированные по убыванию роста людей.
    Ограничения:
        n == names.length == heights.length
        1 <= n <= 103
        1 <= names[i].length <= 20
        1 <= heights[i] <= 105
        names[i] состоит из строчных и заглавных английских букв.
        Все значения heights различны.
    https://leetcode.com/problems/sort-the-people/description/
     */
    public class Task2418 : InfoBasicTask
    {
        public Task2418(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] names = new string[] { "Mary", "John", "Emma" };
            int[] heights = new int[] { 180, 165, 170 };
            printArray(names, "Массив имён: ");
            printArray(heights, "Массив роста: ");
            if (isValid(names, heights))
            {
                string[] result = sortPeople(names, heights);
                printArray(result, "Массив имен людей, отсортированный по убыванию роста: ");
            }
            else
            {
                Console.WriteLine($"Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string[] names, int[] heights)
        {
            if (names.Length != heights.Length)
            {
                return false;
            }
            int n = names.Length;
            int upperLimit = (int)Math.Pow(10, 3);
            if (n < 1 || n > upperLimit)
            {
                return false;
            }
            foreach (string name in names)
            {
                if (name.Length < 1 || name.Length > 20)
                {
                    return false;
                }
            }
            upperLimit = (int)Math.Pow(10, 5);
            foreach (int item in heights)
            {
                if (item < 1 || item > upperLimit)
                {
                    return false;
                }
            }
            HashSet<int> set = new HashSet<int>(heights);
            if (set.Count != heights.Length)
            {
                return false;
            }
            return true;
        }
        private string[] sortPeople(string[] names, int[] heights)
        {
            string[] result = new string[names.Length];
            Dictionary<int, string>dict = new Dictionary<int, string>();
            for (int i = 0; i < names.Length; i++)
            {
                dict.Add(heights[i], names[i]);
            }
            int index = 0;
            var ordered = dict.OrderByDescending(x => x.Key);
            foreach (var pair in ordered)
            {
                result[index] = pair.Value;
                index++;
            }
            return result;
        }
    }
}
