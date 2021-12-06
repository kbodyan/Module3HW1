using System;

namespace OwnCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myCollection = new ListCollection<int>();
            myCollection.Add(10);
            myCollection.Add(20);
            myCollection.Add(30);
            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }

            myCollection.Remove(20);
            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
