﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class PC : Technique, Ipowerable
    {
        private int ram_pc;
        static int count_pc = 0;

        public PC(int id_tech, int price = -1, string name = "(", int ram_pc = 0)
        {
            if (name == null)
            {
                throw new NullReferenceException("Укажите название товара.");
            }
            if (id_tech != 2)
            {
                throw new OutOfRangeProducts("Для ПК ID должен быть равен 2", id_tech);
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
            count_pc++;
            this.ram_pc = ram_pc;
        }

        public void TurnOff()
        {
            Console.WriteLine("ПК выключен");
        }
        public void TurnOn()
        {
            Console.WriteLine("ПК включен");
        }

        public string return_name_pc()
        {
            return this.name;
        }

        public override void ShowFeatures()
        {
            Console.WriteLine($"ПК: {name}, Оперативная память: {ram_pc} МБ");
        }

        public override string ToString()
        {
            return base.ToString() + $"ПК: {name}, Оперативная память: {ram_pc} МБ";
        }

        public override void Show()
        {
            Console.WriteLine($"Абстрактный метод вывел данное устройство: {name_tech} ");
        }

        void Ipowerable.Show()
        {
            Console.WriteLine($"Интерфейс вывел данное устройство: {name_tech} ");
        }

        public override bool Equals(object obj)
        {
            Console.WriteLine("\nВызван переопределенный метод сравнения");
            if (obj == null || GetType() != obj.GetType())
                return false;

            PC other = (PC)obj;
            return this.name == other.name && this.ram_pc == other.ram_pc;
        }

        public override int GetHashCode()
        {
            int hash = (name, ram_pc).GetHashCode();
            Console.WriteLine($"\nHash: {hash}");
            return hash;
        }
    }
}
