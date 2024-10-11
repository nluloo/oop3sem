using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Headphones : Technique, Ipowerable
    {
        static int count_head = 0;
        private string type_head;

        public Headphones(int price = -1, string name = "(", string type_head = null)
        {
            set_price(price);
            this.name = name;
            set_tech(3);
            count_head++;
            this.type_head = type_head;
        }

        public void TurnOn()
        {
            Console.WriteLine("Наушники включены");
        }
        public void TurnOff()
        {
            Console.WriteLine("Наушники выключены");
        }

        public override void ShowFeatures()
        {
            Console.WriteLine($"Наушники: {name}, Тип наушников: {type_head}");
        }

        public override string ToString()
        {
            return base.ToString() + $"Наушники: {name}, Тип наушников: {type_head}";
        }

        public string name_headphones()
        {
            return name;
        }

        public override void Show()
        {
            Console.WriteLine($"Абстрактный метод вывел данное устройство: {name_tech} ");
        }

        void Ipowerable.Show()
        {
            Console.WriteLine($"Интерфейс вывел данное устройство: {name_tech} ");
        }
    }
}
