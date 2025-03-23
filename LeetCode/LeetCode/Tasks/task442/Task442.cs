using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task442
{
    /*
     442. Найдите все дубликаты в массиве
    Учитывая целочисленный массив nums длиной n, где все целочисленные значения nums находятся в диапазоне [1, n] и каждое целочисленное значение встречается не более дважды, верните массив всех целочисленных значений, которые встречаютсядважды.
    Вы должны написать алгоритм, который работает за O(n) секунд и использует только постоянное вспомогательное пространство, не считая пространства, необходимого для хранения результата
    Ограничения:
        n == nums.length
        1 <= n <= 10^5
        1 <= nums[i] <= n
        Каждый элемент в nums появляется один или дважды.
    https://leetcode.com/problems/find-all-duplicates-in-an-array/description/
     */
    public class Task442 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Nothing = 0,
            FirstMethod = 1,
            SecondMethod = 2,
            Both = 3
        }
        public Task442(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                IList<int> result = null;
                TypeSolution typeSolution = askUserTypeSolution();
                switch (typeSolution)
                {
                    case TypeSolution.FirstMethod:
                        result = findDuplicates(nums);
                        printIListInt(result, "Дубликаты, найденные с помощью метода сортировки и просмотра соседних элементов: ");
                        break;
                    case TypeSolution.SecondMethod:
                        result = optimizedAlgorithm(nums);
                        printIListInt(result, "Дубликаты, найденные с помощью метода использования индексов массива для отметки встречаемости элементов: ");
                        break;
                    case TypeSolution.Both:
                        result = findDuplicates(nums);
                        printIListInt(result, "Дубликаты, найденные с помощью метода сортировки и просмотра соседних элементов: ");
                        result = optimizedAlgorithm(nums);
                        printIListInt(result, "Дубликаты, найденные с помощью метода использования индексов массива для отметки встречаемости элементов: ");
                        break;
                }
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
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10, 5);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (num < lowLimit || num > nums.Length)
                {
                    return false;
                }
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            foreach (var pair in dict)
            {
                if (pair.Value < 1 || pair.Value > 2)
                {
                    return false;
                }
            }
            return true;
        }
        private IList<int> optimizedAlgorithm(int[] nums)
        {
            IList<int> res = new List<int>();
            foreach(int num in nums)
            {
                int index = Math.Abs(num) - 1;
                if (nums[index] < 0)
                {
                    res.Add(Math.Abs(num));
                }
                else
                {
                    nums[index] = -1 * nums[index];
                }
            }
            return res;
        }
        private IList<int> findDuplicates(int[] nums)
        {
            IList<int> res = new List<int>();
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i])
                {
                    res.Add(nums[i]);
                }
            }
            return res;
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Сортировка и просмотр соседних элементов\n" +
                    "2 - Использование индексов массива для отметки встречаемости элементов\n" +
                    "3 - Протестировать оба решения\n" +
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 3)
                    {
                        throw new FormatException();
                    }
                    switch (choiceUser)
                    {
                        case 0:
                            return TypeSolution.Nothing;
                        case 1:
                            return TypeSolution.FirstMethod;
                        case 2:
                            return TypeSolution.SecondMethod;
                        case 3:
                            return TypeSolution.Both;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
        }
    }
}
