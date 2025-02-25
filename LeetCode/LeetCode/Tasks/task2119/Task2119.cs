using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2119
{
    /*
     2119. Число после двойного разворота
    Перевернуть целое число означает перевернуть все его цифры.
        Например, при обратном преобразовании 2021 получается 1202. При обратном преобразовании 12300 получается 321 так как начальные нули не сохраняются.
    Дано целое число num, перевернем num его, чтобы получить reversed1, затем перевернем reversed1 его, чтобы получить reversed2. Вернуть true если reversed2 равно num. В противном случае вернуть false.
     https://leetcode.com/problems/a-number-after-a-double-reversal/description/
     */
    public class Task2119 : InfoBasicTask
    {
        public Task2119(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 2001;
            Console.WriteLine($"Исходное число = {number}");
            Console.WriteLine(isSameAfterReversals(number) ? "Число соответствует исходному после двойного переворачивания" : "Число отличается от исходного после двойного переворачивания");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isSameAfterReversals(int num)
        {
            if (num == 0)
            {
                return true;
            }
            if (num % 10 == 0)
            {
                return false;
            }
            return true;

        }
    }
}
