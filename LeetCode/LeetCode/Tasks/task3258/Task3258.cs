using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3258
{
    /*
     3258. Подсчитайте количество подстрок, удовлетворяющих ограничению K
    Вам дается двоичная строка s и целое число k.
    Двоичная строка удовлетворяет k-ограничению, если выполняется любое из следующих условий:
        Количество 0 в строке не превышает k.
        Количество 1 в строке не превышает k.
    Верните целое число, обозначающее количество подстрок в s, которые удовлетворяют k-ограничению.
    Ограничения:
        1 <= s.length <= 50 
        1 <= k <= s.length
        s[i] является либо '0', либо '1'.
    https://leetcode.com/problems/count-substrings-that-satisfy-k-constraint-i/description/
     */
    public class Task3258 : InfoBasicTask
    {
        public Task3258(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "10101";
            int k = 1;
            Console.WriteLine($"Исходная строка: \"{s}\"\nЗначение переменной ограничения = {k}");
            if (isValid(s, k))
            {
                int count = countKConstraintSubstrings(s, k);
                Console.WriteLine($"Количество подстрок, соответствующие ограничению: количество единиц не более чем {k} и количество нулей не более чем {k} = {count}");
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
        private bool isValid(string s, int k)
        {
            if (s.Length < 1 || s.Length > 50)
            {
                return false;
            }
            if (k < 1 || k > s.Length)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }
        private int countKConstraintSubstrings(string s, int k)
        {
            int count = 0;
            int length = 1;
            while (length != s.Length + 1)
            {
                for (int i = 0; i <= s.Length - length; i++)
                {
                    string subStr = s.Substring(i, length);
                    int countOne = 0;
                    int countZero = 0;
                    int left = 0;
                    int right = subStr.Length-1;
                    while (left <= right)
                    {
                        if (left == right)
                        {
                            if (subStr[left] == '0')
                            {
                                countZero++;
                            }
                            else
                            {
                                countOne++;
                            }
                        }
                        else
                        {
                            if (subStr[left] == '0')
                            {
                                countZero++;
                            }
                            else
                            {
                                countOne++;
                            }
                            if (subStr[right] == '0')
                            {
                                countZero++;
                            }
                            else
                            {
                                countOne++;
                            }
                        }
                        left++;
                        right--;
                    }
                    if (countOne <= k || countZero <= k)
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine(subStr);
                    }
                }
                length++;
            }
            return count;
        }
    }
}
