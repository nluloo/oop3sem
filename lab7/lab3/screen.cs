using lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab3
{
    public class Screen : Technique, Ipowerable
    {
        static int count_screen = 0;
        private string resolution;

        public Screen(int price = -1, string name = "(", string type_head = null)
        {
            set_price(price);
            this.name = name;
            set_tech(3);
            count_screen++;
            this.resolution = type_head;
        }

        public void TurnOn()
        {
            Console.WriteLine("Экран исправен");
        }
        public void TurnOff()
        {
            Console.WriteLine("Экран неисправен");
        }

        public override void ShowFeatures()
        {
            Console.WriteLine($"Экран: {this.name}, Разрешение: {resolution}");
        }

        public override string ToString()
        {
            return base.ToString() + $"Экран: {name}, Разрешение:  {resolution}";
        }

        public string return_name_screen()
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
