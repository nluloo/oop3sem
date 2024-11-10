using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Monitor : Technique, Ipowerable
    {
        private float disp;
        static int count_monitor = 0;

        public Monitor()
        {
            set_tech(1);
            count_monitor++;
        }

        public Monitor(int id_tech, int price = -1, string name = "(", float disp = 0)
        {

            if(name == null)
            {
                throw new NullReferenceException("Укажите название товара.");
            }
            if (id_tech != 1)
            {
                throw new OutOfRangeProducts("Для Монитора ID должен быть равен 1", id_tech);
            }
            else
            {
                set_tech(id_tech);
            }
            if (price < -1)
            {
                throw new NegativePriceException("Цена товара должна быть больше 0.", price);
            }
            else
            {
                set_price(price);
            }
            this.name = name;


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
