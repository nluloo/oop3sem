using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;


namespace lab12
{
    internal class SKSFileManager
    {

        public static void SKSInspect(string nameDir, SKSLog log)
        {
            log.LogAction("Создание директория", @"D:\labs\oop\lab12\SKSInspect");
            Directory.CreateDirectory(@"D:\labs\oop\lab12\SKSInspect");
            log.LogAction("Создание файла", @"D:\labs\oop\lab12\SKSInspect\SKSdirinfo.txt");
            File.Create(@"D:\labs\oop\lab12\SKSInspect\SKSdirinfo.txt").Close();
            var drive = DriveInfo.GetDrives().Where(dr => dr.Name == nameDir).FirstOrDefault();

            using (StreamWriter stream = new StreamWriter(@"D:\labs\oop\lab12\SKSInspect\SKSdirinfo.txt"))
            {
                stream.WriteLine("Список папок: ");
                foreach (var item in drive.RootDirectory.GetDirectories())
                {
                    stream.WriteLine(item.Name);
                }

                stream.WriteLine("Список файлов: ");
                foreach (var item in drive.RootDirectory.GetFiles())
                {
                    stream.WriteLine(item.Name);
                }
            }
            log.LogAction("Копия файла", @"D:\labs\oop\lab12\SKSInspect\SKSdirinfoCOPY.txt");
            File.Copy(@"D:\labs\oop\lab12\SKSInspect\SKSdirinfo.txt", @"D:\labs\oop\lab12\SKSInspect\SKSdirinfoCOPY.txt", true);
            log.LogAction("Удаление файла", @"D:\labs\oop\lab12\SKSInspect\SKSdirinfo.txt");
            File.Delete(@"D:\labs\oop\lab12\SKSInspect\SKSdirinfo.txt");
        }


        public static void CopyFiles(string path, string extension, SKSLog log)
        {
            string nameDir = @"D:\labs\oop\lab12\SKSFile";
            try
            {
                Directory.CreateDirectory(nameDir);
                log.LogAction("Создание директория", nameDir);

                if (Directory.Exists(path))
                {
                    DirectoryInfo dir = new DirectoryInfo(path);
                    var dirFiles = dir.GetFiles().Where(file => file.Extension == extension);

                    foreach (var item in dirFiles)
                    {
                        string destFile = Path.Combine(nameDir, item.Name);
                        File.Copy(item.FullName, destFile, true);
                        Console.WriteLine($"Скопирован файл: {item.FullName} в {destFile}");
                        log.LogAction("Скопирован файл", $"{item.FullName} в {destFile}");
                    }
                }
                else
                {
                    Console.WriteLine("Исходный путь не существует.");
                    log.LogAction("Ошибка", "Исходный путь не существует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при копировании файлов: {ex.Message}");
                log.LogAction("Ошибка при копировании файлов", ex.Message);
            }
        }

        public static void Archive(string dir, SKSLog log)
        {
            try
            {
                string nameDir = @"D:\labs\oop\lab12\SKSFile";
                string archive = @"D:\labs\oop\lab12\SKSFile.zip";

                ZipFile.CreateFromDirectory(nameDir, archive);
                log.LogAction("Создание архива", @"D:\labs\oop\lab12\SKSFile.zip");

                if (Directory.Exists(dir))
                {
                    ZipFile.ExtractToDirectory(archive, dir);
                    log.LogAction("Извлечение файлов из архива", dir);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
