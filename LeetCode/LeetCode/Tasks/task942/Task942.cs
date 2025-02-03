using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task942
{
    /*
     942. Совпадение строк DI
    Перестановка perm целых чисел n + 1 из всех целых чисел в диапазоне [0, n] может быть представлена в виде строки s длиной n где:
        s[i] == 'I' если perm[i] < perm[i + 1]
        s[i] == 'D' если perm[i] > perm[i + 1].
    Учитывая строку s, восстановите перестановку perm и верните её. Если существует несколько допустимых перестановок perm, верните любую из них.
     */
    public class Task942 : InfoBasicTask
    {
        public Task942(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "IDID";
            int[] result = diStringMatch(s);
            printArray(result, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] diStringMatch(string s)
        {
            int[] perm = new int[s.Length + 1];
            for (int i = 0; i < s.Length + 1; i++)
            {
                perm[i] = i;
            }
            bool isCorrect = true;
            while (true)
            {
                isCorrect = true;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'I')
                    {
                        if (!(perm[i] < perm[i + 1]))
                        {
                            isCorrect = false;
                            (perm[i], perm[i + 1]) = (perm[i + 1], perm[i]);
                            break;
                        }
                    }
                    if (s[i] == 'D')
                    {
                        if (!(perm[i] > perm[i + 1]))
                        {
                            isCorrect = false;
                            (perm[i], perm[i + 1]) = (perm[i + 1], perm[i]);
                            break;
                        }
                    }
                }
                if (isCorrect)
                {
                    break;
                }
            }
            return perm;
        }
        // скопировано с leetcode
        private int[] bestSolution(string s)
        {
            int[] result = new int[s.Length + 1];
            int DIndex = s.Length;
            int IIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'I')
                {
                    result[i] = IIndex;
                    IIndex++;
                }
                if (s[i] == 'D')
                {
                    result[i] = DIndex;
                    DIndex--;
                }
            }
            if (s[s.Length - 1] == 'D')
            {
                result[result.Length - 1] = DIndex;
            }
            else
            {
                result[result.Length - 1] = IIndex;
            }
            return result;
        }
    }
}
