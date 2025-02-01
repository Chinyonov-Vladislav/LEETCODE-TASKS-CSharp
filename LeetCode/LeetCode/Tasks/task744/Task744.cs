using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task744
{
    /*
     744. Найдите наименьшую букву, превышающую целевую
    Вам предоставляется массив символов, letters который отсортирован в неубывающем порядке, и символ target. В есть как минимум два разныхletters символа.
    Верните наименьший символ в letters лексикографически больший, чем target. Если такого символа нет, верните первый символ в letters.
    https://leetcode.com/problems/find-smallest-letter-greater-than-target/description/
     */
    public class Task744 : InfoBasicTask
    {
        public Task744(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            char[] array = new char[] { 'c', 'f','j' };
            char target = 'a';
            char result = nextGreatestLetter(array, target);
            printArray(array, "Массив символов Letters: ");
            Console.WriteLine($"Целевой символ = {target}");
            Console.WriteLine((int)result > (int)target ? 
                $"Наименьший символ, который лексикографически больше '{target}' в letters — '{result}'" : 
                $"В letters нет символов, которые лексикографически больше 'z', поэтому получен первый элемент в массиве Letters = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private char nextGreatestLetter(char[] letters, char target) // модификация бинарного поиска для поиска первого элемента в массиве, который превышает значение заданного
        {
            int left = 0, right = letters.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if ((int)letters[mid] > (int)target)
                    right = mid; // Устанавливаем указатель right в значение mid и ищем левее, так как mid может быть ответом
                else
                    left = mid +1; // двигаемся вправо
            }
            int index = left < letters.Length ? left : 0;
            return letters[index];
        }
    }
}
