﻿using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //ex1_1();

            //ex1_2();

            //ex1_3();

            //ex1_5();

            //ex2_1();

            //ex2_3();

            //ex2_4();

            //ex3_1();

            //ex3_2();

            //ex3_3();

            //ex4_1();

            (int max, int min, int sum, char firstChar) funcArr(int[] arr, string hi)
            {
               int max = arr.Max();
               int min = arr.Min();
                char c = hi[0];

                int sum = 0;
                foreach(int number in arr)
                {
                    sum += number;
                }
                (int max, int min, int sum, char firstChar) myTurple = (max, min, sum, c);

                return myTurple;
            };

            int[] arr = { 1, 2, 3, 4 ,5,6,7,8,9};
            string hi = "Hello";

            (int max, int min, int sum, char firstChar) myTurple = funcArr(arr, hi);

            Console.WriteLine(myTurple);


            void func1()
            {
                checked
                {
                    int imax = int.MaxValue;
                    Console.WriteLine(imax);
                }
            }
            void func2()
            {
                unchecked
                {
                    int jmax = int.MaxValue;
                    Console.WriteLine(jmax);
                    jmax++;
                    Console.WriteLine(jmax);
                }

            }
            func1();
            func2();
        }
        static void ex1_1()
        {
            int InParam = 1;
            Console.WriteLine($"int: {InParam}");
            InParam = int.Parse(Console.ReadLine());
            Console.WriteLine($" write int: {InParam}");

            char ArParam = 'a';
            Console.WriteLine($"char: {ArParam}");
            ArParam = Convert.ToChar(Console.ReadLine());
            Console.WriteLine($" writechar: {ArParam}");

            short SParam = 2;
            Console.WriteLine($"short: {SParam}");
            SParam = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"write short: {SParam}");

            double dParam = 3.2;
            Console.WriteLine($"double: {dParam}");
            dParam = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"write double: {dParam}");

            float fParam = 1.7f;
            Console.WriteLine($"float: {fParam}");
            fParam = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine($"write: {fParam}");

            bool pParam = true;
            Console.WriteLine($"string: {pParam}");
            pParam = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine($"write boolean: {pParam}");

            string str = "Hello, World!";
            Console.WriteLine($"string: {str}");
            str = Console.ReadLine();
            Console.WriteLine($"write string: {str}");

            byte byteV = 200;
            Console.WriteLine($"byte: {byteV}");
            byteV = Convert.ToByte(Console.ReadLine());
            Console.WriteLine($"write byte: {byteV}");

            sbyte sbyteV = -128;
            Console.WriteLine($"sbyte: {sbyteV}");
            sbyteV = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine($" write sbyte: {sbyteV}");

            ushort ushortV = 60000;
            Console.WriteLine($"ushort: {ushortV}");
            ushortV = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine($"write ushort: {ushortV}");

            long longV = 3942872934769L;
            Console.WriteLine($"long: {longV}");
            longV = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($" write long: {longV}");

            ulong ulongV = 0823598123598172UL;
            Console.WriteLine(ulongV);
            ulongV = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine($" write ulong: {ulongV}");
        }
        static void ex1_2()
        {
            Console.WriteLine("---- Явные преобразования ----");
            double d = 4.21;
            int PreobrInt = (int)d;
            Console.WriteLine($"double -> int: {PreobrInt}");

            int number = 300;
            byte b = (byte)number;
            Console.WriteLine($"int -> byte: {b}");

            char cParam = 'F';
            int c = Convert.ToInt32(cParam);
            Console.WriteLine($"char -> int: {c}");

            int sParam = 928375812;
            short s = (short)sParam;
            Console.WriteLine($"int -> short: {s}");

            ushort us = (ushort)s;
            Console.WriteLine($"short -> ushort: {us}");

            Console.WriteLine("---- Неявные преобразования ----");

            int nd = 4;
            double id = nd;
            Console.WriteLine($"int -> float: {id}");
;
            int cc = cParam;
            Console.WriteLine($"char -> int: {cc}");

            float pi = 3.14f;
            double Pi = pi;
            Console.WriteLine($"float -> double: {Pi}");

            byte sByte = 255;
            int si = sByte;
            Console.WriteLine($"byte -> int: {si}");

            short ss = 32000;
            long sl = ss;
            Console.WriteLine($"short -> long: {sl}");
        }
        static void ex1_3()
        {
            int i = 1;
            object o = i;
            int j = (int)o;
            Console.WriteLine(o);
            Console.WriteLine(j);

            float b = 4.3f;
            string str = "Привет ";
            string result = str + b;
            Console.WriteLine(result);

        }
        static void ex1_4()
        {
            var i = 5; // int
            var c = 'C'; //char
            var f = 12.35f; //float
            var str = "Hello, World!"; //string
            var numbers = new[] { 1, 2, 3, 4, 5 }; // array
            var person = new { Name = "Кирилл", Age = 18 }; // class
        }

        static void ex1_5()
        {
            int? i = null;
            IsNull(i);
            i = 100;
            IsNull(i);

            void IsNull(int? o)
            {
                if (o == null)
                {
                    Console.WriteLine("null");
                }
                else
                {
                    Console.WriteLine(o);
                }
            }
        }

        static void ex1_6()
        {
            var i = 2;
            //i = "Привет";
        }

        static void ex2_1()
        {
            char c = 'C', b = 'B';

            Console.WriteLine(c != b);

            string hello = "Привет ";
            string world = "Мир";
            string all = "Привет Мир хелло";
            string name = " Кирилл";

            Console.WriteLine(hello + world + all);

            string coppyHello = string.Copy(hello);
            Console.WriteLine(coppyHello + 1);
            Console.WriteLine(hello.Substring(4));
            string[] words = all.Split(' ');

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            string newStr = all.Insert(6, name);
            Console.WriteLine(newStr);

            Console.WriteLine(newStr.Remove(6, 7));

            double pi = 3.14;

            string formattedPi = $"Пи = {pi}";
            Console.WriteLine(formattedPi);


        }

        static void ex2_3()
        {
            string str = "";

            string nullStr = null;

            Console.WriteLine(string.IsNullOrEmpty(str));
            Console.WriteLine(string.IsNullOrEmpty(nullStr));
        }

        static void ex2_4()
        {
            StringBuilder sb = new StringBuilder("Привет мир");
            Console.WriteLine(sb.ToString());

            sb.Remove(7, 3);
            Console.WriteLine(sb.ToString());

            sb.Insert(0, "Хай: ");
            sb.Append("Кирилл");
            Console.WriteLine(sb.ToString());
        }

        static void ex3_1()
        {
            int[][] matrix = { new[] {1, 2, 3}, new[] {4, 5, 6}, new[] { 7, 8, 9 }};

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        static void ex3_2()
        {
            string[] hi = { "Привет", "Хело", "Хай", "Вассап" };

            foreach(var word in hi)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine($"Длинна массива: {hi.Length}");

            Console.Write("Введите место нового слова: ");
            int position = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите новое слово: ");
            string newValue = Console.ReadLine();

            hi[position] = newValue;

            foreach (var word in hi)
            {
                Console.WriteLine(word);
            }
        }

        static void ex3_3()
        {
            double[][] zmass = new double[3][];

            zmass[0] = new double[2];
            zmass[1] = new double[3];
            zmass[2] = new double[4];

            Console.WriteLine("Введите значения для первой строки (2):");
            zmass[0][0] = double.Parse(Console.ReadLine());
            zmass[0][1] = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите значения для второй строки (3):");
            zmass[1][0] = double.Parse(Console.ReadLine());
            zmass[1][1] = double.Parse(Console.ReadLine());
            zmass[1][2] = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите значения для третьей строки (4):");
            zmass[2][0] = double.Parse(Console.ReadLine());
            zmass[2][1] = double.Parse(Console.ReadLine());
            zmass[2][2] = double.Parse(Console.ReadLine());
            zmass[2][3] = double.Parse(Console.ReadLine());

            foreach (var row in zmass)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            var arrH = zmass;

            Console.WriteLine("-----------------");
            foreach (var row in arrH)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            var arrS = "Привет";
        }

        static void ex4_1()
        {
            var myTuple = (25, "Пример", 'A', "строка", 123456789UL);

            Console.WriteLine(myTuple);

            Console.WriteLine(myTuple.Item1);
            Console.WriteLine(myTuple.Item2);
            Console.WriteLine(myTuple.Item3);
            Console.WriteLine(myTuple.Item4);
            Console.WriteLine(myTuple.Item5);

            (int number, string text1, char symbol, string text2, ulong largeNumber) = myTuple;

            Console.WriteLine($"number: {number}");
            Console.WriteLine($"text1: {text1}");
            Console.WriteLine($"symbol: {symbol}");
            Console.WriteLine($"text2: {text2}");
            Console.WriteLine($"largeNumber: {largeNumber}");

            (int num, _, char symb, _, ulong largeNum) = myTuple;

            // Вывод только тех переменных, которые распаковали
            Console.WriteLine($"number: {num}");
            Console.WriteLine($"symbol: {symb}");
            Console.WriteLine($"largeNumber: {largeNum}");

            var myTuple2 = (10, "Привет", 'Б', "строка", 123456789UL);

            bool res = (myTuple == myTuple2) ? true : false;

            Console.WriteLine(res);

        }
    }
}