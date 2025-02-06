using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1399
{
    /*
     1399. Подсчитайте самую большую группу
    Вам дается целое число n.
    Каждое число от 1 до n группируется по сумме его цифр.
    Возвращает количество групп, которые имеют наибольший размер.
    https://leetcode.com/problems/count-largest-group/description/
    */
    public class Task1399 : InfoBasicTask
    {
        public Task1399(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 13;
            Console.WriteLine($"Значение n = {n}");
            int countGroups = countLargestGroup(n);
            Console.WriteLine($"Количество групп по сумме цифр, имеющих наибольшей размер = {countGroups}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countLargestGroup(int n)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i = 1; i <= n; i++)
            {
                int currentValue = i;
                int sumOfDigits = 0;
                while (currentValue != 0)
                {
                    int digit = currentValue % 10;
                    sumOfDigits += digit;
                    currentValue /= 10;
                }
                if (dict.ContainsKey(sumOfDigits))
                {
                    dict[sumOfDigits].Add(i);
                }
                else
                {
                    dict.Add(sumOfDigits, new List<int>() { i });
                }
            }
            int max = 0;
            foreach (var pair in dict)
            {
                if (pair.Value.Count > max)
                {
                    max = pair.Value.Count;
                }
            }
            return dict.Where(x => x.Value.Count == max).Count();
        }
    }
}
