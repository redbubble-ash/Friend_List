using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Friend_List
{
    internal class Person
    {
        private Person[] friends;
        public string Name { get; private set; }

        public Person(string name)
        {
            this.Name = name;
            friends = new Person[5];
        }

        //compare another instance of a Person to determine whether it’s the same person or not
        //when check, call method: eg. person1.Equals(person2)
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Person))
            {
                return false;
            }

            //obj is considered as a Person object type
            //item is an instance Person
            var item = obj as Person;

            if (this.Name == item.Name)
            {
                return true;
            }
            else return false;
        }

        //return a String representation of this Person
        public override string ToString()
        {
            return this.Name;
        }

        //Automatically-growing array
        public void growArrayList()
        {
            if (friends[friends.Length - 1] != null)
            {
                //build a new array with additional 5 slots
                Person[] newArray = new Person[friends.Length + 5];

                for (int i = 0; i < friends.Length; i++)
                {
                    //copy everything from friends list to newArray list
                    newArray[i] = friends[i];
                }

                //assign newArray to friends list, since array is reference type, this action only change the reference to the new array(heap), not change the friends itself.
                friends = newArray;
            }
        }

        public bool isAddFriend(Person person)
        {
            //check if friends array is full, then automatically-growing additional 5 slots.
            growArrayList();
            //Don’t add the same friend more than once. Hint: Use the .equals() method for Person
            foreach (Person friend in friends)
            {
                if (friend != null && friend.Equals(person)) return false;
            }

            //Can’t add self as friend
            //"this" is the instance that isAddFriend get called on
            if (this.Equals(person)) return false;
            else return true;
        }

        //Add Friend overload – take in as argument a “name” and create a Person object to add to the array of Friends. Enforce invariants.
        public void addToFriendList(Person newFriend)
        {
            if (isAddFriend(newFriend))
            {
                for (int i = 0; i < friends.Length; i++)
                {
                    if (friends[i] == null)
                    {
                        friends[i] = newFriend;
                        break;
                    }
                }

                //“bilateral” relationships.
                //A “bilateral” relationship means that when “Person A” adds “Person B” as a friend, “Person B” also adds “Person A” as a friend.
                //"this" is MYSELF!!
                if (newFriend.isAddFriend(this))
                {
                    newFriend.addToFriendList(this);
                }
            }
        }

        //Remove Friend
        public void removeFriend(Person friendToRemove)
        {
            foreach (Person friend in friends)
            {
                if (friend != null && friend.Equals(friendToRemove))
                {
                    int indexToRemove = Array.IndexOf(friends, friendToRemove);

                    if (indexToRemove != -1)
                    {
                        Person[] copyArr = new Person[friends.Length - 1];

                        // copy the elements before the found index
                        for (int i = 0; i < indexToRemove; i++)
                        {
                            copyArr[i] = friends[i];
                        }

                        // copy the elements after the found index
                        for (int i = indexToRemove; i < copyArr.Length; i++)
                        {
                            copyArr[i] = friends[i + 1];
                        }

                        //assign new array copyarr to friends
                        friends = copyArr;
                    }
                }
            }
        }

        //List Friends – print out a list of friends
        public void listFriends()
        {
            Console.WriteLine(this + "'s friends' list is:");
            foreach (Person friend in friends)
            {
                if (friend != null)
                {
                    Console.Write(friend.ToString() + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}