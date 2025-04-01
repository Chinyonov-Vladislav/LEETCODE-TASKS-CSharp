using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task729
{
    /*
     729. Мой календарь I
    Вы внедряете программу для использования в качестве календаря. Мы можем добавить новое событие, если его добавление не приведёт к двойному бронированию.
    Двойное бронирование происходит, когда два события имеют некоторое ненулевое пересечение (то есть какой-то момент является общим для обоих событий).
    Событие может быть представлено в виде пары целых чисел startTime и endTime, которые представляют собой бронирование на полуоткрытом интервале [startTime, endTime), диапазоне действительных чисел x таких, что startTime <= x < endTime.
    Реализовать класс MyCalendar:
        MyCalendar() Инициализирует объект календаря.
        boolean book(int startTime, int endTime) Возвращает true, если событие можно успешно добавить в календарь, не вызвав двойного бронирования. В противном случае возвращает false и не добавляет событие в календарь.
    Ограничения:
        0 <= start < end <= 10^9
        Не более 1000 звонков будет сделано по адресу book.
    https://leetcode.com/problems/my-calendar-i/description/
     */
    public class Task729 : InfoBasicTask
    {
        public Task729(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] operations = new string[] { "My Calendar", "Book", "Book", "Book" };
            int[][] data = new int[][] {
                new int[] { },
                new int[] { 10,20 },
                new int[] { 15,25 },
                new int[] { 20,30 }
            };
            printArray(operations, "Массив операций: ");
            printTwoDimensionalArray(data, "Данные для операций");
            if (isValid(operations, data))
            {
                MyCalendar myCalendar = null;
                for (int i = 0; i < operations.Length; i++)
                {
                    switch (operations[i])
                    {
                        case "My Calendar":
                            myCalendar = new MyCalendar();
                            Console.WriteLine("Объект \"Мой календарь\" инициализирован");
                            break;
                        case "Book":
                            if (myCalendar != null)
                            {
                                bool res = myCalendar.Book(data[i][0], data[i][1]);
                                Console.WriteLine(res ? $"Событие на интервале [{data[i][0]},{data[i][1]}}} было забронировано" :$"Бронирование события на интервале [{data[i][0]},{data[i][1]}}} приводит к двойному бронированию");
                            }
                            else
                            {
                                Console.WriteLine("Объект \"Мой календарь\" не был инициализирован");
                            }
                            myCalendar = new MyCalendar();
                            
                            break;
                    }
                }
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
        private bool isValid(string[] operations, int[][] data)
        {
            if (operations.Length != data.Length) // проверка, что для каждой операции есть данные
            {
                return false;
            }
            int lowLimitTotalCountOperations = 1;
            int highLimitTotalCountOperations = 1001;
            if (operations.Length < lowLimitTotalCountOperations || operations.Length > highLimitTotalCountOperations) // проверка, что количество операций должно находится в диапазоне от 1 до 1001
            {
                return false;
            }
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < operations.Length; i++)
            {
                if (dict.ContainsKey(operations[i]))
                {
                    dict[operations[i]]++;
                }
                else
                {
                    dict.Add(operations[i], 1);
                }
            }
            if (!dict.ContainsKey("My Calendar") || dict["My Calendar"] != 1 || operations[0] != "My Calendar") // проверка наличия операции My Calendar, её единственный вызов и на то, что она является первой в списке операций
            {
                return false;
            }
            List<string> acceptedOperations = new List<string>() { "My Calendar", "Book" };
            foreach (var pair in dict)
            {
                if (!acceptedOperations.Contains(pair.Key)) // проверка на существовании только допустимых операций
                {
                    return false;
                }
            }
            int countOperationsBook = dict.ContainsKey("Book") ? dict["Book"] : 0;
            int lowLimitCountOperationsBook = 0;
            int highLimitCountOperationsBook = 1000;
            if (countOperationsBook < lowLimitCountOperationsBook || countOperationsBook > highLimitCountOperationsBook) // проверка, что количество операций Book должно находится в диапазоне от 0 до 1000
            {
                return false;
            }
            for (int i = 0; i < operations.Length; i++)
            {
                switch (operations[i])
                {
                    case "My Calendar":
                        if (data[i].Length != 0)
                        {
                            return false;
                        }
                        break;
                    case "Book":
                        if (data[i].Length != 2)
                        {
                            return false;
                        }
                        if (!(0 <= data[i][0] && data[i][0] < data[i][1] && data[i][0] <= (int)Math.Pow(10, 9)))
                        {
                            return false;
                        }
                        break;
                }
            }
            return true;
        }
    }
}
