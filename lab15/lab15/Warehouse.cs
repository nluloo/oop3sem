using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{

    internal class Warehouse
    {
        private BlockingCollection<string> warehouse = new BlockingCollection<string>();
        private object locker = new object();

        public void Start()
        {
            var sellers = new (string Name, string Product, int Interval)[]
            {
                ("Поставщик 1", "Микроволновая печь", 1000),
                ("Поставщик 2", "Стральная машина", 2000),
                ("Поставщик 3", "Холодильник", 3000),
                ("Поставщик 4", "Посудомойка", 4000),
                ("Поставщик 5", "Электрическая плита", 5000),
            };

            foreach (var sel in sellers)
            {
                Task.Run(() => Supply(sel.Name, sel.Product, sel.Interval));
            }

            for(int i = 0; i < 10; i++)
            {
                Task.Run(() => Buy($"Покупатель {i}"));
            }
        }

        private void Supply(string name, string prod, int time)
        {
            while (true)
            {
                Thread.Sleep(time);
                warehouse.Add(prod);
                lock(locker)
                {
                    Console.WriteLine($"{name} завез {prod}. Состояние склада: {string.Join(",", warehouse)}");
                }
            }
        }

        private void Buy(string customer)
        {
            while (true)
            {
                try
                {
                    string product = warehouse.Take();
                    lock (locker)
                    {
                        Console.WriteLine($"{customer} купил {product}. Состояние склада: {string.Join(",", warehouse)}");
                    }
                }
                catch (Exception ex)
                {
                    lock (locker)
                    {
                        Console.WriteLine($"{customer} ушел с пустыми руками");
                    }
                }
            }
        }
    }
   
}
