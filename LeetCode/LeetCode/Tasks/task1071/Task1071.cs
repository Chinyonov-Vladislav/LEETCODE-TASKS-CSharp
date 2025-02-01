using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1071
{
    /*
     1071. Наибольший общий делитель строк
    Для двух строк s и t мы говорим, что «t делит s» тогда и только тогда, когда s = t + t + t + ... + t + t (то есть t повторяется один или несколько раз).
    Учитывая две строки str1 и str2, верните самую большую строку x такую, которая x разделяет обе str1 и str2.
    https://leetcode.com/problems/greatest-common-divisor-of-strings/description/
     */
    public class Task1071 : InfoBasicTask
    {
        public Task1071(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str1 = "ABABAB";
            string str2 = "ABAB";
            string result = gcdOfStrings(str1, str2);
            Console.WriteLine($"Первая строка = \"{str1}\"\nВторая строка = \"{str2}\"\nНаибольший общий делитель строк = \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string gcdOfStrings(string str1, string str2)
        {
            string result = String.Empty;
            string leastString = str1.Length > str2.Length ? str2 : str1;
            string mostString = str1.Length <= str2.Length ? str2 : str1;
            for (int i = 0; i < leastString.Length; i++)
            {
                HashSet<string> divisorsOfFirstStr = new HashSet<string>();
                string subStr = leastString.Substring(0, i + 1);
                string part = leastString.Substring(0, i + 1);
                Console.WriteLine(part);
                while (part.Length <= leastString.Length)
                {
                    if (part == leastString)
                    {
                        divisorsOfFirstStr.Add(subStr);
                    }
                    part = String.Concat(part, subStr);
                }
                part = leastString.Substring(0, i + 1);
                while (part.Length <= mostString.Length)
                {
                    if (part == mostString)
                    {
                        if (divisorsOfFirstStr.Contains(subStr) && subStr.Length > result.Length)
                        {
                            result = subStr;
                        }
                    }
                    part = String.Concat(part, subStr);
                }
            }
            return result;
        }
        // скопировано с leetcode
        // TODO: разобрать метод
        private string bestSolution(string str1, string str2)
        {
            if (str1 + str2 != str2 + str1)
                return string.Empty;

            var shortStr = str1.Length > str2.Length ? str2 : str1;
            var n = shortStr.Length;

            while (n > 0)
            {
                if (str1.Length % n == 0 && str2.Length % n == 0)
                {
                    return shortStr.Substring(0, n);
                }
                n--;
            }
            return string.Empty;
        }
    }
}
