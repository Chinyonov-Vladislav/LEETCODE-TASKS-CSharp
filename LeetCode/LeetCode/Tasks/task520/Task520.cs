using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task520
{
    /*
     520. Определение правильности использования заглавных букв
    Мы считаем, что использование заглавных букв в слове является правильным, если выполняется одно из следующих условий:
        Все буквы в этом слове заглавные, например, "USA".
        Все буквы в этом слове не заглавные, как "leetcode".
        Только первая буква в этом слове заглавная, как "Google".
    Учитывая строку word, верните true, если в ней правильно использованы заглавные буквы.
     */
    public class Task520 : InfoBasicTask
    {
        public Task520(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "Google";
            Console.WriteLine(detectCapitalUse(str) ? $"Заглавные буквы корректно используются в слове \"{str}\"" : $"Заглавные буквы не корректно используются в слове \"{str}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool detectCapitalUse(string word)
        {
            bool isAllCapital = true;
            bool isAllLower = true;
            bool isOnlyFirstCapital = true;
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsLower(word[i]) && isAllCapital)
                {
                    isAllCapital = false;
                }
                if (char.IsUpper(word[i]) && isAllLower)
                {
                    isAllLower = false;
                }
                if (char.IsUpper(word[0]))
                {
                    if (i != 0 && char.IsUpper(word[i]))
                    {
                        isOnlyFirstCapital = false;
                    }
                }
                else
                {
                    isOnlyFirstCapital = false;
                }
            }
            return isAllCapital || isAllLower || isOnlyFirstCapital; 
        }
    }
}
