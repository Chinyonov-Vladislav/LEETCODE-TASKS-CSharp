using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task705
{
    public class MyHashSet
    {
        private List<int> values;
        public MyHashSet()
        {
            values = new List<int>();
        }

        public void Add(int key)
        {
            if (!values.Contains(key))
            {
                values.Add(key);
                Console.WriteLine($"В объект MyHashSet было добавлено значение = {key}");
            }
            else
            {
                Console.WriteLine($"В объект MyHashSet не было добавлено значение = {key}, так как оно уже присутствует в нём");
            }
        }

        public void Remove(int key)
        {
            if (values.Contains(key))
            {
                values.Remove(key);
                Console.WriteLine($"В объекте MyHashSet было удалено значение = {key}");
            }
            else
            {
                Console.WriteLine($"В объекте MyHashSet не было удалено значение = {key}, так как оно не было найдено");
            }
        }

        public bool Contains(int key)
        {
            Console.WriteLine(values.Contains(key) ? $"Объект MyHashSet содержит значение = {key}" : $"Объект MyHashSet не содержит значение = {key}");
            return values.Contains(key);
        }
        public override string ToString()
        {
            string returnedStr = "";
            if (values.Count == 0)
            {
                returnedStr = "Объект MyHashSet пуст";
            }
            else if (values.Count == 1)
            {
                returnedStr = $"[{values[0]}]";
            }
            else
            { 
                for (int i = 0; i < values.Count; i++)
                {
                    if (i == 0)
                    {
                        returnedStr += $"[{values[i]}, ";
                    }
                    else if (i == values.Count - 1)
                    {
                        returnedStr += $"{values[i]}]\n";
                    }
                    else
                    {
                        returnedStr += $"{values[i]}, ";
                    }
                }
            }
            return returnedStr;
        }
    }
}
