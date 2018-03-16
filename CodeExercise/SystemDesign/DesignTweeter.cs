using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
   

    /// <summary>
    /// Design a simplified version of Twitter where users can post tweets, follow/unfollow another user and is able to see the 10 most recent tweets 
    /// in the user's news feed. Your design should support the following methods:

    /// postTweet(userId, tweetId): Compose a new tweet.
    /// 
    /// getNewsFeed(userId): Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users
    /// who the user followed or by the user herself. Tweets must be ordered from most recent to least recent.
    /// 
    /// follow(followerId, followeeId): Follower follows a followee.
    /// 
    /// unfollow(followerId, followeeId): Follower unfollows a followee.
    /// </summary>
    class Twitter
    {

        Dictionary<int, TweetUser> userTable;

        /** Initialize your data structure here. */
        public Twitter()
        {
            userTable = new Dictionary<int, TweetUser>();
        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            if (!userTable.ContainsKey(userId))
            {
                TweetUser newusr = new TweetUser(userId);
                userTable.Add(userId, newusr);
            }

            TweetUser usr = userTable[userId];
            usr.AddTweet(tweetId);
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            if (!userTable.ContainsKey(userId))
            {
                return new List<int>();
            }

            SortedDictionary<int, int> pq = new SortedDictionary<int, int>(new TweetTimeComparer());  // time, tweet
            GetTop10TweetIdFromUserFriends(userTable[userId], pq);
            List<int> ans = new List<int>();

            int count = 10;
            foreach(var timeKey in pq.Keys)
            {
                ans.Add(pq[timeKey]);
                count--;
                if (count <=0)
                {
                    break;
                }
            }

            return ans.ToArray();
        }

        private void GetTop10TweetIdFromUserFriends(TweetUser usr, SortedDictionary<int, int> pq)
        {
            var friendIds = usr.friends;       

            foreach(var friendId in friendIds)
            {
                TweetUser f = userTable[friendId];

                int count = 10;
                foreach(var timeStamp in f.tweets.Keys)
                {
                    Tweet tw = f.tweets[timeStamp];
                    pq.Add(tw.time, tw.tweetId);
                    count--;
                    if (count <=0)
                    {
                        break;
                    }
                }
            }
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            if (!userTable.ContainsKey(followeeId))
            {
                userTable.Add(followeeId, new TweetUser(followeeId));
            }

            if (!userTable.ContainsKey(followerId))
            {
                userTable.Add(followerId, new TweetUser(followerId));       
            }

            TweetUser usr = userTable[followerId];
            usr.AddFriend(followeeId);
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            if (!userTable.ContainsKey(followeeId) || !userTable.ContainsKey(followerId))
            {
                return;
            }

            TweetUser usr = userTable[followerId];
            usr.RemoveFriend(followeeId);

        }

        /// <summary>
        ///  support method
        /// </summary>

        class TweetUser
        {
            public int userID { get; }

            public SortedDictionary<int, Tweet> tweets { get; }

            public HashSet<int> friends;

            private static int stimeStamp = 0;

            public TweetUser(int uid)
            {
                userID = uid;
                tweets = new SortedDictionary<int, Tweet>(new TweetTimeComparer()); // time stamp, Tweet
                friends = new HashSet<int>();
                friends.Add(uid);  // self friend
            }

            public void AddTweet(int tweetId)
            {
                int currTimeStamp = stimeStamp++;
                Tweet tw = new Tweet(tweetId, currTimeStamp);
                tweets.Add(currTimeStamp, tw);
            }

            public void AddFriend(int friendId)
            {
                friends.Add(friendId);
            }

            public void RemoveFriend(int friendId)
            {
                friends.Remove(friendId);
            }

        }

        class Tweet
        {
            public int tweetId { get; }

            public int time { get; }

            public Tweet(int tweetId, int time)
            {
                this.tweetId = tweetId;
                this.time = time;
            }
        }

        // sort by timeStamp
        class TweetTimeComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
    }
}
