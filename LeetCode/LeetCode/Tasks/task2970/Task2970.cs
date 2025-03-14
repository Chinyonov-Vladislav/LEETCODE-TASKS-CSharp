using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2970
{
    /*
     2970. Подсчитайте количество увеличиваемых подмассивов I
    Вам дан массив с нулевой индексациейположительных целых чисел nums.
    Подмассив nums называется удаляемым, если nums становится строго возрастающим после удаления подмассива. 
        Например, подмассив [3, 4] является удаляемым подмассивом [5, 3, 4, 6, 7] потому, что удаление этого подмассива превращает массив [5, 3, 4, 6, 7] в [5, 6, 7] который является строго возрастающим.
    Верните общее количество увеличиваемых подмассивов nums.
    Обратите внимание, что пустой массив считается строго увеличивающимся.
    Подмассив — это непрерывная непустая последовательность элементов внутри массива.
    Ограничения:
        1 <= nums.length <= 50
        1 <= nums[i] <= 50
    https://leetcode.com/problems/count-the-number-of-incremovable-subarrays-i/description/
     */
    public class Task2970 : InfoBasicTask
    {
        public Task2970(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                int count = incremovableSubarrayCount(nums);
                Console.WriteLine($"Общее количество возрастающих массивов = {count}");
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
            if (nums.Length < 1 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 50)
                {
                    return false;
                }
            }
            return true;
        }
        private int incremovableSubarrayCount(int[] nums)
        {
            int count = 0;
            int length = 1;
            while (length <=nums.Length)
            {
                for (int i = 0; i <= nums.Length-length; i++)
                {
                    List<int> numbers = new List<int>();
                    int leftEnd = i;
                    int rightStart = i+length;
                    for (int j = 0; j < leftEnd; j++)
                    {
                        numbers.Add(nums[j]);
                    }
                    for (int j = rightStart; j < nums.Length; j++)
                    {
                        numbers.Add(nums[j]);
                    }
                   
                    if (numbers.Count <= 1)
                    {
                        count++;
                    }
                    else
                    {
                        bool isIncreasing = true;
                        for (int j = 1; j < numbers.Count; j++)
                        {
                            if (numbers[j] <= numbers[j - 1])
                            {
                                isIncreasing = false;
                                break;
                            }
                        }
                        if (isIncreasing)
                        {
                            count++;
                        }
                    }
                }
                length++;
            }
            return count;
        }
    }
}
