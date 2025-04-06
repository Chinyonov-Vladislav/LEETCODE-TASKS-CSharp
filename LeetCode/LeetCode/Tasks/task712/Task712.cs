using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task712
{
    /*
     712. Минимальная сумма удаления в формате ASCII для двух строк
    Учитывая две строки s1 и s2, верните наименьшую сумму ASCII удаленных символов, чтобы две строки стали равны.
    Ограничения:
        1 <= s1.length, s2.length <= 1000
        s1 и s2 состоят из строчных английских букв.
    https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings/description/
     */
    public class Task712 : InfoBasicTask
    {
        public Task712(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s1 = "delete";
            string s2 = "leet";
            Console.WriteLine($"Строка №1: \"{s1}\"\nСтрока №2: \"{s2}\"");
            if (isValid(s1, s2))
            {
                int res = minimumDeleteSum(s1, s2);
                Console.WriteLine($"Наименьшую сумма ASCII удаленных символов, чтобы две строки (\"{s1}\" и \"{s2}\") стали равны = {res}");
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
        private bool isValid(string s1, string s2)
        {
            int lowLimitLength = 1;
            int highLimitLength = 1000;
            List<string> data = new List<string>() { s1,s2 };
            foreach (string str in data)
            {
                if (str.Length < lowLimitLength || str.Length > highLimitLength)
                {
                    return false;
                }
                foreach (char c in str)
                {
                    if (!(c >= 'a' && c <= 'z'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int minimumDeleteSum(string s1, string s2)
        {
            int[][] dp = findArrayForLCS(s1, s2);
            return asciiSum(s1) + asciiSum(s2) - 2*dp[s1.Length][s2.Length];
        }

        private int[][] findArrayForLCS(string s1, string s2)
        {
            int countRows = s1.Length + 1;
            int countColumns = s2.Length + 1;
            int[][] dp = new int[countRows][];
            for (int index = 0; index < dp.Length; index++)
            {
                dp[index] = new int[countColumns];
            }
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    if (indexRow == 0)
                    {
                        dp[indexRow][0] = 0;
                    }
                    else if (indexColumn == 0)
                    {
                        dp[0][indexColumn] = 0;
                    }
                    else
                    {
                        if (s1[indexRow - 1] == s2[indexColumn - 1])
                        {
                            dp[indexRow][indexColumn] = dp[indexRow - 1][indexColumn - 1] + (int)s1[indexRow-1];
                        }
                        else
                        {
                            dp[indexRow][indexColumn] = Math.Max(dp[indexRow - 1][indexColumn], dp[indexRow][indexColumn - 1]);
                        }
                    }
                }
            }
            return dp;
        }
        private int asciiSum(string s)
        {
            int sum = 0;
            foreach (char c in s)
            {
                sum += (int)c;
            }
            return sum;
        }
    }
}
