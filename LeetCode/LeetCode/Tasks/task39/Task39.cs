using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task39
{
    /*
     39. Сумма комбинации
    Учитывая массив различных целых чисел candidates и целевое целое число target, верните список всехуникальных комбинаций из candidates чисел, сумма которых равна target. 
    Вы можете возвращать комбинации в любом порядке.
    Одно и то же число может быть выбрано из candidatesнеограниченного количества раз. 
    Две комбинации уникальны, если частота хотя бы одного из выбранных чисел отличается.
    Тестовые примеры генерируются таким образом, чтобы количество уникальных комбинаций, сумма которых равна target, было меньше, чем 150 комбинаций для заданных входных данных.
    Ограничения:
        1 <= candidates.length <= 30
        2 <= candidates[i] <= 40
        Все элементы candidates различны.
        1 <= target <= 40
    https://leetcode.com/problems/combination-sum/description/
     */
    public class Task39 : InfoBasicTask
    {
        public Task39(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] candidates = new int[] { 2, 3, 6, 7 };
            int target = 7;
            printArray(candidates);
            Console.WriteLine($"Целевое число = {target}");
            if (isValid(candidates, target))
            {
                IList<IList<int>> result = combinationSum(candidates, target);
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
            if (candidates.Length < 1 || candidates.Length > 30)
            {
                return false;
            }
            foreach (int item in candidates)
            {
                if (item < 2 || item > 40)
                {
                    return false;
                }
            }
            HashSet<int> set = new HashSet<int>(candidates);
            if (set.Count != candidates.Length)
            {
                return false;
            }
            if (target < 1 || target > 40)
            {
                return false;
            }
            return true;
        }
        private IList<IList<int>> combinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> result = new List<IList<int>>();
            recursive(result, new List<int>(), candidates, target);
            return result;
        }
        private void recursive(IList<IList<int>> result, IList<int> currentCombination, int[] candidates, int target, int currentIndex = 0)
        {
            if (target == 0)
            {
                result.Add(new List<int>(currentCombination));
                return;
            }
            for (int i = currentIndex; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                {
                    continue;
                }
                currentCombination.Add(candidates[i]);
                recursive(result, currentCombination, candidates, target - candidates[i], i);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }
    }
}
