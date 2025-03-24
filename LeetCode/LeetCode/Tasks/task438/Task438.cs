using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task438
{
    /*
     438. Найдите все анаграммы в строке
    Учитывая две строки s и p, верните массив всех начальных индексов p's anagrams в s. Вы можете вернуть ответ в любом порядке.
    Ограничения:
        1 <= s.length, p.length <= 3 * 10^4
        s и p состоят из строчных английских букв.
    https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
     */
    public class Task438 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Nothing = 0,
            FirstMethod =1,
            SecondMethod =2,
            Both = 3
        }
        public Task438(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "abab";
            string p = "ab";
            Console.WriteLine($"Исходная строка: \"{s}\"\nСтрока для анаграммы: \"{p}\"");
            if (isValid(s, p))
            {
                TypeSolution typeSolution = askUserTypeSolution();
                IList<int> result = null;
                switch (typeSolution)
                {
                    case TypeSolution.FirstMethod:
                        result = findAnagrams(s, p);
                        printIListInt(result, "Результат с помощью первого метода: ");
                        break;
                    case TypeSolution.SecondMethod:
                        result = findAnagramsVariantTwo(s, p);
                        printIListInt(result, "Результат с помощью второго метода: ");
                        break;
                    case TypeSolution.Both:
                        result = findAnagrams(s, p);
                        printIListInt(result, "Результат с помощью первого метода: ");
                        result = findAnagramsVariantTwo(s, p);
                        printIListInt(result, "Результат с помощью второго метода: ");
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
        private bool isValid(string s, string p)
        {
            int lowLimit = 1;
            int highLimit = 3*(int)Math.Pow(10,4);
            if (s.Length < lowLimit || s.Length > highLimit)
            {
                return false;
            }
            if (p.Length < lowLimit || p.Length > highLimit)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            foreach (char c in p)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            return true;
        }

        private IList<int> findAnagrams(string s, string p)
        {
            IList<int> list = new List<int>();
            char[] arr = p.ToCharArray();
            Array.Sort(arr);
            string sortedP = new string(arr);
            for (int i = 0; i <= s.Length - p.Length; i++)
            {
                string subStr = s.Substring(i, p.Length);
                char[] chars = subStr.ToCharArray();
                Array.Sort(chars);
                string sortedSubStr = new string(chars);
                if (sortedSubStr == sortedP)
                {
                    list.Add(i);
                }
            }
            return list;
        }

        private IList<int> findAnagramsVariantTwo(string s, string p)
        {
            IList<int> result = new List<int>();
            int[] freqS = new int[26];
            int[] freqP = new int[26];
            foreach (char c in p)
            {
                freqP[c-'a']++;
            }
            for (int i = 0; i <= s.Length - p.Length; i++)
            {
                if (i == 0)
                {
                    for (int index = i; index < i + p.Length; index++)
                    {
                        freqS[s[index] - 'a']++;
                    }
                }
                else
                {
                    freqS[s[i-1] - 'a']--;
                    freqS[s[i + p.Length-1] - 'a']++;
                }
                bool isSame = true;
                for (int index = 0; index < freqS.Length; index++)
                {
                    if (freqP[index] != freqS[index])
                    {
                        isSame = false;
                        break;
                    }
                }
                if (isSame)
                {
                    result.Add(i);
                }
            }
            return result;
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Метод сравнения отсортированной анаграммы и подстроки - кандидата\n" +
                    "2 - Метод скользящего окна\n" +
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
