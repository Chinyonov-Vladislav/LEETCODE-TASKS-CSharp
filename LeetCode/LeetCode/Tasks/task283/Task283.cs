using System;
using LeetCode.Basic;

namespace LeetCode.Tasks.task283
{
    /*
     283. Переместить Нули

    Дан целочисленный массив nums, переместите все 0 в его конец, сохранив относительный порядок ненулевых элементов.
    Обратите внимание, что вы должны сделать это на месте, не создавая копию массива.
     */
    public class Task283 : InfoBasicTask
    {
        public Task283(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 0, 1, 0, 3, 12 };
            moveZeroesMethodTwo(array);
            printArray(array, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private void moveZeroesMethodTwo(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return;
            }
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    (nums[i], nums[index]) = (nums[index], nums[i]);
                    index++;
                }
            }
        }
        private void moveZeroes(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return;
            }
            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                if (nums[start] != 0)
                {
                    start++;
                    continue;
                }
                if (nums[end] == 0)
                {
                    end--;
                    continue;
                }
                if (nums[start] == 0)
                {
                    (nums[start], nums[end]) = (nums[end], nums[start]);
                    start++;
                    end--;
                }
            }
        }
        
    }
}
