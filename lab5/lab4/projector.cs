using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Projector : Technique, Ipowerable
    {
        static int count_proj = 0;
        private int maxBrightness;


        public Projector(int price = -1, string name = "(", int brightness = 0)
        {
            set_price(price);
            this.name = name;
            set_tech(4);
            count_proj++;
            this.maxBrightness = brightness;
        }

        public void TurnOff()
        {
            Console.WriteLine("Прожектор выключен");
        }
        public void TurnOn()
        {
            Console.WriteLine("Прожектор включен");
        }

        public override void ShowFeatures()
        {
            Console.WriteLine($"Проектор: {this.name}, Максимальная яркость: {maxBrightness}");
        }

        public override string ToString()
        {
            return base.ToString() + $"Проектор: {this.name}, Максимальная яркость: {maxBrightness}";
        }



        public string return_name_projector()
        {
            return this.name;
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
