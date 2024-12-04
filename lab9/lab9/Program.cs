using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            Concert concert1 = new Concert("Концерт ДДТ", 1500, 1);
            Concert concert2 = new Concert("Концерт Земфиры", 1000, 2);
            Concert concert3 = new Concert("Концерт Валерия Меладзе", 2000, 3);
            Concert concert4 = new Concert("Концерт Би-2", 1200, 4);

            manager.AddConcert(concert1);
            manager.AddConcert(concert2);
            manager.AddConcert(concert3);
            manager.AddConcert(concert4);

            manager.PrintAllConcerts();

            Console.WriteLine("\nДемонстрация работы foreach:"); // Без enumarable не работает
            foreach (var concert in manager)
            {
                Console.WriteLine(concert);
            }

            int searchID = 3;
            Console.WriteLine($"\nПоиск концерта с ID {searchID}:");
            string searchResult = manager.SearchConcert(searchID);
            Console.WriteLine(!string.IsNullOrEmpty(searchResult) ? searchResult : "Концерт не найден.");

            int RemoveId = 3;
            Console.WriteLine($"\nУдаление концерта из коллекции c ID {RemoveId}");
            manager.RemoveConcert(RemoveId);

            manager.PrintAllConcerts();

            Console.ReadLine();
            Console.Clear();


            Console.WriteLine("Второе задание:");


            Dictionary<int, char> dict = new Dictionary<int, char>();
            dict.Add(0, 'a');
            dict.Add(1, 'b');
            dict.Add(2, 'c');
            dict.Add(3, 'd');
            dict.Add(4, 'e');
            dict.Add(5, 'f');

            foreach (var item in dict)
            {
                Console.WriteLine($"Ключ: {item.Key}, Значение: {item.Value}");
            }

            int[] Remove = { 1, 2, 3 };
                
            for(int i = 0; i < Remove.Length; i++)
            {
                dict.Remove(Remove[i]);
            }

            Console.WriteLine("\nКоллекция после удаления: ");
            foreach (var item in dict)
            {
                Console.WriteLine($"Ключ: {item.Key}, Значение: {item.Value}");
            }

            Console.WriteLine("\nКоллекция после изменения(добавление новых элементов): ");
            dict[6] = 'g'; 
            dict[0] = 'z';

            foreach (var item in dict)
            {
                Console.WriteLine($"Ключ: {item.Key}, Значение: {item.Value}");
            }

            Console.WriteLine("\nСоздание второй коллекции");
            List <char> list = new List<char>();
            foreach (var item in dict)
            {
                list.Add(item.Value);
                Console.WriteLine("Элемент успешно добавлен во вторую коллекцию");
            }

            foreach (var item in list)
            {
                Console.WriteLine($"Значение: {item}");
            }

            char items = 'g';
            if (list.Contains(items))
            {
                Console.WriteLine($"Элемент '{items}' находится во второй коллекции");
            }
            else
            {
                Console.WriteLine("Такого элемента нет");
            }

            Console.ReadLine();
            Console.Clear();


            Console.WriteLine("Третье задание:");

            ObservableCollection<Concert> observConcert = new ObservableCollection<Concert>();

            observConcert.CollectionChanged += ObservConcert_CollectionChanged;

            observConcert.Add(concert1);
            observConcert.Add(concert2);

            observConcert.Remove(concert2);

            Console.ReadLine();
        }

        private static void ObservConcert_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Элемент добавлен в коллецию");
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Элемент удален из коллекции");
            }
        }

    }
}
