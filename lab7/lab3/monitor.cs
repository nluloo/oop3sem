using lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Monitor : Technique, Ipowerable
    {
        public float disp;
        static int count_monitor = 0;

        public Monitor()
        {
            set_tech(1);
            count_monitor++;
        }

        public Monitor(int price = -1, string name = "(", float disp = 0)
        {
            set_price(price);
            this.name = name;
            set_tech(1);
            count_monitor++;
            this.disp = disp;
        }

        public string name_mon()
        {
            return this.name;
        }

        public void TurnOff()
        {
            Console.WriteLine("Монитор выключен");
        }
        public void TurnOn()
        {
            Console.WriteLine("Монитор включен");
        }

        public override void ShowFeatures()
        {
            Console.WriteLine($"Монитор: {this.name}, Частота обновления экрана: {disp} Гц");
        }

        public override string ToString()
        {
            return base.ToString() + $"Монитор: {this.name}, Частота обновления экрана: {disp} Гц";
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
