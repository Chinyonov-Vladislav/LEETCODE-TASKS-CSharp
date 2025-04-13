using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task216
{
    /*
     216. Сумма комбинации III
    Найдите все допустимые комбинации из k чисел, сумма которых равна n, при которых выполняются следующие условия:
        Используются только цифры 1 через 9.
        Каждое число используется не более одного раза.
    Верните список всех возможных допустимых комбинаций. Список не должен содержать одну и ту же комбинацию дважды, а комбинации могут возвращаться в любом порядке.
    Ограничения:
        2 <= k <= 9
        1 <= n <= 60
    https://leetcode.com/problems/combination-sum-iii/description/
     */
    public class Task216 : InfoBasicTask
    {
        public Task216(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int neededCountNumbers = 3;
            int neededSum = 9;
            Console.WriteLine($"Необходимо количество чисел в комбинации = {neededCountNumbers}\nНеобходимая сумма комбинации = {neededSum}");
            if (isValid(neededCountNumbers, neededSum))
            {
                IList<IList<int>> result = combinationSum3(neededCountNumbers, neededSum);
                printIListIListInt(result, $"Допустимые комбинации из {neededCountNumbers} чисел от 1 до 9, которые в сумме дают {neededSum}: ");
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
        private bool isValid(int k, int n)
        {
            if (!(2 <= k && k <= 9) || !(1 <= n && n <= 60))
            {
                return false;
            }
            return true;
        }
        private IList<IList<int>> combinationSum3(int k, int n)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> currentCombination = new List<int>();
            recursive(result, currentCombination, 0, 1, k, n);
            return result;
        }
        private void recursive(IList<IList<int>> result, List<int> currentCombination, int currentSum, int startNumber, int neededCountNumbers, int neededSum)
        {
            if (currentCombination.Count == neededCountNumbers)
            {
                if (currentSum == neededSum)
                {
                    List<int> data = new List<int>(currentCombination);
                    result.Add(data);
                }
            }
            else if (currentCombination.Count < neededCountNumbers)
            {
                for (int i = startNumber; i <= 9; i++)
                {
                    currentCombination.Add(i);
                    recursive(result, currentCombination, currentSum + i, i + 1, neededCountNumbers, neededSum);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }
        }
    }
}
