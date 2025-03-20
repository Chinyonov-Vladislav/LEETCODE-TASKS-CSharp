using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task227
{
    /*
     227. Базовый калькулятор II
    Учитывая строку s, которая представляет собой выражение, вычислите это выражение и верните его значение.
    Целочисленное деление должно быть сокращено до нуля.
    Вы можете предположить, что данное выражение всегда верно. Все промежуточные результаты будут находиться в диапазоне [-231, 231 - 1].
    Примечание: вам не разрешается использовать встроенные функции, которые вычисляют строки как математические выражения, например eval().
    Ограничения:
        1 <= s.length <= 3 * 10^5
        s состоит из целых чисел и операторов ('+', '-', '*', '/'), разделенных некоторым количеством пробелов.
        s представляет допустимое выражение.
        Все целые числа в выражении являются неотрицательными целыми числами в диапазоне [0, 2^31 - 1].
        Ответ гарантированно поместится в 32-разрядное целое число.
    https://leetcode.com/problems/basic-calculator-ii/description/
     */
    public class Task227 : InfoBasicTask
    {
        public Task227(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string evaluation = "1+1+1";
            if (isValid(evaluation))
            {
                int result = calculate(evaluation);
                Console.WriteLine($"Результат выражения {evaluation} = {result}");
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
            int highLimit = 3*(int)Math.Pow(10,5);
            HashSet<char> accepetedCharacters = new HashSet<char>() { '0', '1', '2', '3','4', '5','6','7','8','9', '+','-','*','/', ' ' };
            foreach (char character in s)
            {
                if (!accepetedCharacters.Contains(character))
                {
                    return false;
                }
            }
            s = s.Replace(" ", "");
            StringBuilder currentValue = new StringBuilder();
            List<string> parts = new List<string>();
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    currentValue.Append(c);
                }
                else
                {
                    parts.Add(currentValue.ToString());
                    currentValue.Clear();
                    parts.Add(c.ToString());
                }
            }
            lowLimit = 0;
            highLimit = Int32.MaxValue;
            for (int i = 0; i < parts.Count; i += 2)
            {
                if (!(parts[i + 1] != "+" || parts[i + 1] != "-" || parts[i + 1] != "*" || parts[i + 1] != "/"))
                {
                    return false;
                }
                long value = 0;
                bool isSuccess = long.TryParse(parts[i], out value);
                if (!isSuccess)
                {
                    return false;
                }
                if (value < lowLimit || value > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int calculate(string s)
        {
            int result = 0;
            s = s.Replace(" ", "");
            List<string> parts = new List<string>();
            Stack<string> stack = new Stack<string>();
            StringBuilder currentValue = new StringBuilder();
            foreach (char c in s) {
                if (c >= '0' && c <= '9')
                {
                    currentValue.Append(c);
                }
                else
                {
                    parts.Add(currentValue.ToString());
                    currentValue.Clear();
                    parts.Add(c.ToString());
                }
            }
            parts.Add(currentValue.ToString());
            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i] == "+" || parts[i] == "-" || parts[i] == "*" || parts[i] == "/")
                {
                    stack.Push(parts[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(parts[i]);
                    }
                    else
                    {
                        string valueFromStack = stack.Pop();
                        if (valueFromStack == "*")
                        {
                            int firstValue = int.Parse(stack.Pop());
                            int secondValue = int.Parse(parts[i]);
                            stack.Push((firstValue * secondValue).ToString());
                        }
                        else if (valueFromStack == "/")
                        {
                            int firstValue = int.Parse(stack.Pop());
                            int secondValue = int.Parse(parts[i]);
                            stack.Push((firstValue / secondValue).ToString());
                        }
                        else
                        {
                            stack.Push(valueFromStack);
                            stack.Push(parts[i]);
                        }
                    }
                }
            }
            parts.Clear();
            while (stack.Count > 0) {
                parts.Add(stack.Pop());
            }
            parts.Reverse();
            if (parts.Count == 1)
            {
                return int.Parse(parts[0]);
            }
            for (int i = 1; i < parts.Count; i += 2)
            {
                if (i == 1)
                {
                    int firstValue = int.Parse(parts[i - 1]);
                    int secondValue = int.Parse(parts[i + 1]);
                    int value = 0;
                    if (parts[i] == "+")
                    {
                        value = firstValue + secondValue;
                        
                    }
                    else
                    {
                        value = firstValue - secondValue;
                    }
                    result = value;
                }
                else
                {
                    int secondValue = int.Parse(parts[i + 1]);
                    if (parts[i] == "+")
                    {
                        result += secondValue;
                    }
                    else
                    {
                        result -= secondValue;
                    }
                }
            }
            return result;
        }
    }
}
