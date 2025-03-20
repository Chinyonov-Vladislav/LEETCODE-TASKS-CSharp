using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task287
{
    /*
     287. Найдите дубликат номера
    Дан массив целых чисел nums с n + 1 целыми числами, каждое из которых находится в диапазоне [1, n] включительно.
    В есть только одно повторяющееся числоnums, верните это повторяющееся число.
    Вы должны решить задачу, не изменяя массив nums и используя только постоянное дополнительное пространство.
    Ограничения:
        1 <= n <= 10^5
        nums.length == n + 1
        1 <= nums[i] <= n
        Все целые числа в nums встречаются только один раз, кроме ровно одного целого числа, которое встречается два или более раз.
    https://leetcode.com/problems/find-the-duplicate-number/description/
     */
    public class Task287 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Nothing = 0,
            Slow = 1,
            Fast = 2,
            Both = 3
        }
        public Task287(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 1, 3, 4, 2 };
            printArray(nums);
            if (isValid(nums))
            {
                TypeSolution choiceUser = askUserTypeSolution();
                int res = 0;
                switch (choiceUser)
                {
                    case TypeSolution.Slow:
                        res = findDuplicateSlowMethod(nums);
                        Console.WriteLine($"Результат, полученный с помощью метода перебора = {res}");
                        break;
                    case TypeSolution.Fast:
                        res = findDuplicateFastMethod(nums);
                        Console.WriteLine($"Результат, полученный с помощью метода \"черепахи и зайца\" (алгоритм Флойда для поиска циклов) = {res}");
                        break;
                    case TypeSolution.Both:
                        res = findDuplicateSlowMethod(nums);
                        Console.WriteLine($"Результат, полученный с помощью метода перебора = {res}");
                        res = findDuplicateFastMethod(nums);
                        Console.WriteLine($"Результат, полученный с помощью метода \"черепахи и зайца\" (алгоритм Флойда для поиска циклов) = {res}");
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
        private bool isValid(int[] nums)
        {
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10, 5);
            int n = nums.Length - 1;
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            highLimit = n;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            int countMoreOne = 0;
            foreach (var pair in dict)
            {
                if (pair.Value > 1)
                {
                    countMoreOne++;
                }
            }
            if (countMoreOne != 1)
            {
                return false;
            }
            return true;
        }
        private int findDuplicateSlowMethod(int[] nums)
        {
            int n = nums.Length - 1;
            int count = 0;
            int currentValue = 1;
            while (currentValue <= n)
            {
                count = 0;
                foreach (int num in nums)
                {
                    if (num == currentValue)
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    break;
                }
                currentValue++;
            }
            return currentValue;
        }
        private int findDuplicateFastMethod(int[] nums)
        {
            int slowPointer = nums[0];
            int fastPointer = nums[0];
            while (true)
            {
                slowPointer = nums[slowPointer];
                fastPointer = nums[nums[fastPointer]];
                if (slowPointer == fastPointer)
                {
                    break;
                }
            }
            slowPointer = nums[0];
            while (slowPointer != fastPointer)
            {
                slowPointer = nums[slowPointer];
                fastPointer = nums[fastPointer];
            }
            return slowPointer;
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Медленный перебор\n" +
                    "2 - Метод \"черепахи и зайца\" (алгоритм Флойда для поиска циклов)\n" +
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
    }
}
