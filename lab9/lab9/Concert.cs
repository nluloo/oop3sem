using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    internal class Concert
    {
        private static int count = 0;
        private int tickets = 0;
        private string name_concert;
        private int ConcertID;
        public int CompareTo(Concert concert)
        {
            if(this.tickets > concert.tickets)
            {
                return 1;
            }
            if (this.tickets < concert.tickets)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public Concert(string name, int tickets, int concertID)
        {
            this.name_concert = name;
            this.tickets = tickets;
            count++;
            ConcertID = concertID;
        }

        public int GetConcertID()
        {
            return ConcertID;
        }

        public override string ToString()
        {
            return $"Название концерта: {name_concert}, Билетов на продажу: {tickets}";
        }

        public string getName()
        {
            return this.name_concert;
        }
    }
}
