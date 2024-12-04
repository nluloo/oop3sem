using lab13;
using System;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product pc = new PC(700, "Gaming PC", 16000);
           

            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("pc.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, pc);
            }


            using(FileStream fs = new FileStream("pc.dat", FileMode.OpenOrCreate))
            {
                Product newPC = (Product)bf.Deserialize(fs);
                Console.WriteLine(newPC.ToString());
            }



            
        }
    }
}
