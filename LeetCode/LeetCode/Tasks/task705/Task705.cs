using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task705
{
    /*
    705. Создание структуры данных HashSet
    Создайте хэш-набор без использования каких-либо встроенных библиотек хэш-таблиц.
    Реализовать MyHashSet класс:
        void add(key) Вставляет значение key в HashSet.
        bool contains(key) Возвращает, существует ли значение key в HashSet или нет.
        void remove(key) Удаляет значение key из HashSet. Если key не существует в HashSet, ничего не делает.
    https://leetcode.com/problems/design-hashset/description/
     */
    public class Task705 : InfoBasicTask
    {
        public Task705(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            MyHashSet myHashSet = new MyHashSet();
            myHashSet.Add(1);
            myHashSet.Add(2);
            myHashSet.Contains(1);
            myHashSet.Contains(3);
            myHashSet.Add(2);
            myHashSet.Contains(2);
            myHashSet.Remove(2);
            myHashSet.Contains(2);
            Console.WriteLine(myHashSet);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
    }
}
