using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task27
{
    public class Task27 : InfoBasicTask
    {
        public Task27(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            int val = 2;
            int result = removeElement(nums, val);
            Console.WriteLine($"Количество элементов, которые не равны искомому числу {val} = {result}");
            printResultArray(nums);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int removeElement(int[] nums, int val)
        {
            if (nums.Length < 1)
            {
                return 0;
            }
            int count = 0;
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    (nums[i], nums[index]) = (nums[index], nums[i]);
                    index++;
                }
                else
                {
                    count++;
                }
            }
            return nums.Length - count;
        }
        private void printResultArray(int[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст!");
            }
            else if (array.Length == 1)
            {
                Console.WriteLine($"Результат: [{array[0]}]");
            }
            else
            {
                Console.Write("Результат: ");
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == 0)
                    {
                        Console.Write($"[{array[i]}, ");
                    }
                    else if (i == array.Length - 1)
                    {
                        Console.Write($"{array[i]}]\n");
                    }
                    else
                    {
                        Console.Write($"{array[i]}, ");
                    }
                }
            }
        }
    }
}
