using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2496
{
    /*
     2496. Максимальное значение строки в массиве
    Значение буквенно - цифровой строки может быть определено как:
        Числовое представление строки в системе счисления 10, если она состоит только из цифр.
        В противном случае - длина строки.
    Учитывая массив strs буквенно-цифровых строк, верните максимальное значение любой строки в strs.
    Ограничения:
        1 <= strs.length <= 100
        1 <= strs[i].length <= 9
        strs[i] состоит только из строчных английских букв и цифр.
    https://leetcode.com/problems/maximum-value-of-a-string-in-an-array/description/
     */
    public class Task2496 : InfoBasicTask
    {
        public Task2496(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] strs = new string[] { "alic3", "bob", "3", "4", "00000" };
            printArray(strs);
            if (isValid(strs))
            {
                int max = maximumValue(strs);
                Console.WriteLine($"Максимальное значение = {max}");
            }
            else
            {
                Console.WriteLine("Невалидные исходные данные!");
            }

        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string[] strs)
        {
            if (strs.Length < 1 || strs.Length > 100)
            {
                return false;
            }
            foreach (string str in strs) {
                if (str.Length < 1 || str.Length > 9)
                {
                    return false;
                }
                foreach (char c in str)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int maximumValue(string[] strs)
        {
            int max = Int32.MinValue;
            foreach (string str in strs) {
                bool isOnlyDigits = true;
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]))
                    {
                        isOnlyDigits = false;
                        break;
                    }
                }
                if (!isOnlyDigits)
                {
                    if (str.Length > max)
                    {
                        max = str.Length;
                    }
                }
                else
                {
                    int value = Int32.Parse(str);
                    if(value > max)
                    {
                        max = value;
                    }
                }
            }
            return max;
        }
    }
}
