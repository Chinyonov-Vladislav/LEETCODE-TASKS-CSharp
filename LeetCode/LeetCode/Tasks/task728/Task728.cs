using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task728
{
    /*
     728. Саморазделяющиеся числа
    Самоделимое число — это число, которое делится на каждую свою цифру.
    Например, 128 является числом, которое делится само на себя, потому что 128 % 1 == 0, 128 % 2 == 0, и 128 % 8 == 0
    Самоделимое число не может содержать цифру ноль.
    Учитывая два целых числа left и right, верните список всехчисел, делящихся нацело в диапазоне [left, right] (оба включительно).
    https://leetcode.com/problems/self-dividing-numbers/description/
     */
    public class Task728 : InfoBasicTask
    {
        public Task728(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int left = 1;
            int right = 22;
            IList<int> result = selfDividingNumbers(left, right);
            printIListInt(result, $"Саморазделяющиеся числа в интервале с {left} по {right}: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> selfDividingNumbers(int left, int right)
        {
            IList<int> result = new List<int>();
            while (left <= right)
            {
                string numberStr = left.ToString();
                Console.WriteLine(numberStr.ToString());
                bool canAdded = true;
                for (int i = 0; i < numberStr.Length; i++)
                {
                    int denumerator = numberStr[i] - '0';
                    if (numberStr[i] == '0' || left % denumerator != 0)
                    {
                        canAdded = false;
                        break;
                    }
                }
                if (canAdded)
                {
                    result.Add(left);
                }
                left++;
            }
            return result;
        }
        private IList<int> bestSolution(int left, int right)
        {
            var results = new List<int>();

            for (var i = left; i <= right; ++i)
            {
                var remain = i;
                var isValid = true;
                while (remain != 0 && isValid)
                {
                    var digit = remain % 10;

                    if (digit == 0 || i % digit != 0)
                    {
                        isValid = false;
                    }
                    else
                    {
                        remain /= 10;
                    }
                }
                if (isValid)
                {
                    results.Add(i);
                }
            }
            return results;
        }
    }
}
