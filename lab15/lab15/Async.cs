using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    static internal class Async
    {
        public static async void StartAsync()
        {
            Console.WriteLine("Начало выполнения ассинхронного подсчета");

            int n = 10000;
            long fiboNum = await CalculFiboAsync(n);

            Console.WriteLine($"Число фиббоначи для {n}: {fiboNum}");
            Console.WriteLine("Завершение подсчета");
        } 

        static async Task<long> CalculFiboAsync(int n)
        {
            return await Task.Run(() => Fibo(n));
        }


        static long Fibo(int n)
        {
            if (n <= 1) return n;
            long a = 0;
            long b = 1;
            for(int i = 2; i <= n; i++)
            {
                long temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }


    }
}
