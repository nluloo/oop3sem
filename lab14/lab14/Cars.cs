using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace lab14
{
    public class Car
    {
        public int MaxSizeItem { get; }
        public List<string> ListItem { get; } = new List<string>();
        private readonly int number;
        public static int CounterItem = 0;
        private static readonly object CounterLock = new object();

        public Car(int size, int number)
        {
            this.number = number;
            MaxSizeItem = size;
        }

        public void ShowItem()
        {
            Console.WriteLine($"{number} машина загрузила следующие элементы:");
            foreach (var item in ListItem)
            {
                Console.WriteLine(item);
            }

            lock (CounterLock)
            {
                CounterItem += ListItem.Count;
            }
        }
    }

    public class Store
    {
        private readonly Car[] cars;
        private readonly Queue<string> storeQueue = new Queue<string>();
        private readonly Mutex mutex = new Mutex();

        public Store(string fileItem, Car[] cars)
        {
            this.cars = cars;

            
            foreach (var line in File.ReadAllLines(fileItem))
            {
                storeQueue.Enqueue(line);
            }
        }

        public void UnloadStore(object obj)
        {
            Car car = obj as Car;

            while (true)
            {
                mutex.WaitOne();

                if (storeQueue.Count == 0)
                {
                    mutex.ReleaseMutex();
                    return;
                }

                
                while (car.ListItem.Count < car.MaxSizeItem && storeQueue.Count > 0)
                {
                    car.ListItem.Add(storeQueue.Dequeue());
                }

                mutex.ReleaseMutex();
                Thread.Sleep(100);
            }
        }
    }
}
