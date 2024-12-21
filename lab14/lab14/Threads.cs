using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab14
{
    internal static class Threads
    {

        private static bool isPaused = false;
        private static object pauseLock = new object(); 
        public static void CalculN()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Thread curr = Thread.CurrentThread;
            using (StreamWriter sw = new StreamWriter("..\\calcul.txt"))
            {

                for (int i = 1; i <= n; i++)
                {

                    lock (pauseLock)
                    {
                        while (isPaused)
                        {
                            Monitor.Wait(pauseLock); // Приостановка потока
                        }
                    }

                    if (current(i))
                    {
                        sw.WriteLine(i);
                        Console.WriteLine(i);

                        Thread.Sleep(0);
                        PauseThread();
                        PrintThreadInfo(curr);
                        Thread.Sleep(5000);
                        ResumeThread();
                    }


                    PrintThreadInfo(curr);

                    Thread.Sleep(100);
                }
            }

        }

        public static void PauseThread()
        {
            lock (pauseLock)
            {
                isPaused = true;
                Console.WriteLine("Поток приостановлен.");
            }
        }

        public static void ResumeThread()
        {
            lock (pauseLock)
            {
                isPaused = false;
                Monitor.PulseAll(pauseLock); 
                Console.WriteLine("Поток возобновлён.");
            }
        }

        private static bool current(int number)
        {
            if(number <= 1)
            {
                return false;
            }
            for(int i = 2; i <= Math.Sqrt(number); i++)
            { 
                if(number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintThreadInfo(Thread curr)
        {
            Console.WriteLine($"Информация о потоке:");
            Console.WriteLine($"Имя: {curr.Name}");
            Console.WriteLine($"Статус: {(curr.IsAlive ? "Работает" : "Неактивен")}");
            Console.WriteLine($"Приоритет: {curr.Priority}");
            Console.WriteLine($"Идентификатор потока: {curr.ManagedThreadId}");
        }
    }
}
