using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Пример использования класса XXXLog
            SKSLog log = new SKSLog("SKSlogfile.txt");

            // Логирование действий пользователя
            log.LogAction("Создание файла", "D:\\project\\file.txt");
            log.LogAction("Удаление файла", "D:\\project\\file.txt");

            // Чтение лог-файла
            Console.WriteLine("Содержимое лог-файла:");
            log.ReadLog();

            // Поиск в лог-файле
            Console.WriteLine("Результаты поиска по 'Создание':");


            SKSDiskInfo.DiskInfo("D:\\", log);

            SKSFileInfo.infoFile(@"D:\labs\putty.exe", log);


            SKSDirInfo.DirInfo("D:\\labs", log);


            SKSFileManager.SKSInspect("D:\\", log);

            SKSFileManager.CopyFiles(@"D:\\labs", ".exe", log);

            SKSFileManager.Archive(@"D:\labs\oop\lab12\SKSInspect", log);
            Console.Clear();
            DateTime date = new DateTime(2024, 12, 2, 23,0,0);
            DateTime date2 = new DateTime(2024, 12, 2, 23, 59, 0);
            SKSLog.SearchByDate(date);
            Console.ReadLine();
            Console.Clear();
            SKSLog.SearchByDateRange(date, date2);
            Console.ReadLine();
            Console.Clear();
            log.SearchInLog("Создание");
            Console.ReadLine();
            Console.Clear();

            DateTime currentTime = DateTime.Now;
            DateTime TimeHours = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour - 1, currentTime.Minute, currentTime.Second);
            SKSLog.SearchByDateRange(TimeHours, currentTime);

            Console.ReadLine();
            Console.Clear();





        }
    }
}
