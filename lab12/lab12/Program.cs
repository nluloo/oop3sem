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
            
            SKSLog log = new SKSLog("SKSlogfile.txt");

            
            log.LogAction("Создание файла", "D:\\project\\file.txt");
            log.LogAction("Удаление файла", "D:\\project\\file.txt");

            
            Console.WriteLine("Содержимое лог-файла:");
            log.ReadLog();
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Результаты поиска по 'Создание':");
            log.SearchInLog("Создание");

            //2 Задание
            SKSDiskInfo.DiskInfo("D:\\", log);

            SKSFileInfo.infoFile(@"D:\labs\putty.exe", log);


            SKSDirInfo.DirInfo("D:\\labs", log);

            //3 Задание
            SKSFileManager.SKSInspect("D:\\", log);

            SKSFileManager.CopyFiles(@"D:\\labs", ".exe", log);

            var path = Path.Combine("D:\\", "labs", "oop", "lab12", "SKSInspect");

            SKSFileManager.Archive(path, log);
            Console.ReadLine() ;
            Console.Clear();
            DateTime date = new DateTime(2024, 12, 2, 23,0,0);
            DateTime date2 = new DateTime(2024, 12, 2, 23, 59, 0);
            SKSLog.SearchByDate(date);
            Console.ReadLine();
            Console.Clear();
            SKSLog.SearchByDateRange(date, date2);
            Console.ReadLine();
            Console.Clear();

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
