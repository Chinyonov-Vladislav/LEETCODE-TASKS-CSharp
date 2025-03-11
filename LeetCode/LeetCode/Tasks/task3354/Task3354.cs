using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3354
{
    /*
     3354. Сделать элементы массива равными нулю
    Вам предоставляется целочисленный массив nums.
    Для начала выберите начальную позицию curr так, чтобы nums[curr] == 0 и выберите направление движения влево или вправо.
    После этого вы повторяете следующий процесс:
        Если curr находится вне диапазона [0, n - 1], этот процесс завершается.
        Если nums[curr] == 0, двигайтесь в текущем направлении, увеличивая curr значение, если вы двигаетесь вправо, или уменьшая curr значение, если вы двигаетесь влево.
        Еще , если nums[curr] > 0:
            Уменьшите nums[curr] на 1.
            Измените направление вашего движения (левое становится правым и наоборот).
            Сделайте шаг в своем новом направлении.
    Выбор начальной позиции curr и направления движения считается правильным, если к концу процесса каждый элемент в nums становится равным 0.
    Возвращает количество возможных допустимых вариантов выбора.
    Ограничения:
        1 <= nums.length <= 100
        0 <= nums[i] <= 100
        Существует по крайней мере один элемент i where nums[i] == 0.
    https://leetcode.com/problems/make-array-elements-equal-to-zero/description/
     */
    public class Task3354 : InfoBasicTask
    {
        public Task3354(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 0, 2, 0, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int count = countValidSelections(nums);
                Console.WriteLine($"Количество возможных допустимых вариантов выбора = {count}");
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
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 0 || num > 100)
                {
                    return false;
                }
            }
            HashSet<int> set = new HashSet<int>(nums);
            if (!set.Contains(0))
            {
                return false;
            }
            return true;
        }
        private int countValidSelections(int[] nums)
        {
            int count = 0;
            List<int> indexsOfZero = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    indexsOfZero.Add(i);
                }
            }
            bool[] availableStartDirections = new bool[2] { false, true };
            foreach (int startIndex in indexsOfZero)
            {
                foreach (bool startDir in availableStartDirections)
                {
                    int curr = startIndex;
                    int[] copyNums = new int[nums.Length];
                    for (int i = 0; i < copyNums.Length; i++)
                    {
                        copyNums[i] = nums[i];
                    }
                    bool direction = startDir; // false - влево, true - вправо
                    while (curr >= 0 && curr < copyNums.Length)
                    {
                        if (copyNums[curr] == 0)
                        {
                            if (!direction)
                            {
                                curr--;
                            }
                            else
                            {
                                curr++;
                            }
                        }
                        else if (copyNums[curr] > 0)
                        {
                            copyNums[curr] -= 1;
                            direction = !direction;
                            if (!direction)
                            {
                                curr--;
                            }
                            else
                            {
                                curr++;
                            }
                        }
                    }
                    printArray(copyNums, "ТВАРЬ: ");
                    HashSet<int> uniqVal = new HashSet<int>(copyNums);
                    if (uniqVal.Count == 1 && uniqVal.Contains(0))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
