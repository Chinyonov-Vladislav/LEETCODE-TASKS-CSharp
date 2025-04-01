using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task754
{
    /*
     754. Достичь номера
    ы находитесь в точке 0 на бесконечной числовой прямой. В точке target находится пункт назначения.
    Вы можете сделать некоторое количество ходов numMoves так, чтобы:
        На каждом ходу вы можете идти либо влево, либо вправо.
        Во время перемещения ith (начиная с i == 1 и заканчивая i == numMoves), вы делаете i шагов в выбранном направлении.
    Учитывая целое число target, верните минимальное количество ходов, требуемое (т.е. Минимальное numMoves) для достижения пункта назначения.
    Ограничения:
        -10^9 <= target <= 10^9
        target != 0
    https://leetcode.com/problems/reach-a-number/description/
     */
    public class Task754 : InfoBasicTask
    {
        private enum TypeSolution
        {
            None,
            BFS,
            Math,
            Both
        }
        public Task754(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int target = 25;
            Console.WriteLine($"Целевое число = {target}");
            if (isValid(target))
            {
                int res = 0;
                TypeSolution typeSolution = askUserTypeSolution();
                switch (typeSolution)
                {
                    case TypeSolution.BFS:
                        res = reachNumber(target);
                        Console.WriteLine($"Решение с помощью метода поиска в ширину: минимальное количество шагов для достижения числа {target} = {res}");
                        break;
                    case TypeSolution.Math:
                        res = optimalAlgorithm(target);
                        Console.WriteLine($"Решение на основании математических свойств: минимальное количество шагов для достижения числа {target} = {res}");
                        break;
                    case TypeSolution.Both:
                        res = reachNumber(target);
                        Console.WriteLine($"Решение с помощью метода поиска в ширину: минимальное количество шагов для достижения числа {target} = {res}");
                        res = optimalAlgorithm(target);
                        Console.WriteLine($"Решение на основании математических свойств: минимальное количество шагов для достижения числа {target} = {res}");
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
        private bool isValid(int target)
        {
            int lowLimit = -1 * (int)Math.Pow(10, 9);
            int highLimit = (int)Math.Pow(10, 9);
            if (target == 0 || target<lowLimit || target>highLimit)
            {
                return false;
            }
            return true;
        }
        private int reachNumber(int target)
        {
            int start = 0;
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { start, 1 });
            int res = 0;
            while (true)
            {
                int[] currentPosition = queue.Dequeue();
                if (currentPosition[0] == target)
                {
                    res = currentPosition[1]-1;
                    break;
                }
                queue.Enqueue(new int[] { currentPosition[0] + currentPosition[1], currentPosition[1]+1 });
                queue.Enqueue(new int[] { currentPosition[0] - currentPosition[1], currentPosition[1] + 1 });
            }
            return res;
        }
        private int optimalAlgorithm(int target) // скопировано с leetcode
        {
            target = Math.Abs(target);
            int n = 0;
            int S = 0;
            while (S < target || (S - target) % 2 != 0)
            {
                n += 1;
                S += n;
            }
            return n;
        }

        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Решение на основании поиска в ширину (не рекомендуется)\n" +
                    "2 - Решение на основании математики\n" +
                     "3 - Протестировать оба варианта\n" +
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
                            return TypeSolution.BFS;
                        case 2:
                            return TypeSolution.Math;
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
