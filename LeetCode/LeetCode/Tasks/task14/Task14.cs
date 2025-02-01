using System;
using LeetCode.Basic;

namespace LeetCode.Tasks.task14
{
    public class Task14 : InfoBasicTask
    {
        public Task14(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] strs = new string[] {
                "flower","flow","flight"
            };
            Console.WriteLine($"Самый длинный общий префикс: {longestCommonPrefix(strs)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string longestCommonPrefix(string[] strs)
        {
            int minLengthFromStrs = int.MaxValue;
            string minStr = "";
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Length < minLengthFromStrs)
                {
                    minLengthFromStrs = strs[i].Length;
                    minStr = strs[i];
                }
            }
            string result = "";
            for (int i = 0; i < minStr.Length; i++)
            {
                string prefix = minStr.Substring(0, i + 1);
                bool allStrsHaveCommonPrefix = true;
                for (int j = 0; j < strs.Length; j++)
                {
                    if (!strs[j].StartsWith(prefix))
                    {
                        allStrsHaveCommonPrefix = false;
                        break;
                    }
                }
                if (allStrsHaveCommonPrefix)
                {
                    result = prefix;
                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }
}
