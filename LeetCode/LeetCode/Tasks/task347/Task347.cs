using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task347
{
    /*
     347. Топ K часто встречающихся элементов
    Учитывая целочисленный массив nums и целое число k, верните наиболее k часто встречающиеся элементы. Вы можете возвращать ответ в любом порядке.
    Ограничения:
        1 <= nums.length <= 10^5
        -10^4 <= nums[i] <= 10^4
        k находится в пределах досягаемости [1, the number of unique elements in the array].
        Гарантируется, что ответ будет уникальным.
    https://leetcode.com/problems/top-k-frequent-elements/description/
     */
    public class Task347 : InfoBasicTask
    {
        public Task347(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 1, 1, 2, 2, 3 };
            printArray(nums);
            int k = 2;
            Console.WriteLine($"Необходимо найти {k} наиболее встречающихся элементов");
            if (isValid(nums, k))
            {
                int[] res = topKFrequent(nums, k);
                printArray(res, $"{k} наиболее встречающиеся элементы: ");
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
        private bool isValid(int[] nums, int k)
        {
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10,5);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = -1 * (int)Math.Pow(10, 4);
            highLimit = (int)Math.Pow(10, 4);
            foreach (int num in nums)
            {
                if (num< lowLimit || num>highLimit)
                {
                    return false;
                }
            }
            lowLimit = 1;
            HashSet<int> set = new HashSet<int>(nums);
            highLimit = set.Count;
            if (k < lowLimit || k > highLimit)
            {
                return false;
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            HashSet<int> freqSet = new HashSet<int>();
            foreach (var pair in dict)
            {
                int sizeBeforeAdd = freqSet.Count;
                freqSet.Add(pair.Value);
                int sizeAfterAdd = freqSet.Count;
                if (sizeAfterAdd == sizeBeforeAdd)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] topKFrequent(int[] nums, int k)
        {
            int[] result = new int[k];
            Dictionary<int,int> dict = new Dictionary<int,int>();
            foreach (int num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            List<int> list = dict.OrderByDescending(x => x.Value).ToDictionary(item=>item.Key, item => item.Value).Keys.ToList();
            int pointer = 0;
            while (pointer < k)
            {
                result[pointer] = list[pointer];
                pointer++;
            }
            return result;
        }
    }
}
