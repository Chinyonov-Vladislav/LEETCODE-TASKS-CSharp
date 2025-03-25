using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task93
{
    /*
     93. Восстановление IP-адресов
    Допустимый IP-адрес состоит ровно из четырёх целых чисел, разделённых точками. Каждое целое число находится в диапазоне от 0 до 255 (включительно) и не может начинаться с нуля.
        Например, "0.1.2.201" и "192.168.1.1" являются действительными IP-адресами, но "0.011.255.245", "192.168.1.312" и "192.168@1.1" являются недействительными IP-адресами.
    Учитывая строку s, содержащую только цифры, верните все возможные допустимые IP-адреса, которые можно сформировать, вставляя точки в s. Вы не можете изменять порядок или удалять какие-либо цифры в s. Вы можете возвращать допустимые IP-адреса в любом порядке.
    Ограничения:
        1 <= s.length <= 20
        s состоит только из цифр.
    https://leetcode.com/problems/restore-ip-addresses/description/
     */
    public class Task93 : InfoBasicTask
    {
        public Task93(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "25525511135";
            Console.WriteLine($"Исходная строка из цифр: \"{s}\"");
            if (isValid(s))
            {
                IList<string> res = restoreIpAddresses(s);
                printIListString(res, "Результирующий массив валидых ip - адресов: ");
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
            int highLimit = 20;
            if (s.Length < lowLimit || s.Length > highLimit)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    return false;
                }
            }
            return true;
        }
        private IList<string> restoreIpAddresses(string s)
        {
            IList<string> res = new List<string>();
            if (s.Length > 12)
            {
                return res;
            }
            StringBuilder sb =new StringBuilder();
            recursive(s, sb, 0, 0, res);
            return res;
        }
        private void recursive(string s, StringBuilder sb, int currentPart, int startIndex, IList<string> result)
        {
            if (currentPart < 3)
            {
                for (int i = startIndex; startIndex + 3 < s.Length ? i < startIndex + 3 : i < s.Length; i++)
                {
                    sb.Append(s[i]);
                    sb.Append('.');
                    recursive(s, new StringBuilder(sb.ToString()), currentPart + 1, i + 1, result);
                    sb.Remove(sb.Length-1,1);
                }
            }
            else
            {
                sb.Append(s.Substring(startIndex));
                if (isValidIpAddress(sb.ToString()))
                {
                    result.Add(sb.ToString());
                }
            }
        }
        private bool isValidIpAddress(string queryIP)
        {
            string[] parts = queryIP.Split('.');
            if (parts.Length != 4)
            {
                return false;
            }
            foreach (string part in parts)
            {
                if (part.Length > 1 && part.StartsWith("0"))
                {
                    return false;
                }
                int value = 0;
                bool isSuccess = int.TryParse(part, out value);
                if (!isSuccess)
                {
                    return false;
                }
                if (!(0 <= value && value <= 255))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
