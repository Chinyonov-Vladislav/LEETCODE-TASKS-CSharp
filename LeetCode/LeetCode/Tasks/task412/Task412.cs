using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task412
{
    public class Task412 : InfoBasicTask
    {
        public Task412(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 15;
            IList<string> result = fizzBuzz(number);
            printIListString(result, "Результат");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<string> fizzBuzz(int n)
        {
            List<string> answer = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    answer.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    answer.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    answer.Add("Buzz");
                }
                else
                {
                    answer.Add(i.ToString());
                }
            }
            return answer;
        }
    }
}
