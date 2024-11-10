using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Production
    {
        private int ID;
        private string name;

        public Production(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
        }

        public int get_id_prod()
        {
            return this.ID;
        }
        public string get_name_prod()
        {
            return this.name;
        }
    }
}
