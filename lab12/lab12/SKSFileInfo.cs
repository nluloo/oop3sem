using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    internal class SKSFileInfo
    {
        public static void infoFile(string pathFile, SKSLog log)
        {
            if(File.Exists(pathFile))
            {
                FileInfo file = new FileInfo(pathFile);
                string logmessage = "";
                Console.WriteLine($"Полный путь к файлу: {file.FullName}");
                logmessage += $"Полный путь к файлу: {file.FullName}\n";
                Console.WriteLine($"Размер файла: {file.Length}");
                logmessage += $"Размер файла: {file.Length}\n";
                Console.WriteLine($"Расширение файла: {file.Extension}");
                logmessage += $"Расширение файла: {file.Extension}\n";
                Console.WriteLine($"Имя файла: {file.Name}");
                logmessage += $"Имя файла: {file.Name}\n";
                Console.WriteLine($"Дата создания: {file.CreationTime}");
                logmessage += $"Дата создания: {file.CreationTime}\n";
                Console.WriteLine($"Дата изменения: {file.LastWriteTime}");
                logmessage += $"Дата изменения: {file.LastWriteTime}\n";

                log.LogAction("Получение информации о файле", logmessage );
            }
            else
            {
                throw new Exception("Данного файла не существует");
            }
        }
    }
}
