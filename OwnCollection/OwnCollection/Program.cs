using System;

namespace OwnCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myCollection = new ListCollection<int>();
            myCollection.Add(30);
            myCollection.Add(20);
            myCollection.Add(10);
            Console.WriteLine(myCollection);
            Console.WriteLine();
            myCollection.AddRange(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            Console.WriteLine(myCollection);
            Console.WriteLine();
            myCollection.Remove(10);
            Console.WriteLine(myCollection);
            Console.WriteLine();
            myCollection.RemoveAt(1);
            Console.WriteLine(myCollection);
            Console.WriteLine();
            myCollection.Sort();
            Console.WriteLine(myCollection);
            Console.WriteLine();
        }
    }
}
