using LeetCode.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task40
{
    /*
     40. Сумма комбинации II
    Учитывая набор чисел-кандидатов (candidates) и целевое число (target), найдите все уникальные комбинации в candidates такие, что сумма чисел-кандидатов равна target.
    Каждое число в candidates комбинации может быть использовано только один раз.
    Примечание: Набор решений не должен содержать повторяющихся комбинаций.
    Ограничения:
        1 <= candidates.length <= 100
        1 <= candidates[i] <= 50
        1 <= target <= 30
     */
    public class Task40 : InfoBasicTask
    {
        public Task40(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] candidates = new int[] { 10, 1, 2, 7, 6, 1, 5 };
            int target = 8;
            printArray(candidates, "Массив кандидатов: ");
            Console.WriteLine($"Целевая сумма = {target}");
            if (isValid(candidates, target))
            {
                IList<IList<int>> result = combinationSum2(candidates, target);
                Console.WriteLine($"-----Результат-----");
                printIListIListInt(result);
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
        private bool isValid(int[] candidates, int target)
        {
            int lowLimit = 1;
            int highLimit = 100;
            if (candidates.Length < lowLimit || candidates.Length > highLimit)
            {
                return false;
            }
            lowLimit = 1;
            highLimit = 50;
            foreach (int candidate in candidates) {
                if (candidate < 1 || candidate > highLimit)
                {
                    return false;
                }
            }
            lowLimit = 1;
            highLimit = 30;
            if (target < lowLimit || target > highLimit)
            {
                return false;
            }
            return true;
        }
        private IList<IList<int>> combinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);

            IList<IList<int>> result = new List<IList<int>>();
            IList<int> currentCombination = new List<int>();
            int currentSum = 0;
            recursive(result, currentCombination, candidates, 0, currentSum, target);
            Console.WriteLine("-----Результат-----");
            printIListIListInt(result);
            return result;
        }
        private void recursive(IList<IList<int>> result, IList<int> currentCombination, int[] candidates, int currentStartIndex, int currentSum, int target)
        {
            for (int i = currentStartIndex; i < candidates.Length; i++)
            {
                if (i > currentStartIndex && candidates[i] == candidates[i - 1])
                {
                    continue;
                }
                if (currentSum + candidates[i] == target)
                {
                    List<int> addedCombination = new List<int>(currentCombination)
                {
                    candidates[i]
                };
                    result.Add(addedCombination);
                    break;
                }
                else if (currentSum + candidates[i] < target)
                {
                    currentCombination.Add(candidates[i]);
                    recursive(result, currentCombination, candidates, i + 1, currentSum + candidates[i], target);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
