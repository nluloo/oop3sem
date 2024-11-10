using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    internal class Manager : IEnumerable<Concert>
    {
        Dictionary<int, Concert> concerts = new Dictionary<int, Concert>();

        public void AddConcert(Concert concert)
        {
            if (!concerts.ContainsKey(concert.GetConcertID()))
            {
                concerts.Add(concert.GetConcertID(), concert);
                Console.WriteLine("Концерт был успешно добавлен!");
            }
            else
            {
                Console.WriteLine("Концерт под данным номером уже находится в коллекции");
            }
        }

        public void RemoveConcert(int concertID)
        {
            if (concerts.ContainsKey(concertID))
            {
                concerts.Remove(concertID);
                Console.WriteLine("Концерт успешно удален из коллекции");
            }
            else
            {
                Console.WriteLine("Данный концерт уже удален, либо не находится в коллекции");
            }
        }

        public string SearchConcert(int ConcertID)
        {
            concerts.TryGetValue(ConcertID, out Concert concert);
            return concert.ToString();
        }

        public void PrintAllConcerts()
        {
            Console.WriteLine("Список концертов: ");
            foreach (var item in concerts)
            {
                Console.WriteLine($"Номер концерта: {item.Key}\n {item.Value.ToString()}");
            }
        }

        public IEnumerator<Concert> GetEnumerator()
        {
            return concerts.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
