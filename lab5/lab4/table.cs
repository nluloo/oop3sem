﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    sealed public class Table : Furniture
    {
        private int count_det;
        static int count_table = 0;

        public Table()
        {
            set_furn(1);
            count_table++;
        }

        public Table(int price = -1, string name = "(", int count_det = 0)
        {
            set_price(price);
            this.name = name;
            set_furn(1);
            count_table++;
            this.count_det = count_det;
        }

        public string return_name_table()
        {
            return name;
        }

        public override void ShowFeatures()
        {
            Console.WriteLine($"Стол: {name}, Количество деталей для сборки: {count_det}");
        }

        public override string ToString()
        {
            return base.ToString() + $"Стол: {name}, Количество деталей для сборки: {count_det}";
        }
        public override void Show()
        {
            Console.WriteLine($"Абстрактный метод вывел данное устройство: {name} ");
        }
    }
}