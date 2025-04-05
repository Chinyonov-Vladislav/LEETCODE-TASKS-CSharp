using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task763
{
    /*
     763. Метки разделов
    Вам дана строка s. Мы хотим разделить строку на как можно большее количество частей так, чтобы каждая буква встречалась не более чем в одной части. Например, строку "ababcc" можно разделить на ["abab", "cc"], но такие варианты, как ["aba", "bcc"] или ["ab", "ab", "cc"], недопустимы.
    Обратите внимание, что разбиение выполняется таким образом, чтобы после объединения всех частей по порядку результирующая строка была s.
    Возвращает список целых чисел, представляющих размер этих частей.
    Ограничения:
        1 <= s.length <= 500
        s состоит из строчных английских букв.
    https://leetcode.com/problems/partition-labels/description/
     */
    public class Task763 : InfoBasicTask
    {
        public Task763(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "ababcbacadefegdehijhklij";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                IList<int> res = partitionLabels(s);
                printIListInt(res, "Длины разделов: ");
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
        private bool isValid(string s)
        {
            int lowLimit = 1;
            int highLimit = 500;
            if (s.Length < lowLimit || s.Length > highLimit)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            return true;
        }
        private IList<int> partitionLabels(string s)
        {
            IList<int> result = new List<int>();
            int[] indexsOfChars = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                indexsOfChars[s[i] - 'a'] = i;
            }
            int start = 0;
            int farthest = 0;
            for (int i = 0; i < s.Length; i++)
            {
                farthest = Math.Max(farthest, indexsOfChars[s[i] - 'a']);
                if (farthest == i)
                {
                    result.Add(farthest - start + 1);
                    start = i + 1;
                }
            }
            return result;
        }
    }
}
