using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class ProductExeception : Exception
    {
        public ProductExeception(string message) : base(message) { }
    }

    public class OutOfRangeProducts : ArgumentOutOfRangeException
    {
        public int value;
        public OutOfRangeProducts(string message, int value) : base(message) {

            this.value = value;
        }
    }

    public class TechOrFurnException : ArgumentException
    {
        public string value;
        public TechOrFurnException(string message, string value) : base(message)
        {
            this.value = value;
        }
    }

    public class NegativePriceException : ArgumentOutOfRangeException
    {
        public double InvalidPrice { get; }

        public NegativePriceException(string message, double price)
    : base(message)
        {
            InvalidPrice = price;
        }
    }

    public class NullReferenceException : Exception
    {
        public NullReferenceException(string message) : base(message) { }
    }

}
