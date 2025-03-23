using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task313
{
    /*
     313. Супер уродливое число
    Супернекрасивое число — это положительное целое число, простые множители которого находятся в массиве primes.
    Учитывая целое число n и массив целых чисел primes, верните самое nth уродливое число.
    nth Супер-уродливое числогарантированно поместится в 32-битное целое число со знаком.
    Ограничения:
        1 <= n <= 10^5
        1 <= primes.length <= 100
        2 <= primes[i] <= 1000
        primes[i] гарантированно является простым числом.
        Все значения primesуникальны и отсортированы в порядке возрастания.
    https://leetcode.com/problems/super-ugly-number/description/
     */
    public class Task313 : InfoBasicTask
    {
        public Task313(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 5911;
            Console.WriteLine($"Необходимо найти уродливое число №{n}");
            int[] primes = new int[] { 2, 3, 5, 7 };
            printArray(primes, "Простые множители: ");
            if (isValid(n, primes))
            {
                int res = NthSuperUglyNumber(n, primes);
                Console.WriteLine($"Результат = {res}");
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
        private bool isValid(int n, int[] primes)
        {
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10,5);
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            highLimit = 100;
            if (primes.Length < lowLimit || primes.Length > highLimit)
            {
                return false;
            }
            lowLimit = 2;
            highLimit = 1000;
            foreach (int prime in primes)
            {
                if (prime < lowLimit || prime > highLimit || !isPrime(prime))
                {
                    return false;
                }
            }
            HashSet<int> set = new HashSet<int>(primes);
            if (set.Count != primes.Length)
            {
                return false;
            }
            for (int i = 1; i < primes.Length; i++)
            {
                if (primes[i] < primes[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        private int NthSuperUglyNumber(int n, int[] primes)
        {
            int[] values = new int[n];
            values[0] = 1;
            int[] pointers = new int[primes.Length];
            int pointer = 1;
            while (pointer != n)
            {
                List<int> candidates = new List<int>();
                for (int i = 0; i < pointers.Length; i++)
                {
                    long currentNextValue = values[pointers[i]] * primes[i];
                    if (currentNextValue>0)
                    {
                        candidates.Add((int)currentNextValue);
                    }
                }
                int min = candidates.Min();
                values[pointer] = min;
                for (int i = 0; i < candidates.Count; i++)
                {
                    if (candidates[i] == min)
                    {
                        pointers[i]++;
                    }
                }
                pointer++;
            }
            return values[values.Length - 1];
        }
        private bool isPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            for (int i = 2; i < (int)Math.Sqrt(num) + 1; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
