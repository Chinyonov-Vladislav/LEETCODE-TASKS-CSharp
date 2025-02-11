using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1832
{
    /*
     1832. Проверьте, является ли предложение панграммой
    Панграмма — это предложение, в котором каждая буква английского алфавита встречается хотя бы один раз.
    Учитывая строку, sentence содержащую только строчные английские буквы, верните, true если sentence это панграмма или false иначе.
    https://leetcode.com/problems/check-if-the-sentence-is-pangram/description/
     */
    public class Task1832 : InfoBasicTask
    {
        public Task1832(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "thequickbrownfoxjumpsoverthelazydog";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            Console.WriteLine(checkIfPangram(str) ? "Исходная строка является панграммой" : "Исходная строка не является панграммой");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool checkIfPangram(string sentence)
        {
            int countEnglishSymbols = 26;
            HashSet<char> chars = new HashSet<char>();
            foreach (char c in sentence) { 
                chars.Add(c);
            }
            return chars.Count == countEnglishSymbols;
        }
    }
}
