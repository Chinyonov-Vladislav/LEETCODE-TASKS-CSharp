using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task355
{
    public class Twitter
    {
        List<Tuple<int, int>> tweetsList;
        Dictionary<int, HashSet<int>> dictSubscribers;
        public Twitter()
        {
            tweetsList = new List<Tuple<int, int>>();
            dictSubscribers = new Dictionary<int, HashSet<int>>();
        }

        public void PostTweet(int userId, int tweetId)
        {
            tweetsList.Add(new Tuple<int, int>(userId, tweetId));
        }

        public IList<int> GetNewsFeed(int userId)
        {
            List<int> res = new List<int>();
            List<int> idUsersForTweets = new List<int>() { userId };
            if (dictSubscribers.ContainsKey(userId))
            {
                HashSet<int> followees = dictSubscribers[userId];
                foreach (var id in followees)
                {
                    idUsersForTweets.Add(id);
                }
            }
            for (int i = tweetsList.Count - 1; i >= 0; i--)
            {
                if (idUsersForTweets.Contains(tweetsList[i].Item1))
                {
                    res.Add(tweetsList[i].Item2);
                }
                if (res.Count == 10)
                {
                    break;
                }
            }
            return res;
        }

        public void Follow(int followerId, int followeeId)
        {
            if (dictSubscribers.ContainsKey(followerId))
            {
                dictSubscribers[followerId].Add(followeeId);
            }
            else
            {
                dictSubscribers.Add(followerId, new HashSet<int>() { followeeId });
            }
        }

        public void Unfollow(int followerId, int followeeId)
        {
            if (dictSubscribers.ContainsKey(followerId))
            {
                if (dictSubscribers[followerId].Contains(followeeId))
                {
                    dictSubscribers[followerId].Remove(followeeId);
                }
            }
        }
    }
}
