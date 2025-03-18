using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.Tasks.task77
{
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
            IList<IList<int>> res = combine(n, k);
            Console.WriteLine($"Результат: ");
            printIListIListInt(res);
        }

        public override void testing()
        {
            throw new NotImplementedException();
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
