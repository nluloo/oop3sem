using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    internal static class SKSDiskInfo
    {
        public static void DiskInfo(string nameDisk, SKSLog log)
        {
            var driver = DriveInfo.GetDrives().Where(disk => disk.Name == nameDisk).FirstOrDefault();

            if (driver != null)
            {
                string logMessage = "\n";

                Console.WriteLine($"Название: {driver.Name}");
                logMessage += $"Название: {driver.Name}\n";

                Console.WriteLine($"Тип: {driver.DriveType}");
                logMessage += $"Тип: {driver.DriveType}\n";

                Console.WriteLine($"Файловая система: {driver.DriveFormat}");
                logMessage += $"Файловая система: {driver.DriveFormat}\n";

                if (driver.IsReady)
                {
                    Console.WriteLine($"Объем диска: {driver.TotalSize}");
                    logMessage += $"Объем диска: {driver.TotalSize}\n";

                    Console.WriteLine($"Свободное пространство: {driver.TotalFreeSpace}");
                    logMessage += $"Свободное пространство: {driver.TotalFreeSpace}\n";

                    Console.WriteLine($"Метка диска: {driver.VolumeLabel}");
                    logMessage += $"Метка диска: {driver.VolumeLabel}\n";

                    Console.WriteLine($"Доступный объём: {driver.AvailableFreeSpace}\n");
                    logMessage += $"Доступный объём: {driver.AvailableFreeSpace}\n";
                }

                log.LogAction("Получение информации о диске", logMessage);
            }
            else
            {
                Console.WriteLine("Диск не найден.");
                log.LogAction("Ошибка", $"Диск {nameDisk} не найден.");
            }
        }
    }
}
