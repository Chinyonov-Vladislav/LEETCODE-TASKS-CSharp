using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task676
{
    public class MagicDictionary
    {
        string[] dictionary;
        public MagicDictionary()
        {
        }

        public void BuildDict(string[] dictionary)
        {
            this.dictionary = dictionary;
        }

        public bool Search(string searchWord)
        {
            foreach (var word in dictionary)
            {
                if (word.Length == searchWord.Length && word != searchWord)
                {
                    int countDifferentSymbols = 0;
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] != searchWord[i])
                        {
                            countDifferentSymbols++;
                        }
                    }
                    if (countDifferentSymbols == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
