using System;

namespace Friend_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //“Positive” testing(checking for “valid” conditions)
            Person bob = new Person("bob");
            Person sam = new Person("sam");
            Person sally = new Person("sally");
            Person tim = new Person("tim");
            Person abby = new Person("abby");
            Person chris = new Person("chris");
            Person kelly = new Person("kelly");

            bob.addToFriendList(sam);
            sally.addToFriendList(abby);
            tim.addToFriendList(chris);
            bob.addToFriendList(tim);
            sally.addToFriendList(chris);
            sally.addToFriendList(sam);
            bob.addToFriendList(sally);
            bob.addToFriendList(kelly);
            bob.addToFriendList(abby);
            bob.addToFriendList(chris);

            sally.removeFriend(chris);

            bob.listFriends();
            sam.listFriends();
            sally.listFriends();
            tim.listFriends();
            abby.listFriends();
            chris.listFriends();
            kelly.listFriends();

            //“Negative” testing(checking for “invalid” conditions) Person shawn = new Person("");
            Person shawn = new Person("");
            kelly.addToFriendList(kelly);
            shawn.listFriends();
            tim.addToFriendList(chris);
            sally.removeFriend(chris);

            //“Boundary” testing
            kelly.removeFriend(bob);
            kelly.listFriends();
        }
    }
}