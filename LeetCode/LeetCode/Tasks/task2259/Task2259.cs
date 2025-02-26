using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2259
{
    /*
     2259. Удалите цифру из числа, чтобы максимизировать результат
    Вам дана строка number, представляющая положительное целое число, и символ digit.
    Верните полученную строку после удаления ровно одного вхождения из digit в number так, чтобы значение полученной строки в десятичной форме было максимальным. 
    Тестовые примеры генерируются таким образом, что digit встречается в number хотя бы один раз.
    https://leetcode.com/problems/remove-digit-from-number-to-maximize-result/description/
     */
    public class Task2259 : InfoBasicTask
    {
        public Task2259(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string number = "1231";
            Console.WriteLine($"Число в строковом представлении = \"{number}\"");
            char digit = '1';
            Console.WriteLine($"Символ для удаления: \'{digit}\'");
            string max = removeDigit(number, digit);
            Console.WriteLine(number == max ? $"Указанная цифра \'{digit}\' отсутствует в исходном числе в строковом представлении" :$"Максимальное число после удаления одного символа \'{digit}\' в единственном экземпляре в строковом представлении = \"{max}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string removeDigit(string number, char digit)
        { 
            string result = String.Empty;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == digit)
                {
                    string substr = String.Empty;
                    if (i < number.Length - 1)
                    {
                        substr = number.Substring(0, i) + number.Substring(i + 1);
                    }
                    else
                    {
                        substr = number.Substring(0, number.Length - 1);
                    }
                    if (result == String.Empty)
                    {
                        result = substr;
                    }
                    else
                    {
                        bool isResultBigger = true;
                        for (int j = 0; j < result.Length; j++)
                        {
                            if (substr[j] < result[j])
                            {
                                break;
                            }
                            else if (substr[j] > result[j])
                            {
                                isResultBigger = false;
                                break;
                            }
                        }
                        if (!isResultBigger)
                        {
                            result = substr;
                        }
                    }
                }
            }
            return result != String.Empty ? result : number;    
        }
    }
}
