using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task678
{
    /*
     678. Допустимая строка в круглых скобках
    Учитывая, что строка s содержит только три типа символов: '(', ')' и '*', верните true если s онакорректна.
    Следующие правила определяют допустимую строку:
        Любая левая круглая скобка '(' должна иметь соответствующую правую круглую скобку ')'.
        Любая правая скобка ')' должна иметь соответствующую левую скобку '('.
        Левая круглая скобка '(' должна располагаться перед соответствующей правой круглой скобкой ')'.
        '*' может рассматриваться как одиночная правая скобка ')' или одиночная левая скобка '(' или пустая строка "".
    Ограничения:
        1 <= s.length <= 100
        s[i] является '(', ')' или '*'.
    https://leetcode.com/problems/valid-parenthesis-string/description/
     */
    public class Task678 : InfoBasicTask
    {
        public Task678(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "(*))";
            Console.WriteLine($"Строка для проверки: \"{str}\"");
            if (isValid(str))
            {
                Console.WriteLine(checkValidString(str) ? $"Строка \"{str}\" является допустимой строкой с круглыми скобками" : $"Строка \"{str}\" является недопустимой строкой с круглыми скобками");
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
        private bool isValid(string s)
        {
            int lowLimit = 1;
            int highLimit = 100;
            if (s.Length < lowLimit || s.Length > highLimit)
            {
                return false;
            }
            List<char> acceptedChars = new List<char>() { ')', '(', '*' };
            foreach(char c in acceptedChars)
            {
                if (!acceptedChars.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        private bool checkValidString(string s)
        {
            Stack<Tuple<char, int>> stack = new Stack<Tuple<char, int>>();
            Stack<Tuple<char, int>> stackStar = new Stack<Tuple<char, int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*')
                {
                    stackStar.Push(new Tuple<char, int>(s[i], i));
                }
                else if (s[i] == '(')
                {
                    stack.Push(new Tuple<char, int>(s[i], i));
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        if (stack.Peek().Item1 == '(')
                        {
                            stack.Pop();
                        }
                    }
                    else if (stackStar.Count > 0)
                    {
                        Tuple<char, int> star = stackStar.Peek();
                        if (star.Item2 < i)
                        {
                            stackStar.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            while (stackStar.Count > 0)
            {
                Tuple<char,int> star = stackStar.Pop();
                if(stack.Count>0)
                {
                    Tuple<char, int> parenthesis = stack.Pop();
                    if (parenthesis.Item1 == '(')
                    {
                        if (parenthesis.Item2 >= star.Item2)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if(parenthesis.Item2 <= star.Item2)
                        {
                            return false;
                        }
                    }
                }
            }
            if (stack.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
