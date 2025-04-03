using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task650
{
    /*
     650. Клавиатура с 2 клавишами
    На экране блокнота есть только один символ 'A'. На каждом шаге вы можете выполнить одну из двух операций в этом блокноте:
        Скопировать все: вы можете скопировать все символы, присутствующие на экране (частичная копия не допускается).
        Вставить: вы можете вставить символы, которые копировались в последний раз.
    Учитывая целое число n, верните минимальное количество операций, чтобы вывести символ 'A' ровно n раз на экран.
    Ограничения:
        1 <= n <= 1000
     */
    public class Task650 : InfoBasicTask
    {
        public Task650(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n =3;
            Console.WriteLine($"Необходимо количество вывода символа \'A\' на экране = {n}");
            if (isValid(n))
            {
                int res = minSteps(n);
                Console.WriteLine($"Минимальное количество операций, чтобы вывести символ \'A\' ровно {n} раз на экран = {res}");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int n)
        {
            int lowLimit = 1;
            int highLimit = 1000;
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            return true;
        }
        private int minSteps(int n)
        {
            int res = 0;
            while (n % 2 == 0)
            {
                res+=2;
                n /= 2;
            }
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                while (n % i == 0)
                {
                    res += i;
                    n /= i;
                }
            }
            if (n > 1)
            {
                res += n;
            }
            return res;
        }
    }
}
