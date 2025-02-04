using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1108
{
    /*
     1108. Усеченный IP-адрес
    Учитывая действительный (IPv4) IP-адрес address, верните усечённую версию этого IP-адреса.
    Отключенный IP-адрес заменяет каждую точку "." на "[.]".
    https://leetcode.com/problems/defanging-an-ip-address/description/
     */
    public class Task1108 : InfoBasicTask
    {
        public Task1108(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "1.1.1.1";
            Console.WriteLine($"Оригинальный ip - адрес = \"{str}\"");
            Console.WriteLine($"Усеченный ip - адрес = \"{defangIPaddr(str)}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public string defangIPaddr(string address)
        {
            return String.Join("[.]", address.Split('.'));
        }
    }
}
