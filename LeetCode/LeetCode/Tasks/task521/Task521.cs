using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task521
{
    /*
     521. Самая длинная необщая подпоследовательность I
    Учитывая две строки a и b, верните длину самой длинной необычной подпоследовательности между a и b. Если такой необычной подпоследовательности не существует, верните -1.
    Нетипичная подпоследовательность между двумя строками — это строка, которая является подпоследовательность ровно об одном из них.
    https://leetcode.com/problems/longest-uncommon-subsequence-i/description/
     */
    public class Task521 : InfoBasicTask
    {
        public Task521(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string a = "aaa";
            string b = "bbb";
            int maxLengthUncommonSubsequence = findLUSlength(a, b);
            Console.WriteLine($"Первая строка = \"{a}\". Вторая строка = \"{b}\". Максимальная длина необщей подпоследовательности = {maxLengthUncommonSubsequence}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findLUSlength(string a, string b)
        {
            if (a == b)
            {
                return -1;
            }
            else
            {
                return a.Length < b.Length ? b.Length : a.Length;
            }
        }
    }
}
