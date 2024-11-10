using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace lab8
{

     internal class Program
    {
        static void Main(string[] args)
        {
            Programmer lang1 = new Programmer("JavaScript", "ES6");
            Programmer lang2 = new Programmer("Python", "3.9");

            lang1.Prop += message => Console.WriteLine($"Lang1: {message}");

            lang2.Lang += message => Console.WriteLine($"Lang2: {message}");
            lang2.Prop += message => Console.WriteLine($"Lang2: {message}");

            lang1.ChangeLanguage("TypeScript");
            lang1.ChangeLanguage("JS");
            lang1.AddProp("Static Typing");

            lang2.ChangeVersion("3.10");
            lang2.AddProp("Pattern");

            string DoOperation(string str, Func<string, string> fun) => fun(str);
            string DelSymb(string str) => Regex.Replace(str, "\\p{P}", string.Empty);

            void DoReg(string str, Action<string> fun) => fun(str);
            void UpReg(string str) => Console.WriteLine($"Строка в верхнем регистре: {str.ToUpper()}");
            void DelSpace(string str) => Console.WriteLine($"Строка без пробелов: {str.Replace(" ", "")}");

            Func<int, string,  string, string> myFunc = new Func<int, string,string, string>(AddSymb);
            string AddSymb(int n, string ch, string str) => str.Insert(n, ch);

            Predicate<string> isNull = (str) => str == null;

            string s = DoOperation("Hello, World!", DelSymb);

            Console.WriteLine(s);

            DoReg(s, UpReg);
            DoReg(s, DelSpace);

            Console.WriteLine(AddSymb(4, "ПРИВЕТ", s));

            s = null;
            if ( isNull(s) )
            {
                Console.WriteLine("Строка пустая");
            }



            Console.ReadLine();
        }
    }
}
