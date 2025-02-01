using System;
using System.Collections.Generic;
using LeetCode.Basic;
namespace LeetCode.Tasks.task20
{
    public class Task20 : InfoBasicTask
    {
        public Task20(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "([])";
            Console.WriteLine(IsValid(str) ? "Valid" : "Not Valid");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public bool IsValid(string s)
        {
            Stack<char> chars = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (chars.Count == 0)
                {
                    chars.Push(s[i]);
                    continue;
                }
                else
                {
                    char popedChar = chars.Pop();
                    if ((popedChar == '(' && s[i] == ')') || (popedChar == '{' && s[i] == '}') || (popedChar == '[' && s[i] == ']'))
                    {
                        continue;
                    }
                    else
                    {
                        chars.Push(popedChar);
                        chars.Push(s[i]);
                    }
                }
            }
            return chars.Count == 0;
        }
    }
}
