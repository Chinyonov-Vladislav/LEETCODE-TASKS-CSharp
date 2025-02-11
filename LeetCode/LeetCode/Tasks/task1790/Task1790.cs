using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1790
{
    /*
     1790. Проверьте, можно ли сделать строки равными, поменяв местами одну из них
    Вам даны две строки s1 и s2 одинаковой длины. Перестановка строк — это операция, при которой вы выбираете два индекса в строке (не обязательно разные) и меняете местами символы в этих индексах.
    Верните true если можно сделать обе строки равными, выполнив не более одной замены строк в ровно одной из строк. В противном случае верните false.
    https://leetcode.com/problems/check-if-one-string-swap-can-make-strings-equal/description/
     */
    public class Task1790 : InfoBasicTask
    {
        public Task1790(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str1 = "acac";
            string str2 = "acbb";
            Console.WriteLine($"Строка №1: \"{str1}\"");
            Console.WriteLine($"Строка №2: \"{str2}\"");
            Console.WriteLine(areAlmostEqual(str1, str2) ? "Можно сделать обе строки равными, выполнив не более одной замены строк в ровно одной из строк" : "Нельзя сделать обе строки равными, выполнив не более одной замены строк в ровно одной из строк");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool areAlmostEqual(string s1, string s2)
        {
            if (s1 == s2)
            {
                return true;
            }
            if (s1.Length != s2.Length)
            {
                return false;
            }
            int countDifferentPos = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++) {
                if (dict.ContainsKey(s1[i]))
                {
                    dict[s1[i]]++;
                }
                else
                {
                    dict.Add(s1[i], 1);
                }
                if (dict.ContainsKey(s2[i]))
                {
                    dict[s2[i]]--;
                }
                else
                {
                    dict.Add(s2[i], -1);
                }
                if (s1[i] != s2[i])
                {
                    countDifferentPos++;
                }
            }
            bool areCharsSame = true;
            foreach (var pair in dict) {
                if (pair.Value != 0)
                {
                    areCharsSame = false;
                    break;
                }
            }
            return areCharsSame && countDifferentPos == 2;
        }
    }
}
