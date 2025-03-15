using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task31
{
    /*
     31. Следующая перестановка
    Перестановка элементов массива целых чисел — это расположение его элементов в последовательности или линейном порядке.
    Например, для arr = [1,2,3] все возможные перестановки arr: [1,2,3], [1,3,2], [2, 1, 3], [2, 3, 1], [3,1,2], [3,2,1]
    Следующая перестановка массива целых чисел — это следующая лексикографически большая перестановка его элементов. 
    Если говорить более формально, то если все перестановки массива отсортированы в одном контейнере в лексикографическом порядке, то следующей перестановкой этого массива будет перестановка, следующая за ней в отсортированном контейнере. 
    Если такое расположение невозможно, массив должен быть переставлен в наименьший возможный порядок (то есть отсортирован по возрастанию).
        Например, следующая перестановка arr = [1,2,3] является [1,3,2].
        Аналогично, следующая перестановка arr = [2,3,1] является [3,1,2].
        В то время как следующая перестановка arr = [3,2,1] — это [1,2,3], потому что [3,2,1] не имеет лексикографически более крупной перестановки.
    Учитывая массив целых чисел nums, найдите следующую перестановку nums.
    Замена должна быть на месте и использовать только постоянную дополнительную память.
    Ограничения:
        1 <= nums.length <= 100
        0 <= nums[i] <= 100
    https://leetcode.com/problems/next-permutation/description/
     */
    public class Task31 : InfoBasicTask
    {
        public Task31(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 2, 1 };
            printArray(nums, "Текущая перестановка: ");
            if (isValid(nums))
            {
                nextPermutation(nums);
                printArray(nums, "Следующая перестановка: ");
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
                if (num < 0 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private void nextPermutation(int[] nums)
        {
            int n = nums.Length;
            int i = n - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i >= 0)
            {
                int j = n - 1;
                while (j >= 0 && nums[j] <= nums[i])
                {
                    j--;
                }
                (nums[i], nums[j]) = (nums[j], nums[i]);
            }
            int left = i + 1;
            int right = nums.Length - 1;
            while (left <= right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
        }
    }
}
