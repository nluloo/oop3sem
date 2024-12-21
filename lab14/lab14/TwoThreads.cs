using System;
using System.IO;
using System.Threading;

namespace lab14
{
    internal class TwoThreads
    {
        private static Semaphore semaphoreEven = new Semaphore(1, 1);  // Четные числа начинаем с доступом
        private static Semaphore semaphoreOdd = new Semaphore(0, 1);   // Нечетные числа блокированы

        private static object fileLock = new object();
        private static  bool  mark = false;

        public static void RunThreads(StreamWriter writer)
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());

            
            Thread evenThread = new Thread(() => PrintEvenNumbers(n, writer));
            Thread oddThread = new Thread(() => PrintOddNumbers(n, writer));

            
            evenThread.Priority = ThreadPriority.Highest;
            oddThread.Priority = ThreadPriority.Lowest;

            evenThread.Start(); 
            oddThread.Start();


           
            oddThread.Join();  
            Thread.Sleep(1000);
            evenThread.Join(); 


        }

        private static void PrintEvenNumbers(int n, StreamWriter writer)
        {
            if (n % 2 == 1)
            {
                n++;
            }
            for (int i = 2; i <= n; i++)
            {
                if(i % 2 == 0)
                {
                    semaphoreEven.WaitOne(); 
                    lock (fileLock)
                    {
                        writer.WriteLine(i); 
                    }
                    lock (Console.Out)
                    {
                        Console.WriteLine(i);
                    }
                    semaphoreOdd.Release();
                }
                
            }

        }

        private static void PrintOddNumbers(int n, StreamWriter writer)
        {
            if(n % 2 == 1)
            {
                n++;
            }
            for (int i = 1; i <= n; i ++)
            {
                if (i % 2 == 1)
                {
                    semaphoreOdd.WaitOne(); 
                    lock (fileLock)
                    {
                        writer.WriteLine(i);
                    }
                    lock (Console.Out)
                    {
                        Console.WriteLine(i);
                    }
                    semaphoreEven.Release(); 

                }
            }
        }
    }
}
