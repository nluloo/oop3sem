using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace lab11
{

    public class Hello : IEnumerable<string>
    {
        public int primerParam= 1;
        private int primerPrivate;

        public Hello()
        {
            Console.WriteLine("1");
        }


        public void Hello1(string s, string s1)
        {
            Console.WriteLine(s);
            Console.WriteLine(s1);
        }

        private Hello(string s, object a)
        {
            Console.WriteLine("1");
        }
        public Hello(string s)
        {
            Console.WriteLine(s);
        }
        public void hello()
        {
            Console.WriteLine("Hello");
        }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    static class Reflector
    {
        public static StreamWriter sw = new StreamWriter("info.txt");

        static Type type;
        static public void GetNameAssembly(string nameClass)
        {
            type = Type.GetType(nameClass, true, true);
            string buff = "";
            buff += "Задание 1: ";
            buff += type?.Assembly.FullName;
            sw.WriteLine(buff);
        }

        static public void GetPublicConstructor(string nameClass)
        {
            type = Type.GetType (nameClass, true, true);
            int check = 0;
            foreach(ConstructorInfo member in type.GetConstructors(BindingFlags.Public | BindingFlags.Instance)){
                if(member.Name == ".ctor")
                {
                    check++;
                }
            }
            string buff = "";
            buff += "Задание 2: ";
            buff += $"Количество объявленных публичных конструкторов: {check}";
            sw.WriteLine(buff);
        }

        static public IEnumerable<string> GetPublicMethods(string nameClass)
        {
            type = Type.GetType(nameClass, true, true);
            List<string> methods = new List<string>();

            foreach (var item in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                methods.Add(item.Name);
            }
            string buff = "";
            buff += "Задание 3: Все объявленные публичные методы\n";
            int i = 0;
            foreach (var item in methods)
            {

                buff += $"{++i}. ";
                buff += item;
                buff += '\n';
            }

            sw.WriteLine(buff);
            return methods;
        }


        static public IEnumerable<string> GetInfo(string nameClass)
        {
            type = Type.GetType(nameClass, true, true);
            List<string> info = new List<string>();

            foreach (FieldInfo item in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                info.Add(item.Name);
            }

            string buff = "";
            buff += "Задание 4: Все поля данного класса\n";
            int i = 0;
            foreach (var item in info)
            {

                buff += $"{++i}. ";
                buff += item;
                buff += '\n';
            }

            sw.WriteLine(buff);

            return info;
        }

        static public IEnumerable<string> GetInterfaceClass(string nameClass)
        {
            type = Type.GetType(nameClass, true, true);
            List<string> interf = new List<string>();

            foreach (var item in type.GetInterfaces())
            {
                interf.Add(item.Name);
            }

            string buff = "";
            buff += "Задание 5: Все интерфейсы\n";
            int i = 0;
            foreach (var item in interf)
            {

                buff += $"{++i}. ";
                buff += item;
                buff += '\n';
            }

            sw.WriteLine(buff);

            return interf;
        }



        static public void GetMethodsParametrs(string nameClass, Type typeName)
        {
            type = Type.GetType(nameClass, true, true);
            string buff = "";
            buff += "Задание 6: Имена методов с данным типом в параметрах\n";
            int j = 0;

            foreach (MethodInfo method in type.GetMethods())
            {
                ParameterInfo[] parametrs = method.GetParameters();
                
                for(int i = 0; i < parametrs.Length; i++)
                {
                    var param = parametrs[i];

                    if(param.ParameterType == typeName)
                    {
                        buff += $"{++i}. ";
                        buff += method.Name;
                        buff += "\n";
                    }
                }
            }
            sw.WriteLine(buff);

        }


        static public void Invoke(object obj, string file)
        {
            string[] lines = File.ReadAllLines(file);

            Type type = Type.GetType(lines[0]);

            MethodInfo method = type.GetMethod(lines[1]);

            if(lines.Length < 3)
            {
                string[] param = new string[2];
                param[0] = "GenerateValue1";
                param[1] = "GenerateValue2";
                method.Invoke(obj, param);
            }
            else
            {
                string[] param = new string[lines.Length - 2];
                param[0] = lines[2];
                param[1] = lines[3];
                method.Invoke(obj, param);
            }
        }


        static public T Create<T>() where T : class
        {

            ConstructorInfo constructor = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault();

            if(constructor == null)
            {
                throw (new Exception("Нет публичного конструктора"));
            }
            else
            {
                return (T)constructor.Invoke(null);
            }


        } 
    }
}
