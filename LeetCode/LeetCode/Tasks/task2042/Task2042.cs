using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2042
{
    /*
     2042. Проверьте, возрастают ли числа в предложении
    Предложение — это список токенов, разделённых одним пробелом без начальных и конечных пробелов. Каждый токен — это либо положительное число, состоящее из цифр 0-9 без ведущих нулей, либо слово, состоящее из строчных букв английского алфавита.
        Например, "a puppy has 2 eyes 4 legs" — это предложение из семи токенов: "2" и "4" — это числа, а остальные токены, такие как "puppy" — это слова.
    Дана строка s с предложением. 
    Вам нужно проверить, все ли числа в sстрого возрастают слева направо (то есть, кроме последнего числа, каждое число строго меньше числа, стоящего справа от него в s).
    Верните, true если это так, или false в противном случае.
    https://leetcode.com/problems/check-if-numbers-are-ascending-in-a-sentence/description/
     */
    public class Task2042 : InfoBasicTask
    {
        public Task2042(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "1 box has 3 blue 4 red 6 green and 12 yellow marbles";
            Console.WriteLine($"Исходная строка = \"{s}\"");
            Console.WriteLine(areNumbersAscending(s) ? "Числа в исходной строке идут строго по возрастанию слева направо" : "Числа в исходной строке не идут строго по возрастанию слева направо");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool areNumbersAscending(string s)
        {
            List<int> numbers = new List<int>();
            string[] arrStr= s.Split(' ');
            foreach (string str in arrStr)
            {
                try
                {
                    numbers.Add(Int32.Parse(str));
                }
                catch (Exception) { }
            }
            if (numbers.Count <= 1)
            {
                return true;
            }
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] <= numbers[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
