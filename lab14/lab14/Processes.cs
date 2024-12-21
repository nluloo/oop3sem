using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace lab14
{
    public static class Processes
    {
        public static void WriteAllPricesses()
        {
            Process[] processes = Process.GetProcesses();

            using(StreamWriter sw = new StreamWriter("..\\Processes.txt"))
            {
                foreach(Process process in processes)
                {
                    try
                    {
                        sw.WriteLine($"ID: {process.Id} | Имя процесса: {process.ProcessName} | Приоритет: {process.BasePriority} | Время начала: {process.StartTime} | Время использования: {process.TotalProcessorTime}");

                    }
                    catch(Exception ex)
                    {
                        sw.WriteLine($"ERROR: ID: {process.Id} | Имя процесса: {process.ProcessName} | Содержание ошибки: {ex.Message}");
                    }
                }
            }
        }
    }
}
