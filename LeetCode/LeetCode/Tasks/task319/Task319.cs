using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task319
{
    /*
     319. Переключатель ламп накаливания
    Есть n лампочки, которые изначально выключены. Сначала вы включаете все лампочки, затем выключаете каждую вторую.
    В третьем раунде вы переключаете каждую третью лампочку (включаете, если она выключена, или выключаете, если она включена). 
    В ith раунде вы переключаете каждую i лампочку. В nth раунде вы переключаете только последнюю лампочку.
    Верните количество лампочек, которые горят после nраундов.
    Ограничения:
        0 <= n <= 10^9
    https://leetcode.com/problems/bulb-switcher/description/
     */
    public class Task319 : InfoBasicTask
    {
        private enum TypeSolution
        {
            None = 0,
            Slow = 1,
            Fast = 2,
            Both = 3
        }
        public Task319(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 10;
            Console.WriteLine($"Количество лампочек = {n}");
            if (isValid(n))
            {
                int res = 0;
                TypeSolution typeSolution = askUserTypeSolution();
                switch (typeSolution)
                {
                    case TypeSolution.Slow:
                        bool showAdditionalInfo = askUserToShowAdditionalInformation();
                        res = bulbSwitch(n, showAdditionalInfo);
                        Console.WriteLine($"Решение с помощью метода моделирования: количество включенных лампочек = {res}");
                        break;
                    case TypeSolution.Fast:
                        res = optimalAlgorithm(n);
                        Console.WriteLine($"Решение с помощью использования метода sqrt: количество включенных лампочек = {res}");
                        break;
                    case TypeSolution.Both:
                        res = bulbSwitch(n);
                        Console.WriteLine($"Решение с помощью метода моделирования: количество включенных лампочек = {res}");
                        res = optimalAlgorithm(n);
                        Console.WriteLine($"Решение с помощью использования метода sqrt: количество включенных лампочек = {res}");
                        break;
                }
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
            int lowLimit = 0;
            int highLimit = (int)Math.Pow(10, 9);
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            return true;
        }
        private int optimalAlgorithm(int n)
        {
            return (int)Math.Sqrt(n);
        }
        private int bulbSwitch(int n, bool showAdditionalInformation = false)
        {
            int count = 0;
            bool[] mass = new bool[n];
            for (int i = 1; i <= n; i++)
            {
                for (int index = i; index <= mass.Length; index += i)
                {
                    mass[index - 1] = !mass[index - 1];
                }
                if (showAdditionalInformation)
                {
                    Console.WriteLine($"Лампочки после {i} раунда");
                    for (int index = 0; index < mass.Length; index++)
                    {
                        if (index != mass.Length - 1)
                        {
                            Console.Write(mass[index] ? "True\t" : "False\t");
                        }
                        else
                        {
                            Console.Write(mass[index] ? "True\n" : "False\n");
                        }
                    }
                    count = 0;
                    foreach (bool b in mass)
                    {
                        if (b)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"Количество включенных лампочек после {i} раунда = {count}");
                }
            }
            count = 0;
            foreach (bool b in mass)
            {
                if (b)
                {
                    count++;
                }
            }
            return count;
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Медленный (моделирование процесса)\n" +
                    "2 - Быстрый (с помощтю функции sqrt)\n" +
                     "3 - Протестировать оба метода\n" +
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
                            return TypeSolution.None;
                        case 1:
                            return TypeSolution.Slow;
                        case 2:
                            return TypeSolution.Fast;
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

        private bool askUserToShowAdditionalInformation()
        {
            while (true)
            {
                Console.WriteLine("Отображать дополнительную информацию при решении:\n" +
                    "1 - Да\n" +
                    "0 - Нет");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 1)
                    {
                        throw new FormatException();
                    }
                    switch (choiceUser)
                    {
                        case 0:
                            return false;
                        case 1:
                            return true;
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
