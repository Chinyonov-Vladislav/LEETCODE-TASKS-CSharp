using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task167
{
    /*
     167. Two Sum II - Входной массив Отсортирован
    Учитывая 1-индексированный массив целых чисел, numbers который уже отсортирован в порядке неубывания, найдите два числа, такие, чтобы в сумме они составляли определенное target число. Пусть эти два числа равны numbers[index1] и numbers[index2] где 1 <= index1 < index2 <= numbers.length.
    Верните индексы двух чисел, index1 и index2, увеличенные на единицу, в виде целочисленного массива [index1, index2] длиной 2.
    Тесты генерируются таким образом, чтобы существовало ровно одно решение. Вы не можете использовать один и тот же элемент дважды.
    Ваше решение должно использовать только постоянное дополнительное пространство.
    Ограничения:
        2 <= numbers.length <= 3 * 10^4
        -1000 <= numbers[i] <= 1000
        numbers сортируется в неубывающем порядке.
        -1000 <= target <= 1000
        Тесты генерируются таким образом, что существует ровно одно решение.
    https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
     */
    public class Task167 : InfoBasicTask
    {
        public Task167(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] numbers = new int[] { 2, 7, 11, 15 };
            int target = 9;
            if (isValid(numbers, target))
            {
                int[] res = twoSum(numbers, target);
                Console.WriteLine($"Индекс первого элемента = {res[0]} (индексация с единицы)\nИндекс второго элемента = {res[1]} (индексация с единицы)");
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
        private bool isValid(int[] numbers, int target)
        {
            int lowLimit = 2;
            int highLimit = 3*(int)Math.Pow(10,4);
            if (numbers.Length < lowLimit || numbers.Length > highLimit)
            {
                return false;
            }
            lowLimit = -1000;
            highLimit = 1000;
            if (target < lowLimit || target > highLimit)
            {
                return false;
            }
            foreach (int number in numbers)
            {
                if(number<lowLimit || number>highLimit)
                {
                    return false;
                }
            }
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] > numbers[i])
                {
                    return false;
                }
            }
            int countSolutions = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        countSolutions++;
                    }
                }
            }
            if (countSolutions != 1)
            {
                return false;
            }
            return true;
        }
        private int[] twoSum(int[] numbers, int target)
        {
            int[] result = new int[2];
            int left = 0;
            int right = numbers.Length-1;
            while (left < right)
            {
                int currentSum = numbers[left] + numbers[right];
                if (currentSum == target)
                {
                    result[0] = left +1;
                    result[1] = right + 1;
                    break;
                }
                if (currentSum > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return result;
        }
    }
}
