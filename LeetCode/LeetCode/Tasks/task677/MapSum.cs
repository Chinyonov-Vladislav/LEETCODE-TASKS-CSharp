using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task677
{
    public class MapSum
    {
        Dictionary<string, int> dict;
        public MapSum()
        {
            dict = new Dictionary<string, int>();
        }

        public void Insert(string key, int val)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = val;
            }
            else
            {
                dict.Add(key, val);
            }
        }

        public int Sum(string prefix)
        {
            int count = 0;
            foreach (var pair in dict)
            {
                if (pair.Key.StartsWith(prefix))
                {
                    count += pair.Value;
                }
            }
            return count;
        }
    }
}
