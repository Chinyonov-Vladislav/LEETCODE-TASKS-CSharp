using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1189
{
    /*
     1189. Максимальное количество слов "balloon"
    Учитывая строку text, вы хотите использовать символы text, чтобы сформировать как можно больше экземпляров слова "balloon".
    Вы можете использовать каждый символ text не более одного раза. Верните максимальное количество комбинаций, которые можно составить.
    https://leetcode.com/problems/maximum-number-of-balloons/description/
     */
    public class Task1189 : InfoBasicTask
    {
        public Task1189(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "loonbalxballpoon";
            Console.WriteLine($"Оригинальная строка: {str}");
            int count = maxNumberOfBalloons(str);
            Console.WriteLine($"Максимальное количество слов \"balloon\", которое можно составить из оригинальной строки = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int maxNumberOfBalloons(string text)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            int count = 0;
            if (!dict.ContainsKey('b') || !dict.ContainsKey('a') || !dict.ContainsKey('l') || !dict.ContainsKey('o') || !dict.ContainsKey('n'))
            {
                return count;
            }
            while (true)
            {
                dict['b']--;
                dict['a']--;
                dict['l'] -= 2;
                dict['o'] -= 2;
                dict['n']--;
                if (dict['b'] < 0 || dict['a'] < 0 || dict['l'] < 0 || dict['o'] < 0 || dict['n']<0)
                {
                    break;
                }
                count++;
            }
            return count;
        }
    }
}
