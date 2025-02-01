using System;
using System.Collections.Generic;
using LeetCode.Basic;
namespace LeetCode.Tasks.task3
{
    public class Task3 : InfoBasicTask
    {
        public Task3(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "jbpnbwwd";
            Console.WriteLine($"Максимальная длина уникальной подстроки = {lengthOfLongestSubstring(str)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int lengthOfLongestSubstring(string s) // my solution
        {
            if (s.Length <= 1)
            {
                return s.Length;
            }
            int maxLengthUniqueString = 0;
            HashSet<char> uniqueChars = new HashSet<char>();
            for (int indexFirst = 0; indexFirst < s.Length; indexFirst++)
            {
                for (int indexTwo = indexFirst; indexTwo < s.Length; indexTwo++)
                {
                    int previousCountUniqueChars = uniqueChars.Count;
                    uniqueChars.Add(s[indexTwo]);
                    if (previousCountUniqueChars == uniqueChars.Count)
                    {
                        if (uniqueChars.Count > maxLengthUniqueString)
                        {
                            maxLengthUniqueString = uniqueChars.Count;
                        }
                        uniqueChars.Clear();
                        break;
                    }
                }
            }
            return maxLengthUniqueString;
        }

        private int bestSolution(string s) // copy from leetcode
        {
            if (s.Length == 0)
                return 0;

            string substring = string.Empty + s[0];
            string longest = substring;

            //"abcabcbb"

            for (int i = 1; i < s.Length; ++i)
            {
                bool canAdd = true;

                for (int ss = 0; ss < substring.Length; ++ss)
                {
                    if (substring[ss] == s[i])
                    {
                        //dvd
                        if (substring.Length > 1)
                            substring = substring.Substring(ss + 1, substring.Length - (ss + 1));
                        else
                            substring = String.Empty;

                        substring += s[i];
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    substring += s[i];

                    if (substring.Length > longest.Length)
                    {
                        longest = substring;
                    }
                }
            }

            return longest.Length;
        }

    }
}
