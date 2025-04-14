using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task443
{
    /*
     443. Сжатие строки
    Получив массив символов chars, сожмите его, используя следующий алгоритм:
    Начните с пустой строки s. Для каждой группы повторяющихся подряд символов в chars:
        Если длина группы равна 1, добавьте символ в s.
        В противном случае добавьте символ, за которым следует длина группы
    Сжатая строка s не должна возвращаться отдельно, а должна храниться во входном массиве символовchars. Обратите внимание, что группы длиной 10 или больше будут разделены на несколько символов в chars.
    После того как вы закончите изменять входной массив, верните новую длину массива.
    Вы должны написать алгоритм, который использует только постоянное дополнительное пространство.
    Ограничения:
        1 <= chars.length <= 2000
        chars[i] является строчной английской буквой, заглавной английской буквой, цифрой или символом (то есть, любой символ)
    https://leetcode.com/problems/string-compression/description/
     */
    public class Task443 : InfoBasicTask
    {
        public Task443(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            char[] chars = new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' };
            if (isValid(chars))
            {
                int res = compress(chars);
                Console.WriteLine($"Длина закодированной части массива = {res}");
                Console.Write("Закодированная часть массива: [");
                for (int i = 0; i < res; i++)
                {
                    if (i == res - 1)
                    {
                        Console.Write($"{chars[i]}]\n");
                    }
                    else
                    {
                        Console.Write($"{chars[i]}, ");
                    }
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
        private bool isValid(char[] chars)
        {
            int lowLimitCountChars = 1;
            int highLimitCountChars = 2000;
            if (chars.Length < lowLimitCountChars || chars.Length > highLimitCountChars)
            {
                return false;
            }
            return true;
        }
        private int compress(char[] chars)
        {
            int positionForUpdateChars = 0;
            int length = 0;
            int left = 0;
            int right = 0;
            while (right < chars.Length)
            {
                char currentChar = chars[left];
                while (true)
                {
                    if (right < chars.Length - 1)
                    {
                        if (chars[right + 1] != currentChar)
                        {
                            break;
                        }
                        else
                        {
                            right++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                int countSymbols = right - left + 1;
                string countSymbolsInStringRepresentation = countSymbols.ToString();
                chars[positionForUpdateChars] = currentChar;
                positionForUpdateChars++;
                if (countSymbols > 1)
                {
                    for (int i = 0; i < countSymbolsInStringRepresentation.Length; i++)
                    {
                        chars[positionForUpdateChars] = countSymbolsInStringRepresentation[i];
                        positionForUpdateChars++;
                    }
                    length += countSymbolsInStringRepresentation.Length + 1;
                }
                else
                {
                    length += 1;
                }
                right++;
                left = right;
            }
            return length;
        }
    }
}
