using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task263
{
    /*
     263. Уродливое Число
    Некрасивое число — это положительное целое число, которое не имеет простых делителей, кроме 2, 3 и 5.
    Учитывая целое число n, верните true если n этоуродливое число.
    https://leetcode.com/problems/ugly-number/description/
     */
    public class Task263 : InfoBasicTask
    {
        public Task263(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 6;
            Console.WriteLine(isUgly(number) ? $"Число {number} является уродливым" : "Число {number} не является уродливым");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isUgly(int n)
        {
            if (n == 0)
            {
                return false;
            }
            while (n != 1) {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else if (n % 3 == 0)
                {
                    n /= 3;
                }
                else if (n % 5 == 0)
                {
                    n /= 5;
                }
                else {
                    return false;
                }
            }
            return true;
        }
    }
}
