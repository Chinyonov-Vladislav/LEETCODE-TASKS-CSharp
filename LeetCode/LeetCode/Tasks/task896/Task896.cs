using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task896
{
    /*
     896. Монотонный массив
     Массив является монотонным, если он либо монотонно возрастает, либо монотонно убывает.
    Массив nums монотонно увеличивается, если для всех i <= j, nums[i] <= nums[j]. Массив nums монотонно уменьшается, если для всех i <= j, nums[i] >= nums[j].
    Учитывая целочисленный массив nums, верните true если заданный массив является монотонным, или false иначе.
     */
    public class Task896 : InfoBasicTask
    {
        public Task896(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 2, 3 };
            Console.WriteLine(isMonotonic(nums) ? "Массив монотонно убывает или возрастает" : "Массив монотонно не убывает и не возрастает");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public bool isMonotonic(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return true;
            }
            bool isMonoticIncrease = true;
            bool isMonoticDecrease = true;
            for (int i = 1; i < nums.Length; i++) // проверка на монотонное возрастание
            {
                if (!(nums[i - 1] <= nums[i]))
                {
                    isMonoticIncrease = false;
                    break;
                }
            }
            for (int i = 1; i < nums.Length; i++)
            {
                if (!(nums[i - 1] >= nums[i])) // проверка на монотонное убывание
                {
                    isMonoticDecrease = false;
                    break;
                }
            }
            if (isMonoticIncrease || isMonoticDecrease)
            {
                return true;
            }
            return false;
        }
    }
}
