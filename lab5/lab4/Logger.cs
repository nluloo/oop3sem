using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public interface Ilogger
    {
        void LogInfo(string message);
        void LogException(Exception ex);
    }
    public class FileLogger : Ilogger
    {
        private readonly string logFilePath = "log.txt";

        public void LogInfo(string message)
        {
            LogFile("INFO", message);
        }

        public void LogException(Exception ex)
        {
            LogFile("EXCEPTION", $"{ex.Message}\nStack Trace: {ex.StackTrace}");
        }

        private void LogFile(string logType, string message)
        {
            string logEntry = $"{DateTime.Now}: {logType}: {message}";

            // Запись в файл
            try
            {
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"Ошибка записи в лог файл: {ioEx.Message}");
            }
        }
    }

    public class ConsoleLogger : Ilogger
    {
        public void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public void LogException(Exception ex)
        {
            Log("EXCEPTION", $"{ex.Message}\nStack Trace: {ex.StackTrace}");
        }

        private void Log(string logType, string message)
        {
            string logEntry = $"{DateTime.Now}: {logType}: {message}";
            Console.WriteLine(logEntry);
        }
    }
}
