using LeetCode.Basic;
using System;
using System.Linq;
using System.Text;

namespace LeetCode.Tasks.task345
{
    /*
     345. Инвертировать гласные в строке
    Гласные — это 'a', 'e', 'i', 'o', и 'u', и они могут встречаться как в нижнем, так и в верхнем регистре, более одного раза.
     */
    public class Task345 : InfoBasicTask
    {
        public Task345(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "leetcode";
            Console.WriteLine($"Исходная строка = {str}");
            string result = reverseVowels(str);
            Console.WriteLine($"Конечная строка = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string reverseVowels(string s)
        {
            StringBuilder sb = new StringBuilder(s);
            char[] vowels = new char[] { 'a', 'e', 'i', 'o','u', 'A', 'E', 'I', 'O', 'U' };
            int left = 0;
            int right = s.Length-1;
            while (left <= right) {
                char currentLeftChar = s[left];
                if (vowels.Contains(currentLeftChar))
                {
                    while (left < right) {
                        char currentRightChar = s[right];
                        if (vowels.Contains(currentRightChar))
                        {
                            sb.Replace(s[left], currentRightChar, left, 1);
                            sb.Replace(s[right], currentLeftChar, right, 1);
                            right--;
                            break;
                        }
                        right--;
                    }
                }
                left++;
            }
            return sb.ToString();
        }
    }
}
