using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1913
{
    /*
     1913. Максимальная разница произведения между двумя парами
    Разница в произведении между двумя парами (a, b) и (c, d) определяется как (a * b) - (c * d).
        Например, разница в продукте между (5, 6) и (2, 7) составляет (5 * 6) - (2 * 7) = 16.
    Дан целочисленный массив nums. 
    Выберите четыре различных индекса w, x, y, и z, чтобы разница произведений пар (nums[w], nums[x]) и (nums[y], nums[z]) была максимальной.
    Верните значение разницы
    https://leetcode.com/problems/maximum-product-difference-between-two-pairs/description/
     */
    public class Task1913 : InfoBasicTask
    {
        public Task1913(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 4, 2, 5, 9, 7, 4, 8 };
            printArray(array, "Исходный массив: ");
            if (isValidArray(array))
            {
                Console.WriteLine($"Максимальная разница между произведением двух пар чисел в массиве = {maxProductDifference(array)}");
            }
            else
            {
                Console.WriteLine("Невалидный исходный массив. Его длина должна составлять как минимум 4 символа");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValidArray(int[] nums)
        {
            if (nums.Length < 4)
            {
                return false;
            }
            return true;
        }
        private int maxProductDifference(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length - 1] * nums[nums.Length - 2] - nums[0] * nums[1];
        }
    }
}
