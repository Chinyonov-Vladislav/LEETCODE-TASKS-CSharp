using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3379
{
    /*
     3379. Преобразованный массив
    Вам дан целочисленный массив nums, представляющий собой круговой массив. Ваша задача — создать новый массив result того же размера, следуя этим правилам:
    Для каждого индекса i (где 0 <= i < nums.length), выполните следующие независимые действия:
        Если nums[i] > 0: начните с индекса i и пройдите nums[i] шагов вправо по циклическому массиву. Задайте result[i] значение индекса, на котором вы остановитесь.
        Если nums[i] < 0: начните с индекса i и переместитесь на abs(nums[i]) шагов влево в циклическом массиве. Задайте result[i] значение индекса, на котором вы остановитесь.
        Если nums[i] == 0: Установите result[i] значение nums[i].
    Возвращает новый массив result.
    Примечание: поскольку nums является циклом, перемещение за пределы последнего элемента возвращает к началу, а перемещение перед первым элементом возвращает к концу.
    Ограничения:
        1 <= nums.length <= 100
        -100 <= nums[i] <= 100
    https://leetcode.com/problems/transformed-array/description/
     */
    public class Task3379 : InfoBasicTask
    {
        public Task3379(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, -2, 1, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                int[] result = constructTransformedArray(nums);
                printArray(result, "Результирующий массив: ");
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
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < -100 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] constructTransformedArray(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    int newIndex = i;
                    for (int step = 0; step < nums[i]; step++)
                    {
                        newIndex++;
                        if (newIndex == nums.Length)
                        {
                            newIndex = 0;
                        }
                    }
                    result[i] = nums[newIndex];
                }
                else if (nums[i] < 0)
                {
                    int newIndex = i;
                    for (int step = 0; step < Math.Abs(nums[i]); step++)
                    {
                        newIndex--;
                        if (newIndex == -1)
                        {
                            newIndex = nums.Length-1;
                        }
                    }
                    result[i] = nums[newIndex];
                }
                else
                {
                    result[i] = nums[i];
                }
            }
            return result;
        }
    }
}
