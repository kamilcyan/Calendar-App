using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            CircularLinkedList<string> categories = new CircularLinkedList<string>();
            categories.AddLast("Sport");
            categories.AddLast("Kultura");
            categories.AddLast("Historia");
            categories.AddLast("Geografia");
            categories.AddLast("Ludzie");
            categories.AddLast("Technologia");
            categories.AddLast("Przyroda");
            categories.AddLast("Nauka");

            Random random = new Random();
            int totalTime = 0;
            int remainingTime = 0;
            foreach (string category in categories)
            {
                if (remainingTime <= 0)
                {
                    Console.WriteLine("Nacisnij enter by zaczac lub dowolny klawisz by wyjsc");
                    switch(Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            totalTime = random.Next(1000, 5000);
                            remainingTime = totalTime;
                            break;
                        default:
                            return;

                    }
                }
                int categoryTime = (-450 * remainingTime) / (totalTime - 50) + 500 + (22500 / (totalTime - 50));
                remainingTime -= categoryTime;
                Thread.Sleep(categoryTime);

                Console.ForegroundColor = remainingTime <= 0 ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(category);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        
        /*
        public class CircularLinkedList<T> : LinkedList<T>
        {
            public new IEnumerator GetEnumerator()
            {
                return new CircularLinkedListEnumerator<T>(this);
            }
        }

        

        */
    }
    internal class CircularLinkedList
    {
        

        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
        {
            return current.Next ?? current.List.First;
        }

        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current)
        {
            return current.Previous ?? current.List.Last;
        }
    }
}
