using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3024
{
    /*
     3024. Тип треугольника
    Вам дан нумерованный от 0 целочисленный массив nums размером 3, из которого можно составить стороны треугольника.
        Треугольник называется равносторонним, если все его стороны имеют одинаковую длину.
        Треугольник называется равнобедренным, если у него ровно две стороны одинаковой длины.
        Треугольник называется разносторонним, если все его стороны имеют разную длину.
    Верните строку, представляющую тип треугольника, который можно образовать, или"none" если стороны не могут образовать треугольник.
    Ограничения:
        nums.length == 3
        1 <= nums[i] <= 100
    https://leetcode.com/problems/type-of-triangle/description/
     */
    public class Task3024 : InfoBasicTask
    {
        public Task3024(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3,3,3 };
            printArray(nums,"Массив длин сторон треугольника: ");
            if (isValid(nums))
            {
                string type = triangleType(nums);
                string rusType = String.Empty;
                switch (type)
                {
                    case "equilateral":
                        rusType = "равносторонний";
                        break;
                    case "isosceles":
                        rusType = "равнобедренный";
                        break;
                    case "scalene":
                        rusType = "разносторонний";
                        break;
                }
                Console.WriteLine(rusType == String.Empty ? "Невозможно построить треугольник из сторон заданной длины" : $"Тип треугольника = {rusType}");
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
            if (nums.Length != 3)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private string triangleType(int[] nums)
        {
            int a = nums[0];
            int b = nums[1];
            int c = nums[2];
            if (a + b > c && a + c > b && b + c > a)
            {
                if (a == b && b == c)
                {
                    return "equilateral";
                }
                if ((a == b && a != c) || (a == c && a != b) || (b == c && a != c))
                {
                    return "isosceles";
                }
                return "scalene";
            }
            return "none";
        }
    }
}
