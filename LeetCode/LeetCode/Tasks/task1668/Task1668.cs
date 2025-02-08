using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1668
{
    /*
     1668. Максимальная повторяющаяся подстрока
    Для строки sequence строка word является k повторяющейся, если word сцепленные k разы являются подстрокой sequence. word's максимальное kповторяющееся значение - это наибольшее значение, k где word k-повторяющееся в sequence. Если word не является подстрокой sequence, то word максимальное k повторяющееся значение 0 равно.
    Заданные строки sequence и word возвращают максимальное k повторяющееся значение из word in sequence.
    https://leetcode.com/problems/maximum-repeating-substring/description/
     */
    public class Task1668 : InfoBasicTask
    {
        public Task1668(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string sequence = "aaabaaaabaaabaaaabaaaabaaaabaaaaba";
            string word = "aaaba";
            Console.WriteLine($"Исходная строка = \"{sequence}\"");
            Console.WriteLine($"Паттерн = \"{word}\"");
            int countMaxRepeating = maxRepeating(sequence, word);
            Console.WriteLine($"Максимальное количество последовательного повторения строки паттерна в исходной строке = {countMaxRepeating}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maxRepeating(string sequence, string word)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            while (true)
            {
                sb.Append(word);
                if (sequence.Contains(sb.ToString()))
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
    }
}
