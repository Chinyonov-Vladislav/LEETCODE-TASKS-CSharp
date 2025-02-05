using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task17
{
    /*
     17. Буквосочетания телефонного номера
    Учитывая строку, содержащую цифры от 2-9 включительно, верните все возможные комбинации букв, которые могут обозначать это число. Верните ответ в любом порядке.
    Соответствие цифр буквам (как на телефонных кнопках) приведено ниже. Обратите внимание, что 1 не соответствует ни одной букве.
    https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
     */
    public class Task17 : InfoBasicTask
    {
        public Task17(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string digits = "23";
            Console.WriteLine($"Строка цифр = \"{digits}\"");
            IList<string> letterCombinationsList = letterCombinations(digits);
            printIListString(letterCombinationsList, "Возможные комбинации нажатий на телефонные кнопки: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<string> letterCombinations(string digits)
        {
            Dictionary<char, string> dict = new Dictionary<char, string>() {
                {'2',"abc" },
                {'3',"def" },
                {'4',"ghi" },
                {'5',"jkl" },
                {'6',"mno" },
                {'7',"pqrs" },
                {'8',"tuv" },
                {'9',"wxyz" },
            };
            IList<string> result = new List<string>();
            StringBuilder resultDigits =new StringBuilder();
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != '1')
                {
                    resultDigits.Append(digits[i]);   
                }
            }
            if (resultDigits.Length == 0)
            {
                return result;
            }
            StringBuilder currentResultString = new StringBuilder();
            recursive(result, currentResultString, resultDigits.ToString(), dict);
            return result;
        }
        private void recursive(IList<string> result, StringBuilder resultStringBuilder, string resultDigits, Dictionary<char, string> dict,int index=0)
        {
            if (index == resultDigits.Length - 1)
            {
                char currentCharDigitLast = resultDigits[index];
                if (dict.ContainsKey(currentCharDigitLast))
                {
                    string currentStrByDigitLast = dict[currentCharDigitLast];
                    for (int i = 0; i < currentStrByDigitLast.Length; i++)
                    {
                        resultStringBuilder.Append(currentStrByDigitLast[i]);
                        result.Add(resultStringBuilder.ToString());
                        resultStringBuilder.Remove(resultStringBuilder.Length - 1, 1);
                    }
                }
            }
            else
            {
                char currentCharDigit = resultDigits[index];
                if (dict.ContainsKey(currentCharDigit))
                {
                    string currentStrByDigit = dict[currentCharDigit];
                    for (int i = 0; i < currentStrByDigit.Length; i++)
                    {
                        resultStringBuilder.Append(currentStrByDigit[i]);
                        index += 1;
                        recursive(result, resultStringBuilder, resultDigits, dict, index);
                        index -= 1;
                        resultStringBuilder.Remove(resultStringBuilder.Length - 1, 1);
                    }
                }
            }
        }
    }
}
