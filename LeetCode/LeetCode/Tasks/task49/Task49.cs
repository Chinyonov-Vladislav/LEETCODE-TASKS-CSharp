using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task49
{
    /*
     49. Групповые анаграммы
    Учитывая массив строк strs, сгруппируйте анаграммы вместе. Вы можете вернуть ответ в любом порядке.
    Ограничения:
        1 <= strs.length <= 10^4
        0 <= strs[i].length <= 100
        strs[i] состоит из строчных английских букв.
    https://leetcode.com/problems/group-anagrams/description/
     */
    public class Task49 : InfoBasicTask
    {
        public Task49(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            printArray(strs);
            if (isValid(strs))
            {
                IList<IList<string>> res = groupAnagrams(strs);
                Console.WriteLine("Результирующие группировки");
                printIListIListString(res);
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
        private bool isValid(string[] strs)
        {
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10,4);
            if (strs.Length < lowLimit || strs.Length > highLimit)
            {
                return false;
            }
            lowLimit = 0;
            highLimit = (int)Math.Pow(10, 2);
            foreach (string str in strs)
            {
                if (str.Length < lowLimit || str.Length > highLimit)
                {
                    return false;
                }
                foreach (char c in str)
                {
                    if (!(c >= 'a' && c <= 'z'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private IList<IList<string>> groupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] arrChar = strs[i].ToCharArray();
                Array.Sort(arrChar);
                string sortedStr = new string(arrChar);
                if (dict.ContainsKey(sortedStr))
                {
                    dict[sortedStr].Add(strs[i]);
                }
                else
                {
                    dict[sortedStr] = new List<string>() { strs[i] };
                }
            }
            IList<IList<string>> result = new List<IList<string>>();
            foreach (IList<string> str in dict.Values)
            {
                result.Add(str);
            }
            return result;
        }
    }
}
