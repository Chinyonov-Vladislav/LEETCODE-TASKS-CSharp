using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task274
{
    /*
     274. Индекс Хирша
    Учитывая массив целых чисел citations где citations[i] — количество цитирований, полученных исследователем за его ith статью, верните h-индекс исследователя.
    Согласно определению h-индекса в Википедии: h-индекс определяется как максимальное значение h при условии, что данный исследователь опубликовал не менее h статей, каждая из которых была процитирована не менее h раз.
    Ограничения:
        n == citations.length
        1 <= n <= 5000
        0 <= citations[i] <= 1000
    https://leetcode.com/problems/h-index/description/
     */
    public class Task274 : InfoBasicTask
    {
        public Task274(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] citations = new int[] { 3, 0, 6, 1, 5 };
            printArray(citations, "Исходный массив цитирования статей: ");
            if (isValid(citations))
            {
                int res = HIndex(citations);
                Console.WriteLine($"Индекс Хирша = {res}");
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
        private bool isValid(int[] citations)
        {
            int lowLimit = 1;
            int highLimit = 5000;
            if (citations.Length < lowLimit || citations.Length > highLimit)
            {
                return false;
            }
            lowLimit = 0;
            highLimit = 1000;
            foreach (int citation in citations)
            {
                if (citation < lowLimit || citation > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int HIndex(int[] citations)
        {
            Array.Sort(citations);
            Array.Reverse(citations);
            for (int i = 0; i < citations.Length; i++)
            {
                if (i >= citations[i])
                {
                    return i;
                }
            }
            return citations.Length;
        }
    }
}
