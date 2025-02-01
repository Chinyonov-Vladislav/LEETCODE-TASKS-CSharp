using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task703
{
    /*
     703. K-й по величине элемент в потоке
    Вы работаете в приёмной комиссии университета и должны отслеживать kth наивысший балл, набранный абитуриентами, в режиме реального времени. 
    Это помогает динамически определять пороговые баллы для собеседований и зачисления по мере поступления новых абитуриентов.
    Вам нужно реализовать класс, который для заданного целого числа k поддерживает поток результатов тестов и постоянно возвращает k-й по величине результат теста после отправки нового результата. 
    Если быть более точным, мы ищем k-й по величине результат в отсортированном списке всех результатов.
    Реализовать класс KthLargest:
        KthLargest(int k, int[] nums) Инициализирует объект с помощью целого числа k и потока результатов теста nums.
        int add(int val) Добавляет в поток новый результат теста val и возвращает элемент, представляющий kth самый большой элемент в наборе результатов тестов на данный момент.
    https://leetcode.com/problems/kth-largest-element-in-a-stream/description/
     */
    public class Task703 : InfoBasicTask
    {
        public Task703(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 4, 5, 8, 2 };
            int k = 3;
            KthLargest kthLargest = new KthLargest(k, array);
            printArray(array, "Исходный массив: ");
            Console.WriteLine($"{kthLargest.Add(3)}"); // возвращает 4
            Console.WriteLine($"{kthLargest.Add(5)}"); // возвращает 5
            Console.WriteLine($"{kthLargest.Add(10)}"); // возвращает 5
            Console.WriteLine($"{kthLargest.Add(9)}"); // возвращает 8
            Console.WriteLine($"{kthLargest.Add(4)}"); // возвращает 8
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
    }
}
