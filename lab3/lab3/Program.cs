using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab3
{
    public class MyString
    {

        private string symbols;

        public MyString(string arr)
        {
            symbols = arr;
        }

        public override string ToString()
        {
            return symbols;
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


        }


    }


    public static class StatisticOperation
    {
        public static int Sum(params MyString[] myStrings)
        {
            return myStrings.Sum(ms => ms.ToString().Length);
        }

        public static int DifferenceMaxMin(params MyString[] myStrings)
        {
            if (myStrings.Length == 0) return 0;
            int maxLength = myStrings.Max(ms => ms.ToString().Length);
            int minLength = myStrings.Min(ms => ms.ToString().Length);
            return maxLength - minLength;
        }

        public static int ElementCount(MyString myString)
        {
            return myString.ToString().Length;
        }

        public static int WordCount(this string str)
        {
            return Regex.Matches(str, @"\b\w+\b").Count;
        }

        public static MyString smile(this string a, int place)
        {
            var symb = new KeyValuePair<int, string>(place - 1, "♥");
            return new MyString(a.Substring(0, place - 1) + symb.Value + a.Substring(place));
        }

        public static int WordCount(this MyString myString) // МБ ЧУТЬЧУТЬ ПОМЕНЯТЬ
        {
            return Regex.Matches(myString.ToString(), @"\b\w+\b").Count;
        }
        public static MyString smile(this MyString a, int place)
        {
            var symb = new KeyValuePair<int, string>(place - 1, "♥");
            return new MyString(a.ToString().Substring(0, place - 1) + symb.Value + a.ToString().Substring(place));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование оператора -:");
            MyString original = new MyString("Hello World!");
            Console.WriteLine($"Оригинал: {original}");
            Console.WriteLine($"После удаления 5 элемента: {original - 5}");

            Console.WriteLine("\nТестирование операторов > и <:");
            MyString s1 = new MyString("Привет");
            Console.WriteLine($"'{s1}' > 'Привет': {s1 > "Привет"}");
            Console.WriteLine($"'{s1}' < 'Привет': {s1 < "Привет"}");

            Console.WriteLine("\nТестирование оператора +:");
            MyString s2 = new MyString("Hello");

            var pair = new KeyValuePair<int, string>(3, "W");
            Console.WriteLine($"{s2} + {pair}: {s2 + pair}");

            MyString.Production prod = new MyString.Production(1, "Завод");
            Console.WriteLine(prod.get_name_prod());

            Console.WriteLine($"Количество символов в {s1} + {s2}: {StatisticOperation.Sum(s1, s2)}");

            Console.WriteLine($"Разница между количеством символов '{s1}' и '{s2}': {StatisticOperation.DifferenceMaxMin(s1, s2)}");
            Console.WriteLine($"Количество элементов строки '{s1}': {StatisticOperation.ElementCount(s1)}");

            string s3 = "Привет как дела что делаешь";
            Console.WriteLine($"Количество слов в строке '{s3}': {StatisticOperation.WordCount(s3)}");

            Console.WriteLine($"\nКоличество слов в '{new MyString("This is a test sentence")}' : {StatisticOperation.WordCount(new MyString("This is a test sentence"))}"); // ДОБАВИТЬ ДЛЯ СТРОКИ

            Console.WriteLine($"\nТест смайилка: '{new MyString("Hello")}' -> {StatisticOperation.smile(new MyString("Hello"), 2)}");

            Console.ReadLine();
        }
    }
}
