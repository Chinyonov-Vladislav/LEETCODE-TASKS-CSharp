using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task187
{
    /*
     187. Повторяющиеся последовательности ДНК
    Последовательность ДНК состоит из ряда нуклеотидов, обозначаемых как 'A', 'C', 'G' и 'T'.
        Например, "ACGAATTCCG" - это последовательность ДНК.
    При изучении ДНК полезно выявлять повторяющиеся последовательности в ДНК.
    Учитывая строку, s представляющую последовательность ДНК, верните все 10-буквенные последовательности (подстроки), которые встречаются более одного раза в молекуле ДНК. Вы можете вернуть ответ в любом порядке.
    Ограничения:
        1 <= s.length <= 10^5
        s[i] является либо 'A', 'C', 'G', либо 'T'.
     https://leetcode.com/problems/repeated-dna-sequences/description/
     */
    public class Task187 : InfoBasicTask
    {
        public Task187(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT";
            Console.WriteLine($"Последовательность ДНК: \"{s}\"");
            if (isValid(s))
            {
                IList<string> res = findRepeatedDnaSequences(s);
                printIListString(res, "10-буквенные последовательности, которые встречаются в ДНК более 1 раза: ");
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
            int highLimit = (int)Math.Pow(10,5);
            if (s.Length < lowLimit || s.Length > highLimit)
            {
                return false;
            }
            List<char> acceptedChars = new List<char>() { 'A','C','G','T' };
            foreach (char c in s)
            {
                if (!acceptedChars.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        private IList<string> findRepeatedDnaSequences(string s)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int left = 0;
            int right = 9;
            if (!(left >= 0 && left < s.Length && right >= 0 && right < s.Length))
            {
                return new List<string>();
            }
            StringBuilder sb = new StringBuilder();
            while (left >= 0 && left < s.Length && right >= 0 && right < s.Length)
            {
                if (sb.Length == 0)
                {
                    for (int index = left; index <= right; index++)
                    {
                        sb.Append(s[index]);
                    }
                }
                else
                {
                    sb.Remove(0, 1);
                    sb.Append(s[right]);
                }
                string currentDNA = sb.ToString();
                if (dict.ContainsKey(currentDNA))
                {
                    dict[currentDNA]++;
                }
                else
                {
                    dict.Add(currentDNA, 1);
                }
                left++;
                right++;
            }
            List<string> res = new List<string>();
            foreach (var pair in dict)
            {
                if (pair.Value > 1)
                {
                    res.Add(pair.Key);
                }
            }
            return res;
        }
    }
}
