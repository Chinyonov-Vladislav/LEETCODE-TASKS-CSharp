using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task355
{
    /*
     355. Дизайн Твиттера
    Разработайте упрощённую версию Twitter, в которой пользователи смогут публиковать твиты, подписываться/отписываться от других пользователей и просматривать 10 последние твиты в ленте новостей пользователя.
    Реализовать класс Twitter:
        Twitter() Инициализирует ваш объект Twitter.
        void postTweet(int userId, int tweetId) Создаёт новый твит с идентификатором tweetId от пользователя userId. Каждый вызов этой функции будет сопровождаться уникальным tweetId.
        List<Integer> getNewsFeed(int userId) Получает 10 самые последние идентификаторы твитов в ленте новостей пользователя. Каждый элемент в ленте новостей должен быть опубликован пользователями, на которых подписан пользователь, или самим пользователем. Твиты должны быть упорядочены от самых новых к менее новым.
        void follow(int followerId, int followeeId) Пользователь с ID followerId начал подписываться на пользователя с ID followeeId.
        void unfollow(int followerId, int followeeId) Пользователь с ID followerId начал отменять подписку на пользователя с ID followeeId.
    https://leetcode.com/problems/design-twitter/description/
     */
    public class Task355 : InfoBasicTask
    {
        public Task355(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] operations = new string[] { "Twitter", "postTweet", "getNewsFeed", "follow", "postTweet", "getNewsFeed", "unfollow", "getNewsFeed" };
            int[][] data = new int[][] {
                new int[] { },
                new int[] { 1,5 },
                new int[] { 1 },
                new int[] { 1,2 },
                new int[] { 2,6 },
                new int[] {1 },
                new int[] {1,2 },
                new int[] { 1 }
            };
            if (isValid(operations, data))
            {
                Twitter twitter = new Twitter();
                Console.WriteLine("Объект Twitter инициализирован");
                for (int i = 1; i < operations.Length; i++)
                {
                    switch (operations[i])
                    {
                        case "postTweet":
                            twitter.PostTweet(data[i][0], data[i][1]);
                            Console.WriteLine($"Пользователь с id = {data[i][0]} запостил tweet с id = {data[i][1]}");
                            break;
                        case "getNewsFeed":
                            IList<int> res = twitter.GetNewsFeed(data[i][0]);
                            printIListInt(res, $"Последние 10 твитов от пользователя с id = {data[i][0]} и пользователей, на которых он подписан (от новых к старым): ");
                            break;
                        case "follow":
                            twitter.Follow(data[i][0], data[i][1]);
                            Console.WriteLine($"Пользователь с id = {data[i][0]} подписался на пользователя с id = {data[i][1]}");
                            break;
                        case "unfollow":
                            twitter.Unfollow(data[i][0], data[i][1]);
                            Console.WriteLine($"Пользователь с id = {data[i][0]} отписался от пользователя с id = {data[i][1]}");
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
            if (operations.Length != data.Length)
            {
                return false;
            }
            if (operations[0] != "Twitter")
            {
                return false;
            }
            int countOperations = operations.Length - 1;
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10, 4);
            if (countOperations < lowLimit || countOperations > highLimit)
            {
                return false;
            }
            highLimit = 500;
            int lowLimitIdTweet = 0;
            int highLimitIdTweet = (int)Math.Pow(10, 4);
            HashSet<int> idTweets = new HashSet<int>();
            for (int i = 1; i < operations.Length; i++)
            {
                int countNeededData = 2;
                if (operations[i] == "getNewsFeed")
                {
                    countNeededData = 1;
                }
                if (data[i].Length != countNeededData)
                {
                    return false;
                }
                if (operations[i] == "postTweet")
                {
                    if (idTweets.Contains(data[i][1]))
                    {
                        return false;
                    }
                    idTweets.Add(data[i][1]);
                    if (data[i][1] < lowLimitIdTweet || data[i][1] > highLimitIdTweet)
                    {
                        return false;
                    }
                    if (data[i][0] < lowLimit || data[i][0] > highLimit)
                    {
                        return false;
                    }
                }
                else
                {
                    for (int index = 0; index < data[i].Length; index++)
                    {
                        if (data[i][index] < lowLimit || data[i][index] > highLimit)
                        {
                            return false;
                        }
                    }
                }
                if (operations[i] == "follow")
                {
                    if (data[i][0] == data[i][1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
