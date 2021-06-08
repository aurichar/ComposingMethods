using System;
using System.Collections.Generic;

namespace ComposingMethods
{
    public static class ComposingMethods
    {
        /// <summary>
        /// Version 1. Finds the largest group of friends, using only a single method.
        /// </summary>
        public static int FindLargestFriendGroup1(IEnumerable<Friendship> friendships)
        {
            // Construct graph of friendships
            var graph = new Dictionary<string, IList<string>>();

            foreach (var friendship in friendships)
            {
                if (graph.TryGetValue(friendship.Friend1, out var currentFriends1))
                {
                    currentFriends1.Add(friendship.Friend2);
                }
                else
                {
                    graph[friendship.Friend1] = new List<string> { friendship.Friend2 };
                }

                if (graph.TryGetValue(friendship.Friend2, out var currentFriends2))
                {
                    currentFriends2.Add(friendship.Friend1);
                }
                else
                {
                    graph[friendship.Friend2] = new List<string> { friendship.Friend1 };
                }
            }

            var largestFriendGroup = 0;
            var seen = new HashSet<string>();

            foreach (var friend in graph.Keys)
            {
                if (!seen.Add(friend))
                {
                    continue;
                }

                // Do a graph traversal to determine the size of this unseen component
                var friendGroupSize = 0;
                var traversal = new Queue<string>();

                traversal.Enqueue(friend);

                while (traversal.Count > 0)
                {
                    friendGroupSize++;
                    var next = traversal.Dequeue();

                    foreach (var friendOfFriend in graph[next])
                    {
                        if (seen.Add(friendOfFriend))
                        {
                            traversal.Enqueue(friendOfFriend);
                        }
                    }
                }

                largestFriendGroup = Math.Max(largestFriendGroup, friendGroupSize);
            }

            return largestFriendGroup;
        }

        /// <summary>
        /// Version 2. Finds the largest group of friends, using a lot of smaller, more-focused methods.
        /// </summary>
        public static int FindLargestFriendGroup2(IEnumerable<Friendship> friendships)
        {
            var graph = CreateGraph(friendships);
            return FindLargestFriendGroup(graph);
        }

        private static IDictionary<string, IList<string>> CreateGraph(IEnumerable<Friendship> friendships)
        {
            var graph = new Dictionary<string, IList<string>>();

            foreach (var friendship in friendships)
            {
                AddFriendshipToGraph(graph, friendship.Friend1, friendship.Friend2);
                AddFriendshipToGraph(graph, friendship.Friend2, friendship.Friend1);
            }

            return graph;
        }

        private static void AddFriendshipToGraph(IDictionary<string, IList<string>> graph, string friend1, string friend2)
        {
            if (graph.TryGetValue(friend1, out var currentFriends))
            {
                currentFriends.Add(friend2);
            }
            else
            {
                graph[friend1] = new List<string> { friend2 };
            }
        }

        private static int FindLargestFriendGroup(IDictionary<string, IList<string>> graph)
        {
            var largestFriendGroup = 0;
            var seen = new HashSet<string>();

            foreach (var friend in graph.Keys)
            {
                if (!seen.Add(friend))
                {
                    continue;
                }

                var friendGroupSize = FindFriendGroupSize(friend, graph, seen);

                largestFriendGroup = Math.Max(largestFriendGroup, friendGroupSize);
            }

            return largestFriendGroup;
        }

        private static int FindFriendGroupSize(string friend, IDictionary<string, IList<string>> graph, ISet<string> seen)
        {
            var friendGroupSize = 0;
            var traversal = new Queue<string>();

            traversal.Enqueue(friend);

            while (traversal.Count > 0)
            {
                friendGroupSize++;
                var next = traversal.Dequeue();

                foreach (var friendOfFriend in graph[next])
                {
                    if (seen.Add(friendOfFriend))
                    {
                        traversal.Enqueue(friendOfFriend);
                    }
                }
            }

            return friendGroupSize;
        }

        public class Friendship
        {
            public string Friend1 { get; init; }
            public string Friend2 { get; init; }
        }
    }
}
