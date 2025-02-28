using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2525
{
    /*
     2525. Классифицируйте коробку в соответствии с критериями
    Учитывая четыре целых числа length, width, height, и mass, представляющих размеры и массу коробки соответственно, верните строку, представляющую категорию коробки.
        Поле является "Bulky" , если:
            Любой из размеров коробки больше или равен 10^4.
            Или объём коробки больше или равен 10^9.
        Если масса коробки больше или равна 100, то это "Heavy".
        Если поле является одновременно "Bulky" и "Heavy", то его категорией является "Both".
        Если поле не является ни "Bulky" ни "Heavy", то его категорией является "Neither".
        Если поле есть, "Bulky" но нет "Heavy", то его категория "Bulky".
        Если поле есть, "Heavy" но нет "Bulky", то его категория "Heavy".
    Обратите внимание, что объём коробки равен произведению её длины, ширины и высоты.
    Ограничения:
        1 <= length, width, height <= 10^5
        1 <= mass <= 10^3
    https://leetcode.com/problems/categorize-box-according-to-criteria/description/
     */
    public class Task2525 : InfoBasicTask
    {
        public Task2525(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int length = 2909;
            int width = 3968;
            int height = 3272;
            int mass = 727;
            Console.WriteLine($"Длина = {length}");
            Console.WriteLine($"Ширина = {width}");
            Console.WriteLine($"Высота = {height}");
            Console.WriteLine($"Масса = {mass}");
            if (isValid(length, width, height, mass))
            {
                string category = categorizeBox(length, width, height, mass);
                Console.WriteLine($"Категория коробки: \"{category}\"");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int length, int width, int height, int mass)
        {
            int upperLimit = (int)Math.Pow(10, 5);
            if (length < 1 || length > upperLimit)
            {
                return false;
            }
            if (width < 1 || width > upperLimit)
            {
                return false;
            }
            if (height < 1 || height > upperLimit)
            {
                return false;
            }
            upperLimit = (int)Math.Pow(10, 3);
            if (mass < 1 || mass > upperLimit)
            {
                return false;
            }
            return true;
        }
        private string categorizeBox(int length, int width, int height, int mass)
        {
            int limitForDimension = (int)Math.Pow(10, 4);
            long volume = (long)length * (long)width * (long)height;
            bool isBulky = length >= limitForDimension || width >= limitForDimension || height >= limitForDimension || volume >= (int)Math.Pow(10, 9);
            bool isHeavy = mass >= 100;
            if (isBulky && isHeavy)
            {
                return "Both";
            }
            if (!isBulky && !isHeavy)
            {
                return "Neither";
            }
            if (isBulky)
            {
                return "Bulky";
            }
            return "Heavy";
        }
    }
}
