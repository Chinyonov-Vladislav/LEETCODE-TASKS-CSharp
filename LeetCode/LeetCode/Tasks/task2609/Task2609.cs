using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2609
{
    /*
     2609. Найдите самую длинную сбалансированную подстроку в двоичной строке
    Вам выдается двоичная строка, s состоящая только из нулей и единиц.
    Подстрока s считается сбалансированной, если все нули стоят перед единицами и количество нулей равно количеству единиц внутри подстроки. Обратите внимание, что пустая подстрока считается сбалансированной.
    Возвращает длину самой длинной сбалансированной подстроки из s.
    Подстрока - это непрерывная последовательность символов внутри строки.
    Ограничения:
        1 <= s.length <= 50
        '0' <= s[i] <= '1'
    https://leetcode.com/problems/find-the-longest-balanced-substring-of-a-binary-string/description/
     */
    public class Task2609 : InfoBasicTask
    {
        public Task2609(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "0100";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                int max = findTheLongestBalancedSubstring(s);
                Console.WriteLine($"Длина самой длинной сбалансированной бинарной подстроки = {max}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string s)
        {
            if (s.Length < 1 || s.Length > 50)
            {
                return false;
            }
            foreach (char c in s) {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }
        private int findTheLongestBalancedSubstring(string s)
        {
            if (s.Length == 1)
            {
                return 0;
            }
            int count = s.Length %2 ==0 ? s.Length : s.Length-1;
            while (count != 0)
            {
                for (int i = 0; i <= s.Length - count; i++)
                {
                    int countOnes = 0;
                    int countZeros = 0;
                    string subStr = s.Substring(i, count);
                    int indexOfFirstOne = subStr.IndexOf("1");
                    if (indexOfFirstOne != -1)
                    {
                        for (int j = 0; j < subStr.Length; j++)
                        {
                            if (j < indexOfFirstOne && subStr[j] == '0')
                            {
                                countZeros++;
                            }
                            if (j >= indexOfFirstOne && subStr[j] == '1')
                            {
                                countOnes++;
                            }
                        }
                    }
                    else
                    {
                        continue; 
                    }
                    if (countOnes == countZeros && countOnes+countZeros == subStr.Length)
                    {
                        return subStr.Length;
                    }
                }
                count -= 2;
            }
            return 0;
        }
    }
}
