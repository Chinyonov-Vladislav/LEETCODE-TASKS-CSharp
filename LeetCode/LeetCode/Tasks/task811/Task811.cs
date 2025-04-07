using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task811
{
    /*
     811. Количество посещений поддомена
    Домен веб-сайта "discuss.leetcode.com" состоит из различных поддоменов. На верхнем уровне у нас есть "com", на следующем уровне — "leetcode.com" и на самом нижнем уровне — "discuss.leetcode.com". Когда мы заходим на домен, например "discuss.leetcode.com", мы также неявно заходим на родительские домены "leetcode.com" и "com".
    Домен с подсчётом посещений — это домен, который имеет один из двух форматов "rep d1.d2.d3" или "rep d1.d2", где rep — это количество посещений домена, а d1.d2.d3 — сам домен.
    Например, "9001 discuss.leetcode.com" — это домен с подсчётом, который указывает, что discuss.leetcode.com был посещён 9001 раз
    Учитывая массив из доменов, сопряженных по количеству, cpdomains верните массив из доменов, сопряженных по количеству, каждого поддомена во входных данных. Вы можете вернуть ответ в любом порядке.
    Ограничения:
        1 <= cpdomain.length <= 100
        1 <= cpdomain[i].length <= 100
        cpdomain[i] следует либо за "repi d1i.d2i.d3i" форматом, либо за "repi d1i.d2i" форматом.
        repi является целым числом в диапазоне [1, 104].
        d1i, d2i, и d3i состоят из строчных английских букв.
    https://leetcode.com/problems/subdomain-visit-count/description/
     */
    public class Task811 : InfoBasicTask
    {
        public Task811(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] cpdomains = new string[] { "900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org" };
            printArray(cpdomains, "Массив доменов и количества посещений: ");
            if (isValid(cpdomains))
            {
                IList<string> res = subdomainVisits(cpdomains);
                printIListString(res, "Количество посещений по доменам: ");
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
        private bool isValid(string[] cpdomains)
        {
            int lowLimitCpDomainsCount = 1;
            int highLimitCpDomainsCount = 100;
            int lowLimitCpDomainLength = 1;
            int highLimitCpDomainLength = 100;
            if (cpdomains.Length < lowLimitCpDomainsCount || cpdomains.Length > highLimitCpDomainsCount)
            {
                return false;
            }
            foreach (string cpdomain in cpdomains)
            {
                if (cpdomain.Length < lowLimitCpDomainLength || cpdomain.Length > highLimitCpDomainLength)
                {
                    return false;
                }
            }
            foreach (string cpdomain in cpdomains)
            {
                string[] parts = cpdomain.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("3");
                    return false;
                }
                int count = int.Parse(parts[0]);
                if (count < 1 || count > Math.Pow(10, 4))
                {
                    return false;
                }
                string[] domains = parts[1].Split('.');
                if (domains.Length < 2 || domains.Length > 3)
                {
                    return false;
                }
                foreach (string domain in domains)
                {
                    foreach (char c in domain)
                    {
                        if (!(c >= 'a' && c <= 'z'))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private IList<string> subdomainVisits(string[] cpdomains)
        {
            IList<string> list = new List<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string cpdomain in cpdomains)
            {
                string[] parts = cpdomain.Split(' ');
                int count = int.Parse(parts[0]);
                List<int> indexsOfDot = new List<int>();
                for (int i = 0; i < parts[1].Length; i++)
                {
                    if (parts[1][i] == '.')
                    {
                        indexsOfDot.Add(i);
                    }
                }
                for (int i = indexsOfDot.Count - 1; i >= 0; i--)
                {
                    string substring = parts[1].Substring(indexsOfDot[i] + 1);
                    if (dict.ContainsKey(substring))
                    {
                        dict[substring] += count;
                    }
                    else
                    {
                        dict.Add(substring, count);
                    }
                }
                if (dict.ContainsKey(parts[1]))
                {
                    dict[parts[1]] += count;
                }
                else
                {
                    dict.Add(parts[1], count);
                }
            }
            foreach (var pair in dict)
            {
                list.Add($"{pair.Value} {pair.Key}");
            }
            return list;
        }
    }
}
