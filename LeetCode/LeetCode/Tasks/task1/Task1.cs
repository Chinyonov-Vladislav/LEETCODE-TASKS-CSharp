using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace LeetCode.Tasks.Task1
{
    public class Task1 : InfoBasicTask
    {
        private const int codeOfFirstMethod = 1;
        private const int codeOfSecondMethod = 2;

        public Task1(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int countElementsInArray = 0;
            while (true)
            {
                Console.Write("Введите количество элементов для массива: ");
                try
                {
                    countElementsInArray = Int32.Parse(Console.ReadLine());
                    if (countElementsInArray < 1)
                    {
                        throw new FormatException();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
            int[] nums = new int[countElementsInArray];
            int countEnteredNumbers = 0;
            while (countEnteredNumbers < countElementsInArray)
            {
                Console.Write($"Введите значение {countEnteredNumbers+1} элемента для массива: ");
                try
                {
                    nums[countEnteredNumbers] = Int32.Parse(Console.ReadLine());
                    countEnteredNumbers++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение для элемента массива. Введите целое число! Повторите попытку!");
                }
            }
            int targetNumber = 0;
            while (true) {
                Console.Write($"Введите значение для целового числа: ");
                try
                {
                    targetNumber = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение для целевого числа. Введите целое число! Повторите попытку!");
                }
            }
            int methodExecution = askUserOfMethod();
            int[] indexs = null;
            switch (methodExecution)
            {
                case codeOfFirstMethod:
                    indexs = twoSumFirstMethod(nums, targetNumber);
                    break;
                case codeOfSecondMethod:
                    indexs = twoSumSecondMethod(nums, targetNumber);
                    break;
            }
            if (indexs == null)
            {
                Console.WriteLine("Решение отсутствует");
            }
            else
            {
                Console.WriteLine($"Первый индекс = {indexs[0]}. Значение элемента массива = {nums[indexs[0]]}");
                Console.WriteLine($"Второй индекс = {indexs[1]}. Значение элемента массива = {nums[indexs[1]]}");
            }
        }

        public override void testing()
        {
            testCase1();
        }

        private int[] twoSumFirstMethod(int[] nums, int target)
        {
            for (int firstIndex = 0; firstIndex < nums.Length; firstIndex++)
            {
                for (int secondIndex = 0; secondIndex < nums.Length; secondIndex++)
                {
                    if (firstIndex == secondIndex)
                    {
                        continue;
                    }
                    if (nums[firstIndex] + nums[secondIndex] == target)
                    {
                        return new int[] { firstIndex, secondIndex }; 
                    }
                }
            }
            return null;
        }

        private int askUserOfMethod()
        {
            while (true)
            {
                Console.WriteLine("Выберите метод для выполнения: 1 - на основе двух массивов, 2 - на основании словаря");
                Console.Write("Ваш выбор: ");
                try
                {
                    int methodExecution = Int32.Parse(Console.ReadLine());
                    if (methodExecution < 1 || methodExecution > 2)
                    {
                        throw new FormatException();
                    }
                    return methodExecution;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введен неверный номер метода. Повторите попытку!");
                }
            }
        }

        private int[] twoSumSecondMethod(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int difference = target - nums[i];
                if (dict.ContainsValue(difference))
                {
                    return new int[] { i, dict.First(valueDict => valueDict.Value == difference).Key };
                }
                dict.Add(i, nums[i]);
            }
            return null;
        }

        private bool AreArraysEqualIgnoringOrder(int[] array1, int[] array2)
        {
            // Проверяем равенство длин
            if (array1.Length != array2.Length)
            {
                return false;
            }
            // Сравниваем элементы без учета порядка
            return array1.OrderBy(x => x).SequenceEqual(array2.OrderBy(x => x));
        }

        [Fact]
        private void testCase1()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            int target = 9;
            int[] expected = new int[] { 4,3,5,6 };
            int[] actual = twoSumFirstMethod(nums, target);
            try
            {
                //Assert.Equal(expected, actual);
                Assert.True(AreArraysEqualIgnoringOrder(expected, actual), "Массивы не равны");
                Console.WriteLine("Тест пройден");
            }
            catch (TrueException ex)
            {
                Console.WriteLine("Тест не пройден");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
