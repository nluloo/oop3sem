using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{


    internal class Program
    {
        static void Main(string[] args)
        {

            Hello helo = new Hello();
            string hi = "";

            string SpaceName = helo.GetType().Namespace + '.' + helo.GetType().Name;

            Reflector.GetNameAssembly(SpaceName);
            Reflector.GetPublicConstructor(SpaceName);
            IEnumerable<string> result = Reflector.GetPublicMethods(SpaceName);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            

            IEnumerable<string> result1 = Reflector.GetInfo(SpaceName);

            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }


            IEnumerable<string> result2 = Reflector.GetInterfaceClass(SpaceName);

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();    
            Reflector.GetMethodsParametrs(SpaceName, typeof(string));


            Reflector.Invoke(helo, "invoke.txt");




            Console.WriteLine("____________2 часть____________-");
            var helllo = Reflector.Create<Hello>();

            Console.WriteLine(helllo.GetType());







            Console.ReadLine();
            Console.Clear();


            string SpaceNameStr = hi.GetType().Namespace + '.' + hi.GetType().Name;

            Reflector.GetNameAssembly(SpaceNameStr);
            Reflector.GetPublicConstructor(SpaceNameStr);
            IEnumerable<string> resultHi = Reflector.GetPublicMethods(SpaceNameStr);

            foreach (var item in resultHi)
            {
                Console.WriteLine(item);
            }



            IEnumerable<string> result3 = Reflector.GetInfo(SpaceNameStr);

            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }


            IEnumerable<string> result5 = Reflector.GetInterfaceClass(SpaceName);

            foreach (var item in result5)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
            Console.Clear();
            Reflector.sw.Close();
        }
    }
}
