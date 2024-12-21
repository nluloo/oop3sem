using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Drawing;
using System.Linq.Expressions;
using System.Collections.Concurrent;

namespace lab15
{


    internal class Program
    {
    static void reshetoEro(int n)
        {
            if (n < 2) return;
            bool[] numbTrue = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                numbTrue[i] = true;
            }

            for(int p = 2; p*p <= n; p++)
            {
                if (numbTrue[p])
                {
                    for(int i = p*p;i <= n; i += p)
                    {
                        numbTrue[i] = false;
                    }
                }
            }
            Console.WriteLine($"Простые числа до {n}:\n");
            for(int i = 0; i < n; i++)
            {
                if (numbTrue[i]) Console.WriteLine($"{i}");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            CancellationTokenSource token = new CancellationTokenSource();

            const int n = 1000;

            Task task = new Task(() => reshetoEro(n));
            Task task2 = new Task(() => reshetoEro(n), token.Token);
            sw.Start();
            task.Start();
            task.Wait();
            sw.Stop();
            Console.WriteLine(task.Status);
            Console.WriteLine($"ID: {task.Id}");
            Console.WriteLine(task.IsCompleted ? true : false);
            Console.WriteLine(sw.ElapsedTicks);

            sw.Restart();
            task2.Start();
            Thread.Sleep(1000);
            token.Cancel();
            Console.WriteLine("Остановлена задача с помощью токена");
            Console.WriteLine($"Время выполнения с токеном: {sw.ElapsedMilliseconds}");


            int a = new Random().Next(0, 10);
            int b = new Random().Next(0, 10);

            Console.WriteLine("---------------Task 3 -----------------");
            Console.WriteLine($"a = {a} | b = {b}");
            Task<int> sumTaskThree = new Task<int>(() => { return a + b; });
            Task<int> RTaskThree = new Task<int>(() => { return a - b; });
            Task<int> multiTaskThree = new Task<int>(() => { return a * b; });

            sumTaskThree.Start();
            RTaskThree.Start();
            multiTaskThree.Start();

            sumTaskThree.Wait();
            RTaskThree.Wait();
            multiTaskThree.Wait();

            Task<int> Formul = new Task<int>(() => { return sumTaskThree.Result + multiTaskThree.Result + RTaskThree.Result; });
            Formul.Start();
            Formul.Wait();
            Console.WriteLine($"Результат вычислений: {Formul.Result}");

            Console.WriteLine("\n---------------Task 4 -----------------\n");

            Task<int> task4_1 = new Task<int>(() => {
                int randNum = new Random().Next(1, 10);
                Console.WriteLine($"Сгенерированное число: {randNum}");
                return randNum;});
            Task<int> task4_2 = task4_1.ContinueWith(t =>
            {
                int randNum = new Random().Next(1, 10);
                if (t.Result <= 5)
                {
                    Console.WriteLine($"ВЫражение: {randNum} * t = {t.Result * randNum}");
                    return t.Result * randNum;
                }
                else
                {
                    Console.WriteLine($"Сгенерированное число: {randNum}");
                    return randNum;
                }
            });
            Task<int> task4_3 = task4_2.ContinueWith(t => {
                Console.WriteLine($"t.Result * 2: {t.Result * 2}");
                return t.Result * 2; });


            task4_1.Start();

            task4_3.Wait();


            int SumFirstTaskAndSecondTask = task4_1.GetAwaiter().GetResult() + task4_2.GetAwaiter().GetResult();
            Console.WriteLine($"Результат через getAwaiter: {SumFirstTaskAndSecondTask}");


            Console.WriteLine("\n---------------Task 5 -----------------\n");

            var arr1 = new int[10000000];
            var arr2 = new int[10000000];
            var arr3 = new int[10000000];
            sw.Restart();


            Parallel.For(0, 10000000, (i) =>
            {
                arr1[i] = 200;
                arr2[i] = 400;
                arr3[i] = 600;
            });
            sw.Stop();

            Console.WriteLine($"Параллельный цикл: {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                arr1[i] = 100;
                arr2[i] = 200;
                arr3[i] = 300;
            }
            sw.Stop();

            Console.WriteLine($"Обычный цикл: {sw.ElapsedMilliseconds} мс");

            string[] text = Enumerable.Repeat("Удаление обработка замена ", 1000000).ToArray();

            sw.Restart();

            foreach(var t in text)
            {
                string temp =  t.Replace("Удаление", "").Replace("замена", "Супер");
            }
            sw.Stop();

            Console.WriteLine($"Время выполнения обычного foreach: {sw.ElapsedMilliseconds}");

            sw.Restart();

            Parallel.ForEach(text, t =>
            {
                string temp = t.Replace("Удаление", "").Replace("замена", "Супер");
            });
            sw.Stop();

            Console.WriteLine($"Параллельный foreach: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\n---------------Task 6 -----------------\n");

            Action task6 = () =>
            {
                int sum = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    sum += i;
                }
                Console.WriteLine($"Сумма элементов до 1000000 = {sum}");
            };
            Action task6_2 = () =>
            {
                int sum = 1;
                for (int i = 1; i < 20; i++)
                {
                    sum *= i;
                }
                Console.WriteLine($"20! = {sum}");
            };

            Action task6_3 = () =>
            {
                int[] arrPow = new int[1000];
                for (int i = 0; i < 1000; i++)
                {
                    arrPow[i] = i * i;
                }
                Console.WriteLine($"Массив создан!");
            };


            Parallel.Invoke(task6, task6_2, task6_3);


            Console.WriteLine("\n---------------Task 7 -----------------\n");

           Warehouse war = new Warehouse();

            war.Start();

            Console.ReadLine();


            Console.WriteLine("\n---------------Task 8 -----------------\n");



            Async.StartAsync();
        }


    }
}