using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task592
{
    /*
     592. Сложение и вычитание дробей
    Учитывая строку expression с выражением для сложения и вычитания дробей, верните результат вычисления в строковом формате.
    Конечным результатом должна быть неприводимая дробь. Если ваш конечный результат — целое число, измените его на дробь со знаменателем 1. В этом случае 2 следует преобразовать в 2/1.
    Ограничения:
        Исходная строка содержит только '0' до '9', '/', '+' и '-'. То же самое относится и к результату.
        Каждая дробь (входная и выходная) имеет формат ±numerator/denominator. Если первая входная дробь или выходная дробь положительны, то '+' будет опущено.
        Входные данные содержат только допустимые неприводимые дроби, где числитель и знаменатель каждой дроби всегда находятся в диапазоне [1, 10]. Если знаменатель равен 1, это означает, что данная дробь на самом деле является целым числом в формате дроби, описанном выше.
        Количество заданных дробей будет находиться в диапазоне [1, 10].
        Числитель и знаменатель конечного результата гарантированно будут корректными и находиться в диапазоне 32-битного целого числа.
    https://leetcode.com/problems/fraction-addition-and-subtraction/description/
     */
    public class Task592 : InfoBasicTask
    {
        public Task592(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string expression = "-1/2+1/2";
            Console.WriteLine($"Исходное выражение: \"{expression}\"");
            if (isValid(expression))
            {
                string res = fractionAddition(expression);
                Console.WriteLine($"Результат = \"{res}\"");
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
        private bool isValid(string expression)
        {
            int lowLimitValueNumerator = 1;
            int highLimitValueNumerator = 10;
            int lowLimitValueDenumerator = 1;
            int highLimitValueDenumerator = 10;
            int lowLimitCountFraction = 1;
            int highLimitCountFraction = 10;

            foreach (char c in expression)
            {
                if (!((c >= '0' && c <= '9') || c == '/' || c == '+' || c == '-'))
                {
                    return false;
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in expression)
            {
                if (c == '+' || c == '-')
                {
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append(c);
            }
            string[] arr = stringBuilder.ToString().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                string pattern = String.Empty;
                if (i == 0)
                {
                    pattern = @"^[+-]?\d+/\d+$";
                }
                else
                {
                    pattern = @"^[+-]\d+/\d+$";
                }
                if (!Regex.IsMatch(arr[i], pattern))
                {
                    return false;
                }
            }
            string[] arrayPartsExpression = expression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> numerators = new List<int>();
            List<int> denumerators = new List<int>();
            if (arrayPartsExpression.Length < lowLimitCountFraction || arrayPartsExpression.Length > highLimitCountFraction)
            {
                return false;
            }
            foreach (string part in arrayPartsExpression)
            {
                string[] parts = part.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                int numerator = int.Parse(parts[0]);
                int denumerator = int.Parse(parts[1]);
                if (numerator < lowLimitValueNumerator || numerator > highLimitValueNumerator || denumerator < lowLimitValueDenumerator || denumerator > highLimitValueDenumerator)
                {
                    return false;
                }
                numerators.Add(numerator);
                denumerators.Add(denumerator);
            }
            for (int i = 0; i < numerators.Count; i++)
            {
                int smallestСommonDivisor = getNOD(numerators[i], denumerators[i]);
                if (smallestСommonDivisor != 1)
                {
                    return false;
                }
            }
            return true;
        }
        private string fractionAddition(string expression)
        {
            List<char> operations = new List<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '+' || expression[i] == '-')
                {
                    operations.Add(expression[i]);
                }
            }
            string[] arrayPartsExpression = expression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> numerators = new List<int>();
            List<int> denumerators = new List<int>();
            foreach (string arr in arrayPartsExpression)
            {
                string[] parts = arr.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                int numerator = int.Parse(parts[0]);
                int denumerator = int.Parse(parts[1]);
                numerators.Add(numerator);
                denumerators.Add(denumerator);
            }
            int nokDenumerator = findSmallestCommonMultiple(denumerators);
            for (int i = 0; i < denumerators.Count; i++)
            {
                int multiplier = nokDenumerator / denumerators[i];
                numerators[i]*=multiplier;
                denumerators[i]*=multiplier;
            }
            int totalNumerator = 0;
            int totalDenominator = denumerators[0];
            if (operations.Count == numerators.Count)
            {
                for (int i = 0; i < operations.Count; i++)
                {
                    switch (operations[i])
                    {
                        case '+':
                            totalNumerator += numerators[i];
                            break;
                        case '-':
                            totalNumerator -= numerators[i];
                            break;
                    }
                }
            }
            else
            {
                totalNumerator += numerators[0];
                for (int i = 0; i < operations.Count; i++)
                {
                    switch (operations[i])
                    {
                        case '+':
                            totalNumerator += numerators[i+1];
                            break;
                        case '-':
                            totalNumerator -= numerators[i+1];
                            break;
                    }
                }
            }
            int nod = getNOD(Math.Abs(totalNumerator), Math.Abs(totalDenominator));
            int resultNumerator = totalNumerator / nod;
            int resultDenumerator = totalDenominator / nod;
            if (resultNumerator % resultDenumerator == 0)
            {
                return $"{resultNumerator}/1";
            }
            return $"{resultNumerator}/{resultDenumerator}";
        }

        private int findSmallestCommonMultiple(List<int> items)
        {
            int nok = items[0];
            for (int i = 1; i < items.Count; i++)
            {
                nok = getNOK(nok, items[i]); // функции getNOK и getNOD для двух чисел
            }
            return nok;
        }

        private int getNOK(int a, int b)
        {
            return (int)a * b / getNOD(Math.Abs(a), Math.Abs(b));
        }

        private int getNOD(int a, int b)
        {
            for (int i = (int)Math.Min(a, b); i > 1; i--)
            {
                if (((a % i) == 0) & ((b % i) == 0))
                {
                    return i;
                }
            }
            return 1;
        }

    }
}
