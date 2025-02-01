using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task482
{
    /*
     482. Форматирование лицензионного ключа
    Вам предоставлен лицензионный ключ, представленный в виде строки s, состоящей только из буквенно-цифровых символов и тире. Строка разделена на n + 1 групп n тире. Вам также предоставлено целое число k.
    Мы хотим переформатировать строку s так, чтобы каждая группа содержала ровно k символов, за исключением первой группы, которая может быть короче, чем k, но всё равно должна содержать хотя бы один символ. Кроме того, между двумя группами должен быть вставлен дефис, а все строчные буквы должны быть преобразованы в заглавные.
    Верните переформатированный лицензионный ключ.
     */
    public class Task482 : InfoBasicTask
    {
        public Task482(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string original = "2-5g-3-J";
            int countSymbolsAfterDash = 2;
            string formattedString = licenseKeyFormatting(original, countSymbolsAfterDash);
            Console.WriteLine($"Оригинальная строка = \"{original}\"");
            Console.WriteLine($"Отформатированная строка = \"{formattedString}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string licenseKeyFormatting(string s, int k)
        {
            s = s.Replace("-", "");
            if (k >= s.Length)
            {
                return s.ToUpper();
            }
            StringBuilder sb = new StringBuilder();
            int count = 0;
            for (int i = s.Length-1; i >= 0; i--)
            {
                if (count == k)
                {
                    sb.Insert(0, "-");
                    sb.Insert(0, s[i]);
                    count = 1;
                }
                else
                {
                    sb.Insert(0,s[i]);
                    count++;
                }
            }
            return sb.ToString().ToUpper();
        }
    }
}
