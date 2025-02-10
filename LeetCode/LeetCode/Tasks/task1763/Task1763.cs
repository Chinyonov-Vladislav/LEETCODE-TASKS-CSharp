using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1763
{
    /*
     1763. Самая длинная хорошая подстрока
    Строка s является хорошей, если для каждой буквы алфавита, которую s она содержит, она отображается как в верхнем, так и в нижнем регистре. Например, "abABB" приятно, потому что 'A' и 'a' появляются, и 'B' и 'b' появляются. Однако, "abA" это не потому, что 'b' появляется, а 'B' нет.
    Учитывая строку s, верните самую длинную подстроку из s того, что является красивым. Если их несколько, верните подстроку из самого раннего вхождения. Если их нет, верните пустую строку.
    https://leetcode.com/problems/longest-nice-substring/description/
     */
    public class Task1763 : InfoBasicTask
    {
        public Task1763(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "YazaAay";
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            string niceSubstring = longestNiceSubstring(initialString);
            Console.WriteLine($"Самая длинная хорошая подстрока: \"{niceSubstring}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string longestNiceSubstring(string s)
        {
            string result = String.Empty;
            for (int indexStart = 0; indexStart < s.Length-1; indexStart++)
            {
                for (int indexFinish = indexStart+1; indexFinish < s.Length; indexFinish++)
                {
                    string substring = s.Substring(indexStart, indexFinish-indexStart+1);
                    bool isGood = true;
                    for (int i = 0; i < substring.Length; i++)
                    {
                        if ((char.IsLower(substring[i]) && !substring.Contains(char.ToUpper(substring[i]))) ||
                            (char.IsUpper(substring[i]) && !substring.Contains(char.ToLower(substring[i]))))
                        {
                            isGood = false;
                            break;
                        }
                    }
                    if (isGood && substring.Length > result.Length)
                    {
                        result = substring;
                    }
                }
            }
            return result;
        }
    }
}
