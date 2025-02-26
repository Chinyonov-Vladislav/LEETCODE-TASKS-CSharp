using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2283
{
    /*
     2283. Проверьте, совпадает ли количество цифр в числе с их значением
    Вам дана строка с нулевой индексацией num длиной n, состоящая из n цифр.
    Вернуть true значение, если для каждого индекса i в диапазоне 0 <= i < nцифра i встречается num[i] раз в num, в противном случае вернуть false.
    Ограничения:
        n == num.length
        1 <= n <= 10
        num состоит из цифр.
     https://leetcode.com/problems/check-if-number-has-equal-digit-count-and-digit-value/description/
     */
    public class Task2283 : InfoBasicTask
    {
        public Task2283(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string number = "1210";
            Console.WriteLine($"Исходное число в строковом формате: \"{number}\"");
            Console.WriteLine(digitCount(number) ? "Для каждого индекса i в диапазоне 0 <= i < n цифра i встречается num[i] раз в num" : "Не для каждого индекса i в диапазоне 0 <= i < n цифра i встречается num[i] раз в num");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool digitCount(string num)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < num.Length; i++)
            {
                if (dict.ContainsKey(num[i]))
                {
                    dict[num[i]]++;
                }
                else
                {
                    dict.Add(num[i], 1);
                }
            }
            for (int i = 0; i < num.Length; i++)
            {
                char ch = (char)(i + '0');
                int count = num[i] - '0';
                if (dict.ContainsKey(ch))
                {
                    if (count != dict[ch])
                    {
                        return false;
                    }
                }
                else
                {
                    if (count != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
