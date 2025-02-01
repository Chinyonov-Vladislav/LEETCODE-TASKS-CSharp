using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task326
{
    /*
     326. Степень тройки
    Учитывая целое число n, верните true если оно является степенью тройки. В противном случае верните false.
    Целое число n является степенью тройки, если существует целое число x такое, что n == 3x.
    https://leetcode.com/problems/power-of-three/description/
     */
    public class Task326 : InfoBasicTask
    {
        public Task326(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 27;
            Console.WriteLine(isPowerOfThree(number) ? $"Число {number} является степенью тройки" : $"Число {number} не является степенью тройки");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isPowerOfThree(int n)
        {
            if(n<=0)
            { 
                return false; 
            }
            if (n == 1)
            {
                return true;
            }
            int current = 1;
            while(current <= int.MaxValue / 3 && current <= n)
            {
                current *= 3;
                if (current == n)
                {
                    return true;
                }
            }
            return false;
        }
        private bool bestSolution(int n)
        {
            if (n <= 0)
            {
                return false;
            } 
            while (n % 3 == 0)
            {
                n /= 3;
            }
            return n == 1;
        }
    }
}
