using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task841
{
    /*
     841. Ключи и комнаты
     Здесь есть комнаты, помеченные от 0 до n - 1, и все они заперты, за исключением комнаты 0. Ваша цель - посетить все комнаты. Однако вы не можете войти в запертую комнату, не имея ключа от нее.
    Когда вы заходите в комнату, вы можете найти в ней набор отдельных ключей. На каждом ключе есть номер, обозначающий, какую комнату он открывает, и вы можете взять их все с собой, чтобы открыть другие комнаты.
    Учитывая массив комнат, где rooms[i] - это набор ключей, которые вы можете получить, посетив комнату i, верните значение true, если вы можете посетить все комнаты, или значение false в противном случае.
     Ограничения:
        n == rooms.length
        2 <= n <= 1000
        0 <= rooms[i].length <= 1000
        1 <= sum(rooms[i].length) <= 3000
        0 <= rooms[i][j] < n
        Все значения в массиве rooms[i] уникальны.
     https://leetcode.com/problems/keys-and-rooms/description/
     */
    public class Task841 : InfoBasicTask
    {
        public Task841(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<IList<int>> rooms = new List<IList<int>>() {
                new List<int>() { 1,3 },
                new List<int>() { 3,0,1 },
                new List<int>() { 2 },
                new List<int>() { 0 },
            };
            printIListIListInt(rooms, "Комнаты с ключами: ");
            if (isValid(rooms))
            {
                Console.WriteLine(canVisitAllRooms(rooms) ? "Возможно посетить все комнаты, имея первоначально только ключ от двери под номером 0" : "Невозможно посетить все комнаты, имея первоначально только ключ от двери под номером 0");
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
        private bool isValid(IList<IList<int>> rooms)
        {
            int lowLimitCountRooms = 2;
            int highLimitCountRooms = 1000;
            int lowLimitCountKeysInRoom = 0;
            int highLimitCountKeysInRoom = 1000;
            int lowLimitNumberKeyInRoom = 0;
            int highLimitNumberKeyInRoom = rooms.Count;
            if (rooms.Count < lowLimitCountRooms || rooms.Count > highLimitCountRooms)
            {
                return false;
            }
            foreach (IList<int> room in rooms)
            {
                if (room.Count < lowLimitCountKeysInRoom || room.Count > highLimitCountKeysInRoom)
                {
                    return false;
                }
                HashSet<int> keys = new HashSet<int>();
                foreach (int key in room)
                {
                    if (key < lowLimitNumberKeyInRoom || key >= highLimitNumberKeyInRoom)
                    {
                        return false;
                    }
                    keys.Add(key);
                }
                if (keys.Count != room.Count)
                {
                    return false;
                }
            }
            return true;
        }
        private bool canVisitAllRooms(IList<IList<int>> rooms)
        {
            bool[] visitedRooms = new bool[rooms.Count];
            Stack<int> keys = new Stack<int>();
            keys.Push(0);
            while (keys.Count > 0)
            {
                int currentKey = keys.Pop();
                if (!visitedRooms[currentKey])
                {
                    visitedRooms[currentKey] = true;
                    IList<int> keysInCurrentRoom = rooms[currentKey];
                    foreach (int key in keysInCurrentRoom)
                    {
                        keys.Push(key);
                    }
                }
            }
            foreach (bool isRoomVisited in visitedRooms)
            {
                if (!isRoomVisited)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
