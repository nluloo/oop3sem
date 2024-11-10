using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class MyString
    {

        private string symbols;
        private Production production;

        public MyString(string arr)
        {
            symbols = arr;
            this.production = new Production(101, "GameStream");
        }

        public override string ToString()
        {
            return symbols;
        }

        public string GetProductionInfo()
        {
            return $"ID: {production.get_id_prod()}, Название организации: {production.get_name_prod()}";
        }


        public static MyString operator -(MyString a, int place)
        {
            int size = a.symbols.Length - 1;
            int buff = place - 1;
            string result = a.symbols.Substring(0, buff);
            string result2 = a.symbols.Substring(buff + 1);

            return new MyString(result + result2);
        }

        public static bool operator >(MyString a, string str)
        {
            return a.symbols.IndexOf(str) != -1;
        }
        public static bool operator !=(MyString a, string str)
        {
            return a.symbols != str;
        }
        public static bool operator ==(MyString a, string str)
        {
            return a.symbols == str;
        }


        public static bool operator <(MyString a, string str)
        {
            return a.symbols.IndexOf(str) == -1;
        }

        public static MyString operator +(MyString a, KeyValuePair<int, string> AddSymb)
        {
            int buff = AddSymb.Key;
            buff--;
            return new MyString(a.symbols.Substring(0, buff) + AddSymb.Value + a.symbols.Substring(buff));
        }




        public class Developer
        {
            private int ID;
            private string name_dev;
            private string department;

            public Developer(string name, int ID, string dep)
            {
                this.ID = ID;
                this.name_dev = name;
                this.department = dep;
            }

            public int get_id_dev()
            {
                return this.ID;
            }
            public string get_name_dev()
            {
                return this.name_dev;
            }
            public string get_name_dep()
            {
                return this.department;
            }
            public override string ToString()
            {
                return $"ID: {ID}, Name: {name_dev}, Department: {department}";
            }
        }


    }
}
