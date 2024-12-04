using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;



namespace lab12
{
    internal class SKSDirInfo
    {
        public static void DirInfo(string nameDir, SKSLog log)
        {
            if(Directory.Exists(nameDir))
            {
                string logMessage = "\n";
                DirectoryInfo directory = new DirectoryInfo(nameDir);
                Console.WriteLine($"Количество файлов: {directory.GetFiles().Length}");
                logMessage += $"Количество файлов: {directory.GetFiles().Length}\n";
                Console.WriteLine($"Время создания: {directory.CreationTime.ToString()}");
                logMessage += $"Время создания: {directory.CreationTime.ToString()}\n";
                Console.WriteLine($"Количество поддиректориев: {directory.GetDirectories().Length}");
                logMessage += $"Количество поддиректориев: {directory.GetDirectories().Length}\n";
                Console.WriteLine($"Список родительских директориев: {directory.Parent}");
                logMessage += $"Список родительских директориев: {directory.Parent}\n";

                log.LogAction("Вывод информации о директории", logMessage );


            }
            else
            {
                throw new Exception("Данной директории не существует");
            }
        }
    }
}
