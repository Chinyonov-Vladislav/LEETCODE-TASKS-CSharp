using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task80
{
    /*
     80. Удалите дубликаты из отсортированного массива II
    Дан целочисленный массив nums, отсортированный в порядке неубывания. 
    Удалите некоторые дубликаты на месте, чтобы каждый уникальный элемент встречался не более двух раз.
    Относительный порядок элементов должен остаться прежним.
    Поскольку в некоторых языках невозможно изменить длину массива, вместо этого нужно поместить результат в первую часть массива nums. 
    Если говорить более формально, то если после удаления дубликатов осталось k элементов, то первые k элементов nums должны содержать конечный результат. 
    Неважно, что вы оставите после первых k элементов.
    Вернитесь k после размещения конечного результата в первых k ячейках nums.
    Не выделяйте дополнительное пространство для другого массива. Вы должны сделать это, изменив входной массивна месте с помощью O(1) дополнительной памяти.
    Ограничения:
        1 <= nums.length <= 3 * 10^4
        -10^4 <= nums[i] <= 10^4
        nums сортируется в неубывающем порядке.
    https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/description/
     */
    public class Task80 : InfoBasicTask
    {
        public Task80(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 1, 1, 2, 2, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int k = removeDuplicates(nums);
                Console.WriteLine($"Количество рассматриваемых элементов с начала строки = {k}");
                printResult(nums, k);
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
            int highLimit = 3 * (int)Math.Pow(10, 4);
            if (nums.Length < 1 || nums.Length > highLimit)
            {
                return false;
            }
            int lowLimit = -1 * (int)Math.Pow(10, 4);
            highLimit = (int)Math.Pow(10, 4);
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            if (nums.Length > 1)
            {
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] < nums[i - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int removeDuplicates(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 1;
            }
            int k = 0;
            int index = 0;
            int currentElement = nums[index];
            int freq = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == currentElement)
                {
                    freq++;
                }
                else
                {
                    if (freq <= 2)
                    {
                        k += freq;
                        nums[index] = currentElement;
                        index++;
                        if (freq == 2)
                        {
                            nums[index] = currentElement;
                            index++;
                        }
                    }
                    else
                    {
                        k += 2;
                        nums[index] = currentElement;
                        nums[index+1] = currentElement;
                        index += 2;
                    }
                    currentElement = nums[i];
                    freq = 1;
                }
                if (i == nums.Length - 1)
                {
                    if (freq <= 2)
                    {
                        k += freq;
                        nums[index] = currentElement;
                        index++;
                        if (freq == 2)
                        {
                            nums[index] = currentElement;
                            index++;
                        }
                    }
                    else
                    {
                        k += 2;
                        nums[index] = currentElement;
                        nums[index + 1] = currentElement;
                        index += 2;
                    }
                }
            }
            return k;
        }
        private void printResult(int[] nums, int k)
        {
            Console.Write("Результат: ");
            for (int i = 0; i < nums.Length; i++)
            {
                string printedStr = nums[i].ToString();
                if (i >= k)
                {
                    printedStr = "_";
                }
                if (i == 0)
                {
                    Console.Write($"[{printedStr}, ");
                }
                else if (i == nums.Length - 1)
                {
                    Console.WriteLine($"{printedStr}]");
                }
                else
                {
                    Console.Write($"{printedStr}, ");
                }
            }
        }
        // скопировано с leetcode
        private int bestSolution(int[] nums)
        {
            int k = 2;
            if (nums.Length < 2) return 1;
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[k - 2])
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;
        }
        
    }
}
