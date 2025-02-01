using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task868
{
    /*
     868. Бинарный разрыв
    Считывая положительное целое число n, найдите и верните наибольшее расстояние между любыми двумя соседними 1 в двоичном представлении n. Если нет двух соседних 1, верните 0.
    Два 1' являются смежными, если их разделяют только 0' (возможно, без 0').Расстояние между двумя 1' — это абсолютная разница между их позициями в битах. Например, расстояние между двумя 1' в "1001" равно 3.
     https://leetcode.com/problems/binary-gap/description/
     */
    public class Task868 : InfoBasicTask
    {
        public Task868(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 22;
            int maxLength = binaryGap(n);
            Console.WriteLine($"Наибольшее расстояние между любыми двумя соседними 1 в двоичном представлении {n} = {maxLength}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int binaryGap(int n)
        {
            int index = 0;
            List<int> indexs = new List<int>();
            while (n != 0)
            {
                int bit = n & 1;
                if (bit == 1)
                {
                    indexs.Add(index);
                }
                n >>= 1;
                index++;
            }
            if (indexs.Count <= 1)
            {
                return 0;
            }
            indexs.Sort();
            int max = 0;
            for (int i = 1; i < indexs.Count; i++)
            {
                int currentLength = indexs[i] - indexs[i - 1];
                if (currentLength > max)
                {
                    max = currentLength;
                }
            }
            return max;
        }
        // скопировано с leetcode
        private int bestSolution(int n)
        {
            int last = -1, ans = 0;
            for (int i = 0; i < 32; ++i)
                if (((n >> i) & 1) > 0)
                {
                    if (last >= 0)
                        ans = Math.Max(ans, i - last);
                    last = i;
                }

            return ans;
        }
    }
}
