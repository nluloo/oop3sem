using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Printer
    {
        public void IAmPrinting(Product someobj)
        {
            Console.WriteLine(someobj.ToString());
        }
    }
}
