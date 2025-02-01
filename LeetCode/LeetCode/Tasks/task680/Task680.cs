using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task680
{
    public class Task680 : InfoBasicTask
    {
        /*
         680. Действительный палиндром II
        Учитывая строку s, верните true если s она может быть палиндромом после удаления не более одного символа из неё.
        https://leetcode.com/problems/valid-palindrome-ii/description/
         */
        public Task680(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "eceec";
            Console.WriteLine(validPalindrome(str) ? $"Строка \"{str}\" является валидным палиндромом (включая возможность удаления 1 символа)" : $"Строка \"{str}\" не является валидным палиндромом (включая возможность удаления 1 символа");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool validPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    string strWithourLeftLetter = s.Remove(left, 1);
                    bool validWithoutLeftLetter = checkValidPalindromeWithoutOneLetter(strWithourLeftLetter);
                    if (validWithoutLeftLetter)
                    {
                        return true;
                    }
                    else
                    {
                        string strWithourRightLetter = s.Remove(right, 1);
                        bool validWithoutRightLetter = checkValidPalindromeWithoutOneLetter(strWithourRightLetter);
                        if (validWithoutRightLetter)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    left++;
                    right--;
                }
            }
            return true;
        }
        private bool checkValidPalindromeWithoutOneLetter(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
}
