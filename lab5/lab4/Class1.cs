using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{

    public abstract partial class Product
    {
        public void set_price(int price)
        {
            this.price = price;
        }

        public override string ToString()
        {
            return $"Тип устройства: {this.GetType().Name}, Цена: {this.price} ";
        }

        public abstract void Set_Defect();
    }
}
