using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2154
{
    /*
     2154. Продолжайте умножать найденные значения на два
    Вам дан массив целых чисел nums. Вам также дано целое число original, которое является первым числом, которое нужно найти в nums.
    Затем вы выполняете следующие шаги:
        Если original встречается в nums, умножьте его на два (т. е. установите original = 2 * original).
        В противном случае, остановите процесс.
        Повторяйте этот процесс с новым номером до тех пор, пока не найдёте нужный номер.
    Возвращает окончательное значение original.
    https://leetcode.com/problems/keep-multiplying-found-values-by-two/description/
     */
    public class Task2154 : InfoBasicTask
    {
        public Task2154(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 5, 3, 6, 1, 12 };
            printArray(nums, "Исходный массив: ");
            int original = 3;
            Console.WriteLine($"Исходное число = {original}");
            int final = findFinalValue(nums, original);
            Console.WriteLine($"Конечное значение = {final}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findFinalValue(int[] nums, int original)
        {
            HashSet<int> set = new HashSet<int>(nums);
            while (set.Contains(original))
            {
                original *= 2;
            }
            return original;
        }
    }
}
