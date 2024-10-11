using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public abstract partial class Product
    {

        public int id_department;
        public string name_department;
        public int price;
        public string name;
        public bool defect = false;
        public void set_dep(int id_department, string name_department)
        {
            this.id_department = id_department;
            this.name_department = name_department;
        }

        public int return_id_department()
        {
            return id_department;
        }
        public string return_name_department()
        {
            return name_department;
        }
        public int ret_price()
        {
            return price;
        }

    }
}
