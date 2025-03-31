using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task611
{
    /*
     611. Количество действительных треугольников
    Учитывая целочисленный массив nums, верните количество троек, выбранных из массива, которые могут образовать треугольник, если мы возьмём их за длины сторон треугольника.
    Ограничения:
        1 <= nums.length <= 1000
        0 <= nums[i] <= 1000
    https://leetcode.com/problems/valid-triangle-number/description/
     */
    public class Task611 : InfoBasicTask
    {
        private enum TypeSolution
        {
            None = 0,
            Naive = 1,
            Optimized = 2,
            Both = 3
        }
        public Task611(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 2, 3, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = 0;
                TypeSolution typeSolution = askUserTypeSolution();
                switch (typeSolution)
                {
                    case TypeSolution.Naive:
                        res = triangleNumber(nums);
                        Console.WriteLine($"Решение, полученное с помощью наивного метода: количество треугольников = {res}");
                        break;
                    case TypeSolution.Optimized:
                        res = triangleNumberOptimal(nums);
                        Console.WriteLine($"Решение, полученное с помощью оптимизированного метода: количество треугольников = {res}");
                        break;
                    case TypeSolution.Both:
                        res = triangleNumber(nums);
                        Console.WriteLine($"Решение, полученное с помощью наивного метода: количество треугольников = {res}");
                        res = triangleNumberOptimal(nums);
                        Console.WriteLine($"Решение, полученное с помощью оптимизированного метода: количество треугольников = {res}");
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
            int lowLimitLengthNums = 1;
            int highLimitLengthNums = 1000;
            int lowLimitValueNums = 0;
            int highLimitValueNums = 1000;
            if (nums.Length < lowLimitLengthNums || nums.Length > highLimitLengthNums)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < lowLimitValueNums || num > highLimitValueNums)
                {
                    return false;
                }
            }
            return true;
        }
        private int triangleNumber(int[] nums)
        {
            Array.Sort(nums);
            int count = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    int firstSum = nums[i] + nums[j];
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        int secondSum = nums[i] + nums[k];
                        int thirdSum = nums[j] + nums[k];
                        if (firstSum > nums[k] && secondSum > nums[j] && thirdSum > nums[i])
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        private int triangleNumberOptimal(int[] nums) // скопировано с leetcode
        {
            //for a triplet to be valid sides of a triangle; sum of two smaller numbers should be greater than the biggest number. 
            int tripcount = 0;
            Array.Sort(nums);
            for (int k = nums.Length - 1; k >= 2; k--)
            {
                //find i, j where their total is greater than k
                int i = 0; 
                int j = k - 1;
                while (i < j)
                {
                    int sum = nums[i] + nums[j];
                    if (sum > nums[k])
                    {
                        //found a valid triplet
                        tripcount += j - i;
                        j--;
                    }
                    else
                    {
                        //i+j is smaller. move i to right; so sum increases
                        i++;
                    }
                }
            }
            return tripcount;
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Наивное решение (три цикла)\n" +
                    "2 - Быстрое решение (с использование бинарного поиска)\n" +
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
                            return TypeSolution.None;
                        case 1:
                            return TypeSolution.Naive;
                        case 2:
                            return TypeSolution.Optimized;
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
