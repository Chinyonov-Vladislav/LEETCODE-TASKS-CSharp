using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task677
{
    /*
     677. Пары сумм карт
    Создайте карту, которая позволит вам выполнять следующие действия:
        Сопоставляет строковый ключ с заданным значением.
        Возвращает сумму значений, у которых ключ с префиксом равен заданной строке.
    Реализации MapSum класс:
        MapSum() Инициализирует объект MapSum .
        void insert(String key, int val)Вставляет key-valпару в карту. Если keyпара уже существует, исходная key-valueпара будет заменена на новую.
        int sum(string prefix)Возвращает сумму значений всех пар, которые keyначинаются с prefix.
    Ограничения:
        1 <= key.length, prefix.length <= 50
        key и prefix состоят только из строчных английских букв.
        1 <= val <= 1000
        Максимум 50звонков будет сделано в insert и sum.
    https://leetcode.com/problems/map-sum-pairs/description/
     */
    public class Task677 : InfoBasicTask
    {
        public Task677(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] operations = new string[] { "MapSum", "insert", "sum", "insert", "sum" };
            KeyValuePair<string, int?>[] data = new KeyValuePair<string, int?>[] {
                new KeyValuePair<string, int?>(null, null),
                new KeyValuePair<string, int?>("apple", 3),
                new KeyValuePair<string, int?>("ap", null),
                new KeyValuePair<string, int?>("app",2),
                new KeyValuePair<string, int?>("ap", null)
            };
            printArray(operations, "Массив операций: ");
            printArrayKeyValuePair(data);
            if (isValid(operations, data))
            {
                MapSum mapSum = null;
                for (int i = 0; i < operations.Length; i++)
                {
                    switch (operations[i])
                    {
                        case "MapSum":
                            mapSum = new MapSum();
                            Console.WriteLine("Объект \"MapSum\" был успешно инициализирован");
                            break;
                        case "insert":
                            if (mapSum != null)
                            {
                                mapSum.Insert(data[i].Key, data[i].Value.Value);
                                Console.WriteLine($"Пара ключ-значение ({data[i].Key},{data[i].Value.Value}) была успешно вставлена в карту");
                            }
                            else
                            {
                                Console.WriteLine("Объект \"MapSum\" не был инициализирован");
                            }
                            break;
                        case "sum":
                            if (mapSum != null)
                            {
                                int res = mapSum.Sum(data[i].Key);
                                Console.WriteLine($"Сумма значений всех пар, которые начинаются с {data[i].Key} = {res}");
                            }
                            else
                            {
                                Console.WriteLine("Объект \"MapSum\" не был инициализирован");
                            }
                            break;
                    }
                }
            }
            else
            {
                printInfoNotValidData();
            }

        }
        private bool isValid(string[] operations, KeyValuePair<string, int?>[] data)
        {
            if (operations.Length != data.Length)
            {
                return false;
            }
            int countInsertOperation = 0;
            int countSumOperation = 0;
            int countMapSumOperation = 0;
            int highLimitCountOper = 50;
            int lowLimitLengthKey = 1;
            int highLimitLengthKey = 50;
            int lowLimitLengthPrefix = 1;
            int highLimitLengthPrefix = 50;
            int lowLimitValue = 1;
            int highLimitValue = 1000;
            List<string> acceptedOperations = new List<string>() { "MapSum", "insert", "sum" };
            for (int i = 0; i < operations.Length; i++)
            {
                if (!acceptedOperations.Contains(operations[i]))
                {
                    return false;
                }
                switch (operations[i])
                {
                    case "MapSum":
                        countMapSumOperation++;
                        break;
                    case "insert":
                        countInsertOperation++;
                        break;
                    case "sum":
                        countSumOperation++;
                        break;
                }
                if (i == 0)
                {
                    if (operations[i] != acceptedOperations[0])
                    {
                        return false;
                    }
                    if (!(data[i].Key == null && data[i].Value == null))
                    {
                        return false;
                    }
                }
                else
                {
                    if (operations[i] == acceptedOperations[0])
                    {
                        return false;
                    }
                    else if (operations[i] == acceptedOperations[1])
                    {
                        if (!(data[i].Key != null && data[i].Value != null))
                        {
                            return false;
                        }
                        string key = data[i].Key;
                        if (key.Length < lowLimitLengthKey || key.Length > highLimitLengthKey)
                        {
                            return false;
                        }
                        foreach (char c in key)
                        {
                            if (!(c >= 'a' && c <= 'z'))
                            {
                                return false;
                            }
                        }
                        int val = data[i].Value.Value;
                        if (val < lowLimitValue || val > highLimitValue)
                        {
                            return false;
                        }
                    }
                    else if (operations[i] == acceptedOperations[2])
                    {
                        if (!(data[i].Key != null && data[i].Value == null))
                        {
                            return false;
                        }
                        string prefix = data[i].Key;
                        if (prefix.Length < lowLimitLengthPrefix || prefix.Length > highLimitLengthPrefix)
                        {
                            return false;
                        }
                        foreach (char c in prefix)
                        {
                            if (!(c >= 'a' && c <= 'z'))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            if (countMapSumOperation != 1 || countInsertOperation > highLimitCountOper || countSumOperation > highLimitCountOper)
            {
                return false;
            }
            return true;
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
    }
}
