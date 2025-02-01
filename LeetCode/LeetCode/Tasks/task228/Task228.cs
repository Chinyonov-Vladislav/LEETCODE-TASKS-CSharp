using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task228
{
    public class Task228 : InfoBasicTask
    {
        public Task228(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { -1 };
            IList<string> results = summaryRanges(nums);
            printIListString(results, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<string> summaryRanges(int[] nums)
        {
            IList<string> result = new List<string>();
            if (nums.Length == 0)
            {
                return result;
            }
            if (nums.Length == 1)
            {
                result.Add(nums[0].ToString());
                return result;
            }
            List<int> subRange = new List<int>();
            for (int i = 0; i < nums.Length - 1;i++)
            {
                subRange.Add(nums[i]);
                if (nums[i] + 1 != nums[i + 1])
                {
                    if (subRange.Count == 1)
                    {
                        result.Add($"{subRange[0]}");
                    }
                    else
                    {
                        result.Add($"{subRange[0]}->{subRange[subRange.Count - 1]}");
                    }
                    subRange.Clear();
                }
            }
            subRange.Add(nums[nums.Length - 1]);
            if (subRange.Count == 1)
            {
                result.Add($"{subRange[0]}");
            }
            else if (subRange.Count == 2)
            {
                if (subRange[0] + 1 == subRange[1])
                {
                    result.Add($"{subRange[0]}->{subRange[subRange.Count - 1]}");
                }
                else
                {
                    result.Add($"{subRange[0]}");
                    result.Add($"{subRange[1]}");
                }
            }
            else
            {
                if (subRange[subRange.Count - 2] + 1 == subRange[subRange.Count - 1])
                {
                    result.Add($"{subRange[0]}->{subRange[subRange.Count - 1]}");
                }
                else
                {
                    result.Add($"{subRange[0]}->{subRange[subRange.Count - 2]}");
                    result.Add($"{subRange[subRange.Count-1]}");
                }
            }
            return result;
        }
        private IList<string> bestSolution(int[] nums)
        {
            List<string> ranges = new List<string>();
            if (nums.Length == 0)
            {
                return ranges;
            }
            int currentMin = nums[0];
            int currentMax = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > currentMax + 1)
                {
                    if (currentMin == currentMax)
                    {
                        ranges.Add(currentMax.ToString());
                    }
                    else
                    {
                        ranges.Add(currentMin.ToString() + "->" + currentMax.ToString());
                    }
                    currentMin = nums[i];
                    currentMax = nums[i];
                }
                else
                {
                    currentMax++;
                }
            }
            if (currentMin == currentMax)
            {
                ranges.Add(currentMax.ToString());
            }
            else
            {
                ranges.Add(currentMin.ToString() + "->" + currentMax.ToString());
            }

            return ranges;
        }
    }
}
