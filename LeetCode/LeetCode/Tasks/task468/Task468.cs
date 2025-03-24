using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task468
{
    /*
     468. Проверка IP-адреса
    Учитывая строку queryIP, верните "IPv4" если IP является допустимым адресом IPv4, "IPv6" если IP является допустимым адресом IPv6 или "Neither" если IP не является допустимым адресом ни одного из этих типов.
    Действительный IPv4 адрес - это IP-адрес в форме "x1.x2.x3.x4", где 0 <= xi <= 255 и xi не может содержать начальных нулей. 
        Например, "192.168.1.1" и "192.168.1.0" являются допустимыми адресами IPv4, в то время как "192.168.01.1", "192.168.1.00" и "192.168@1.1" являются недопустимыми адресами IPv4.
    Действительный IPv6-адрес — это IP-адрес в формате "x1:x2:x3:x4:x5:x6:x7:x8" где:
        1 <= xi.length <= 4
        xi Это шестнадцатеричная строка, которая может содержать цифры, строчные английские буквы ('a' — 'f') и заглавные английские буквы ('A' — 'F').
        В xi допускаются начальные нули.
    Например, "2001:0db8:85a3:0000:0000:8a2e:0370:7334" и "2001:db8:85a3:0:0:8A2E:0370:7334" — допустимые IPv6-адреса, а "2001:0db8:85a3::8A2E:037j:7334" и "02001:0db8:85a3:0000:0000:8a2e:0370:7334" — недопустимые IPv6-адреса.
    Ограничения:
        queryIP состоит только из английских букв, цифр и символов '.' и ':'.
    https://leetcode.com/problems/validate-ip-address/description/
     */
    public class Task468 : InfoBasicTask
    {
        public Task468(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string ip = "2001:0db8:85a3:0:0:8A2E:0370:7334";
            Console.WriteLine($"IP - адрес: \"{ip}\"");
            if (isValid(ip))
            {
                string typeIp = validIPAddress(ip);
                Console.WriteLine(typeIp == "Neither" ? "Данный ip - адрес не является валидным!" : $"Тип IP - адреса = {typeIp}");
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
        private bool isValid(string queryIP)
        {
            foreach (char c in queryIP)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == '.' || c == ':'))
                {
                    return false;
                }
            }
            return true;
        }
        private string validIPAddress(string queryIP)
        {
            if (queryIP.Contains('.'))
            {
                string[] parts = queryIP.Split('.');
                if (parts.Length != 4)
                {
                    return "Neither";
                }
                foreach (string part in parts)
                {
                    if (part.Length > 1 && part.StartsWith("0"))
                    {
                        return "Neither";
                    }
                    int value = 0;
                    bool isSuccess = int.TryParse(part, out value);
                    if (!isSuccess)
                    {
                        return "Neither";
                    }
                    if (!(0 <= value && value <= 255))
                    {
                        return "Neither";
                    }
                }
                return "IPv4";
            }
            else if(queryIP.Contains(':'))
            {
                List<char> acceptedChars = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F' };
                string[] parts = queryIP.Split(':');
                if (parts.Length != 8)
                {
                    return "Neither";
                }
                foreach (string part in parts)
                {
                    if (!(1 <= part.Length && part.Length <= 4))
                    {
                        return "Neither";
                    }
                    foreach (char c in part)
                    {
                        if (!acceptedChars.Contains(c))
                        {
                            return "Neither";
                        }
                    }
                }
                return "IPv6";
            }
            return "Neither";
        }
    }
}
