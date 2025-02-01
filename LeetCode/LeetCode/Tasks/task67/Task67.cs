using System;
using System.Text;
using LeetCode.Basic;
namespace LeetCode.Tasks.task67
{
    public class Task67 : InfoBasicTask
    {
        public Task67(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string a = "100";
            string b = "110010";
            Console.WriteLine($"Результат: {addBinary(a,b)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string addBinary(string a, string b)
        {
            string result = "";
            int maxLength = a.Length>b.Length ? a.Length : b.Length;
            string zeros = "";
            if (maxLength > a.Length)
            {
                int countZeros = maxLength - a.Length;
                for (int i = 0; i < countZeros; i++)
                {
                    zeros = zeros + "0";
                }
                a = zeros + a;
            }
            if (maxLength > b.Length)
            {
                int countZeros = maxLength - b.Length;
                for (int i = 0; i < countZeros; i++)
                {
                    zeros = zeros + "0";
                }
                b = zeros + b;
            }
            bool hasOverflow = false;
            for (int i = maxLength - 1; i >= 0; i--)
            {
                char first = a[i];
                char second = b[i];
                if (first == '0' && second == '0')
                {
                    result += hasOverflow ? "1" : "0";
                    hasOverflow = false;
                }
                else if ((first == '1' && second == '0') || (first == '0' && second == '1'))
                {
                    if (hasOverflow)
                    {
                        result += "0";
                        hasOverflow = true;
                    }
                    else
                    {
                        result += "1";
                        hasOverflow = false;
                    }
                }
                else
                {
                    result += hasOverflow ? "1" : "0";
                    hasOverflow = true;
                }
            }
            if (hasOverflow)
            {
                result += "1";
            }
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private string bestSolution(string a, string b) // скопировано с leetcode
        {
            int posA = a.Length - 1;
            int posB = b.Length - 1;
            int carry = 0;
            char currA;
            char currB;

            StringBuilder builder = new StringBuilder();

            while (posA >= 0 || posB >= 0)
            {
                if (posA >= 0)
                {
                    currA = a[posA];
                    posA--;
                }
                else
                {
                    currA = '0';
                }

                if (posB >= 0)
                {
                    currB = b[posB];
                    posB--;
                }
                else
                {
                    currB = '0';
                }

                if (currA == '0' && currB == '0')
                {
                    if (carry == 1)
                    {
                        builder.Insert(0, '1');
                    }
                    else
                    {
                        builder.Insert(0, '0');
                    }
                    carry = 0;
                }
                else if (currA == '1' && currB == '1')
                {
                    if (carry == 1)
                        builder.Insert(0, '1');
                    else
                    {
                        builder.Insert(0, '0');
                    }
                    carry = 1;
                }
                else
                {
                    if (carry == 1)
                    {
                        builder.Insert(0, '0');
                        carry = 1;
                    }
                    else
                    {
                        builder.Insert(0, '1');
                        carry = 0;
                    }
                }

                if (posA < 0 && posB < 0)
                {
                    if (carry == 1)
                    {
                        builder.Insert(0, '1');
                    }
                }

            }

            return builder.ToString();
        }
    }
}
