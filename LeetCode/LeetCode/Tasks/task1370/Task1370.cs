using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1370
{
    /*
     1370. Увеличивающаяся уменьшающаяся строка
    Вам дана строка s. Переставьте символы в строке по следующему алгоритму:
        Удалите самый маленький символ из s и добавьте его к результату.
        Удалите самый маленький символ из s, который больше последнего добавленного символа, и добавьте его к результату.
        Повторяйте шаг 2 до тех пор, пока не останется больше символов, которые можно будет удалить.
        Удалите самый большой символ из s и добавьте его к результату.
        Удалите самый большой символ из s, который меньше последнего добавленного символа, и добавьте его к результату.
        Повторяйте шаг 5 до тех пор, пока не останется больше символов, которые можно будет удалить.
        Повторяйте шаги с 1 по 6, пока не удалите все символы из s
    Если самый маленький или самый большой символ встречается более одного раза, вы можете выбрать любое его появление для добавления в результат.
    Верните результирующую строку после изменения порядка s с использованием этого алгоритма.
    Ограничения:
        1 <= s.length <= 500
        s состоит только из строчных английских букв.
    https://leetcode.com/problems/increasing-decreasing-string/description/
     */
    public class Task1370 : InfoBasicTask
    {
        public Task1370(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "aaaabbbbcccc";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                string res = sortString(s);
                Console.WriteLine($"Результирующая строка: \"{res}\"");
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
            if (s.Length < 1 || s.Length > 500)
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
        private string sortString(string s)
        {
            int[] freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }
            StringBuilder sb = new StringBuilder();
            while (!isAllZero(freq))
            {
                for (int i = 0; i < freq.Length; i++)
                {
                    if (freq[i] != 0)
                    {
                        sb.Append((char)(i+'a'));
                        freq[i]--;
                    }
                }
                for (int i = freq.Length-1; i >= 0; i--)
                {
                    if (freq[i] != 0)
                    {
                        sb.Append((char)(i + 'a'));
                        freq[i]--;
                    }
                }
            }
            return sb.ToString();
        }
        private bool isAllZero(int[] freq)
        {
            foreach (int num in freq)
            {
                if (num !=0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
