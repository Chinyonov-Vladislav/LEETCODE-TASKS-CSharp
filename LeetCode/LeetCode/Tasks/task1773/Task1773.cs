using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1773
{
    /*
     1773. Подсчитывать элементы, соответствующие правилу
    Вам дан массив items, где каждый items[i] = [type i, color i, name i] описывает тип, цвет и название ith элемента. 
    Вам также дано правило, представленное двумя строками, ruleKey и ruleValue.
    Говорят, что элемент ith соответствует правилу, если выполняется одно из следующих условий:
        ruleKey == "type" и ruleValue == typei.
        ruleKey == "color" и ruleValue == colori.
        ruleKey == "name" и ruleValue == namei.
    Возвращает количество элементов, соответствующих заданному правилу.
    https://leetcode.com/problems/count-items-matching-a-rule/description/
     */
    public class Task1773 : InfoBasicTask
    {
        public Task1773(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<IList<string>> items = new List<IList<string>>() {
                new List<string>() { "phone","blue","pixel" },
                new List<string>() { "computer","silver","lenovo" },
                new List<string>() { "phone","gold","iphone" },
            };
            string ruleKey = "color";
            string ruleValue = "silver";
            Console.WriteLine("Массив Items с характеристиками");
            printIListIListString(items);
            Console.WriteLine($"Правило (ключ): \"{ruleKey}\"\nПравило (значение): \"{ruleValue}\"");
            if (isValidRuleKey(ruleKey))
            {
                int count = countMatches(items, ruleKey, ruleValue);
                Console.WriteLine($"Количество items, которые характеристики которых соответствуют заданному правилу = {count}");
            }
            else
            {
                Console.WriteLine("Не валидное значение ключа правила!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValidRuleKey(string ruleKey)
        {
            List<string> validRuleKeys = new List<string>() { "type","color","name" };
            return validRuleKeys.Contains(ruleKey);
        }
        private int countMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            int count = 0;
            int indexNumber = -1;
            switch (ruleKey)
            {
                case "type":
                    indexNumber = 0;
                    break;
                case "color":
                    indexNumber = 1;
                    break;
                case "name":
                    indexNumber = 2;
                    break;
            }
            foreach (var item in items) {
                if (item[indexNumber] == ruleValue)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
