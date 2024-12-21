using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Data;



namespace lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Processes.WriteAllPricesses(); // 1 задание
            //Domain.DomainManipul(); // 2 задание

            /*Thread myThread = new Thread(Threads.CalculN); // 3 задание

            myThread.Start();

            Thread.Sleep(1000); // Время, через сколько выведется hello
            Console.WriteLine("Hello!!!!!!!!!!!!!!!!");*/

           /* using (StreamWriter writer = new StreamWriter("..\\odd.txt")) //4 задание
            {
                TwoThreads.RunThreads(writer);
            }*/
            


            /*Timer timer = new Timer(PrintTimeNewYear, null, 0, 1000); // 5 задание

            Console.WriteLine("Нажмите Enter, чтобы завершить программу...");
            Console.ReadLine();*/


            // ДОП


            Car car_01 = new Car(15, 1);
            Car car_02 = new Car(15, 2);
            Car car_03 = new Car(20, 3);

            Car[] cars = { car_01, car_02, car_03 };

            Store store = new Store("..\\store.txt", cars);

            Thread thread_01 = new Thread(store.UnloadStore);
            Thread thread_02 = new Thread(store.UnloadStore);
            Thread thread_03 = new Thread(store.UnloadStore);

            thread_03.Start(car_03); // Менять порядок машин чтобы была разная загрузка
            thread_01.Start(car_01);
            Thread.Sleep(1000);
            thread_02.Start(car_02);
            Thread.Sleep(1000);


            thread_01.Join();
            thread_02.Join();

            thread_03.Join();

            car_01.ShowItem();
            car_02.ShowItem();
            car_03.ShowItem();

            Console.WriteLine($"Всего товаров = {Car.CounterItem}");

        }
        static void PrintTimeNewYear(object obj)
        {
            DateTime newYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // Дата Нового года
            DateTime now = DateTime.Now; // Текущая дата и время

            TimeSpan timeRemaining = newYear - now; // Разница между Новым годом и текущим временем

            // Выводим оставшееся время
            Console.WriteLine("До Нового года осталось: ");
            Console.WriteLine($"{timeRemaining.Days} дней, {timeRemaining.Hours} часов, {timeRemaining.Minutes} минут, {timeRemaining.Seconds} секунд");
        }
    }
}