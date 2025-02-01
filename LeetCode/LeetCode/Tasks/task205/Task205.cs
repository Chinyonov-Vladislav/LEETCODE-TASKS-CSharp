using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.Basic;
namespace LeetCode.Tasks.task205
{
    /*
     205. Изоморфные строки
    Даны две строки s и t, определите, изоморфны ли они.
    Две строки s и t изоморфны, если символы в s можно заменить на символы из t.
    Все вхождения символа должны быть заменены другим символом с сохранением порядка символов. Два символа не могут быть заменены одним и тем же символом, но символ может быть заменен сам на себя.
     */
    public class Task205 : InfoBasicTask
    {
        public Task205(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string first = "badc";
            string second = "baba";
            if (first.Length != second.Length)
            {
                Console.WriteLine("Длина исходных строк не равна. Строки не корректны для задания");
                return;
            }
            Console.WriteLine(isIsomorphic(first, second) ? $"Строки \"{first}\" и \"{second}\" являются изоморфными" : $"Строки \"{first}\" и \"{second}\" не являются изоморфными");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isIsomorphic(string s, string t)
        {
            Dictionary<char, char> chars = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (chars.ContainsKey(s[i]))
                {
                    if (t[i] != chars[s[i]])
                    {
                        return false;
                    }
                    
                }
                else
                {
                    if (chars.Values.Contains(t[i]))
                    {
                        return false;
                    }
                    chars.Add(s[i], t[i]);
                }
            }
            return true;
        }
    }
}
