using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.Tasks.task77
{
    /*
     77. Комбинации
    Учитывая два целых числа n и k, верните все возможные комбинации из k чисел, выбранных из диапазона [1, n].
    Вы можете вернуть ответ в любом порядке.
    Ограничения:
        1 <= n <= 20
        1 <= k <= n
    https://leetcode.com/problems/combinations/description/
     */
    public class Task77 : InfoBasicTask
    {
        public Task77(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 4;
            int k = 2;
            Console.WriteLine($"Диапазон: [{1},{n}]\nКоличество элементов в комбинации = {k}");
            if (isValid(n, k))
            {
                IList<IList<int>> res = combine(n, k);
                Console.WriteLine($"Результат: ");
                printIListIListInt(res);
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
        private bool isValid(int n, int k)
        {
            if (n < 1 || n > 20)
            {
                return false;
            }
            if (k < 1 | k > n)
            {
                return false;
            }
            return true;
        }
        private IList<IList<int>> combine(int n, int k)
        {
            IList<IList<int>> res = new List<IList<int>>();
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = i+1;
            }
            combinations(numbers, k, 0, new int[k], res);
            return res;
        }
        private void combinations(int[] arr, int len, int startPosition, int[] currentResult, IList<IList<int>> res)
        {
            if (len == 0)
            {
                res.Add(currentResult.ToList());
                return;
            }
            for (int i = startPosition; i <= arr.Length - len; i++)
            {
                currentResult[currentResult.Length - len] = arr[i];
                combinations(arr, len - 1, i + 1, currentResult, res);
            }
        }
    }
}
