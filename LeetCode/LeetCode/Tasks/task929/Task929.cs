using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task929
{
    /*
     929. Уникальные адреса электронной почты
    Каждое действительное электронное письмо состоит из локального имени и доменного имени, разделенных '@' знаком. 
    Помимо строчных букв, электронное письмо может содержать одну или несколько '.' или '+'.
        Например, в "alice@leetcode.com""alice" — это локальное имя, а "leetcode.com" — доменное имя.
    Если вы добавите точки '.' между некоторыми символами в локальной части адреса электронной почты, отправленная по этому адресу почта будет пересылаться на тот же адрес без точек в локальной части. Обратите внимание, что это правило не применяется к доменным именам.
        Например, "alice.z@leetcode.com" и "alicez@leetcode.com" переслать на один и тот же адрес электронной почты.
    Если вы добавите знак «плюс '+'» в локальное имя, все, что будет после первого знака «плюс», будет игнорироваться. Это позволяет фильтровать определенные электронные письма. Обратите внимание, что это правило не применяется к доменным именам.
        Например, "m.y+name@email.com" будет перенаправлено на "my@email.com".
    Можно использовать оба этих правила одновременно.
        Учитывая массив строк emails с адресами, по которым мы отправляем по одному письму на каждый адрес emails[i], верните количество различных адресов, на которые действительно приходят письма.
     Ограничения:
        1 <= emails.length <= 100
        1 <= emails[i].length <= 100
        emails[i] состоит из строчных английских букв, '+', '.' и '@'.
        Каждый emails[i] содержит ровно один '@' символ.
        Все локальные и доменные имена непустые.
        Местные названия не начинаются с '+' символа.
        Доменные имена заканчиваются суффиксом ".com".
        Доменные имена должны содержать хотя бы один символ перед суффиксом ".com".
     https://leetcode.com/problems/unique-email-addresses/description/
     */
    public class Task929 : InfoBasicTask
    {
        public Task929(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] array = new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" };
            printArray(array, "Email - адреса: ");
            int countUniqueEmail = numUniqueEmails(array);
            Console.WriteLine($"Количество уникальных email - адресов = {countUniqueEmail}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int numUniqueEmails(string[] emails)
        {
            HashSet<string> uniqueEmails = new HashSet<string>();
            for (int i = 0; i < emails.Length; i++)
            {
                string[] parts = emails[i].Split('@');
                if (parts.Length != 2)
                {
                    continue;
                }
                StringBuilder localName = new StringBuilder();
                foreach (char c in parts[0])
                {
                    if (c == '+')
                    {
                        break;
                    }
                    else if (c == '.')
                    {
                        continue;
                    }
                    else
                    {
                        localName.Append(c);
                    }
                }
                if (localName.Length == 0 || !parts[1].EndsWith(".com") || parts[1].Length <= 4)
                {
                    continue;
                }
                localName.Append("@");
                localName.Append(parts[1]);
                uniqueEmails.Add(localName.ToString());
            }
            return uniqueEmails.Count;
        }
        
    }
}
