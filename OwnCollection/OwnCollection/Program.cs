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
            Print();
            myCollection.AddRange(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            Print();
            myCollection.Remove(10);
            Print();
            myCollection.RemoveAt(1);
            Print();
            myCollection.Sort();
            Print();
            myCollection[1] = 100;
            foreach (var item in myCollection)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine();
            myCollection.Insert(1, 200);
            Print();
            Console.WriteLine($"Index of 200: {myCollection.IndexOf(200)}");
            Console.WriteLine($"Contains 7: {myCollection.Contains(7).ToString()}");

            void Print()
            {
                Console.WriteLine(myCollection);
                Console.WriteLine();
            }
        }
    }
}
