using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task397
{
    /*
     397. Замена целого числа
    Учитывая положительное целое число n, вы можете применить одну из следующих операций:
        Если n четное, замените n на n / 2
        Если n значение нечетное, замените n на n + 1 или n - 1.
    Возвращает минимальное количество операций, необходимых для того, чтобы n стать 1.
    Ограничения:
        1 <= n <= 2^31 - 1
    https://leetcode.com/problems/integer-replacement/description/
     */
    public class Task397 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Nothing = 0,
            Iterative = 1,
            Recursive = 2,
            Both = 3
        }
        public Task397(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = int.MaxValue;
            Console.WriteLine($"Исходное число n = {n}");
            if (isValid(n))
            {
                int result = 0;
                TypeSolution typeSolution = askUserTypeSolution();
                switch (typeSolution)
                {
                    case TypeSolution.Iterative:
                        result = integerReplacement(n);
                        Console.WriteLine($"Решение с помощью итеративного метода: минимальное количество операций, необходимых для того, чтобы {n} стать 1 = {result}");
                        break;
                    case TypeSolution.Recursive:
                        result = recursive(n, 0);
                        Console.WriteLine($"Решение с помощью рекурсивного метода: минимальное количество операций, необходимых для того, чтобы {n} стать 1 = {result}");
                        break;
                    case TypeSolution.Both:
                        result = integerReplacement(n);
                        Console.WriteLine($"Решение с помощью итеративного метода: минимальное количество операций, необходимых для того, чтобы {n} стать 1 = {result}");
                        result = recursive(n, 0);
                        Console.WriteLine($"Решение с помощью рекурсивного метода: минимальное количество операций, необходимых для того, чтобы {n} стать 1 = {result}");
                        break;

                }
                
                
            }
            else
            {

            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int n)
        {
            if (n < 1)
            {
                return false;
            }
            return true;
        }
        private int integerReplacement(int n)
        {
            int count = 0;
            if (n == int.MaxValue)
            {
                count--;
            }
            while (n != 1)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    if (n == 3 || ((n - 1) % 4 == 0) || n == int.MaxValue)
                    {
                        n -= 1;
                    }
                    else
                    {
                        n += 1;
                    }
                }
                count++;
            }
            return count;
        }
        private int recursive(long currentNumber, int count)
        {
            if (currentNumber == 1)
            {
                return count;
            }
            if (currentNumber % 2 == 0)
            {
                return recursive(currentNumber /= 2, count + 1);
            }
            else
            {
                if (currentNumber == 3 || ((currentNumber - 1) % 4 == 0))
                {
                    return recursive(currentNumber - 1, count + 1);
                }
                else
                {
                    return recursive(currentNumber + 1, count + 1);
                }
            }
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Итеративный\n" +
                    "2 - Рекурсивный\n" +
                    "3 - Протестировать оба решения\n" +
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 3)
                    {
                        throw new FormatException();
                    }
                    switch (choiceUser)
                    {
                        case 0:
                            return TypeSolution.Nothing;
                        case 1:
                            return TypeSolution.Iterative;
                        case 2:
                            return TypeSolution.Recursive;
                        case 3:
                            return TypeSolution.Both;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
        }
    }
}
