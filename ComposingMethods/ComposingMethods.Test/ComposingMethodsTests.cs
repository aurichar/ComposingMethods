using System.Collections.Generic;
using Xunit;
using static ComposingMethods.ComposingMethods;

namespace ComposingMethods.Test
{
    public class ComposingMethodsTests
    {
        [Fact]
        public void Version1_GroupOf2Friends()
        {
            var friendships = CreateWithGroupOf2Friends();
            Assert.Equal(2, FindLargestFriendGroup1(friendships));
        }

        [Fact]
        public void Version2_GroupOf2Friends()
        {
            var friendships = CreateWithGroupOf2Friends();
            Assert.Equal(2, FindLargestFriendGroup2(friendships));
        }

        [Fact]
        public void Version1_GroupOf3Friends()
        {
            var friendships = CreateWithGroupOf3Friends();
            Assert.Equal(3, FindLargestFriendGroup1(friendships));
        }

        [Fact]
        public void Version2_GroupOf3Friends()
        {
            var friendships = CreateWithGroupOf3Friends();
            Assert.Equal(3, FindLargestFriendGroup2(friendships));
        }

        [Fact]
        public void Version1_GroupOf4Friends()
        {
            var friendships = CreateWithGroupOf4Friends();
            Assert.Equal(4, FindLargestFriendGroup1(friendships));
        }

        [Fact]
        public void Version2_GroupOf4Friends()
        {
            var friendships = CreateWithGroupOf4Friends();
            Assert.Equal(4, FindLargestFriendGroup2(friendships));
        }

        private static IEnumerable<Friendship> CreateWithGroupOf2Friends()
        {
            yield return new Friendship { Friend1 = "Alice", Friend2 = "Bob" };
        }

        private static IEnumerable<Friendship> CreateWithGroupOf3Friends()
        {
            yield return new Friendship { Friend1 = "Alex", Friend2 = "Bob" };
            yield return new Friendship { Friend1 = "Sally", Friend2 = "Judy" };
            yield return new Friendship { Friend1 = "Thomas", Friend2 = "Sally" };
            yield return new Friendship { Friend1 = "Steve", Friend2 = "Alice" };
        }

        private static IEnumerable<Friendship> CreateWithGroupOf4Friends()
        {
            yield return new Friendship { Friend1 = "Alex", Friend2 = "Bob" };
            yield return new Friendship { Friend1 = "Sally", Friend2 = "Judy" };
            yield return new Friendship { Friend1 = "Thomas", Friend2 = "Sally" };
            yield return new Friendship { Friend1 = "Steve", Friend2 = "Alice" };
            yield return new Friendship { Friend1 = "Thomas", Friend2 = "James" };
        }
    }
}
