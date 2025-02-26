using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2264
{
    /*
     2264. Самое большое трёхзначное число в строке
    Вам дана строка num, представляющая собой большое целое число. Целое число хорошо, если оно удовлетворяет следующим условиям:
        Это подстрока num с длиной 3.
        Он состоит только из одной уникальной цифры.
    Возвращает максимально допустимое целое число в виде строки или пустой строки, "" если такого целого числа не существует.
    Примечание:
        Подстрока - это непрерывная последовательность символов внутри строки.
        В могут быть начальные нулиnum или хорошее целое число.
    https://leetcode.com/problems/largest-3-same-digit-number-in-string/description/
     */
    public class Task2264 : InfoBasicTask
    {
        public Task2264(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialStr = "6777133339";
            Console.WriteLine($"Исходная строка: \"{initialStr}\"");
            string result = largestGoodInteger(initialStr);
            Console.WriteLine(result == String.Empty ? "В исходной строке отсутствую хорошие целые числа" :$"Самое большое хорошее целое число = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string largestGoodInteger(string num)
        {
            string max = String.Empty;
            for (int i = 0; i < num.Length - 2; i++)
            {
                string substr = num.Substring(i, 3);
                HashSet<char> chars = new HashSet<char>(substr);
                if (chars.Count == 1)
                {
                    if (max == String.Empty)
                    {
                        max = substr;
                    }
                    else
                    {
                        bool isResultBigger = true;
                        for (int j = 0; j < max.Length; j++)
                        {
                            if (substr[j] < max[j])
                            {
                                break;
                            }
                            else if (substr[j] > max[j])
                            {
                                isResultBigger = false;
                                break;
                            }
                        }
                        if (!isResultBigger)
                        {
                            max = substr;
                        }
                    }
                }
            }
            return max;
        }
    }
}
