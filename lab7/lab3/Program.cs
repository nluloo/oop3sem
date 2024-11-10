using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab3
{

    internal class Program
    {
        static void Main(string[] args)
        {
            MyString s1 = new MyString("Привет");
            MyString s2 = new MyString("Hello");
            CollectionType<MyString> collection = new CollectionType<MyString>();

            collection.Add(s1);
            collection.Add(s2);

            Console.WriteLine("__________________________GETINFO_CLASS_________________________");
            collection.GetInfo();

            Console.ReadLine();
            Console.Clear();

            CollectionType<int> collectionINT = new CollectionType<int>();

            collectionINT.Add(1);
            collectionINT.Add(2);
            collectionINT.Remove(1);
            collectionINT.Remove(1);
            Console.WriteLine("__________________________GETINFO_________________________");
            collectionINT.GetInfo();

            Console.ReadLine();
            Console.Clear();
            

            Monitor monitor = new Monitor(499, "DELL 321523", 144);
            Monitor monitor2 = new Monitor(1000, "HP", 240);
            Monitor monitor3 = new Monitor(700, "Lenovo", 144);


            CollectionType<Monitor>collectionTECH = new CollectionType<Monitor>();

            collectionTECH.Add(monitor);
            collectionTECH.Add(monitor2);
            collectionTECH.Add(monitor3);


            Console.WriteLine("__________________________GETINFO_________________________");
            collectionTECH.GetInfo();


            collectionTECH.SaveToFile("tech.json");

            CollectionType<Monitor> collectionCopy = new CollectionType<Monitor>();
            Console.WriteLine("__________________________GETINFO_COPY_________________________");
            collectionCopy.ReadFile("tech.json");
            collectionCopy.GetInfo();


            Console.ReadLine();
        }
    }
}
