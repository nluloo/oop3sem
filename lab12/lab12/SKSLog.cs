using System;
using System.IO;

namespace lab12
{
    public class SKSLog
    {
        private readonly string logFilename;

        public SKSLog(string filename)
        {
            logFilename = filename;
        }

        public void LogAction(string action, string filePath = "")
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(logFilename, true);
                string logEntry = $"{DateTime.Now}: {action} - {filePath}";
                writer.WriteLine(logEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
            finally
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при закрытии файла: {ex.Message}");
                    }
                }
            }
        }

        public void ReadLog()
        {
            StreamReader reader = null;
            try
            {
                if (File.Exists(logFilename))
                {
                    reader = new StreamReader(logFilename);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Лог-файл не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при закрытии файла: {ex.Message}");
                    }
                }
            }
        }

        public void SearchInLog(string searchTerm)
        {
            StreamReader reader = null;
            try
            {
                if (File.Exists(logFilename))
                {
                    reader = new StreamReader(logFilename);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(searchTerm))
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Лог-файл не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске в файле: {ex.Message}");
            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при закрытии файла: {ex.Message}");
                    }
                }
            }
        }


        public static void SearchByDate(DateTime date)
        {
            StreamReader reader = new StreamReader("SKSlogfile.txt");
            string line;
            string dateStr = date.ToString("dd.MM.yyyy");
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(dateStr))
                {
                    Console.WriteLine(line);
                }
            }
            reader.Close();
        }

        static public void SearchByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (StreamReader reader = new StreamReader("SKSlogfile.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Попробуем извлечь дату из начала строки
                        if (line.Length >= 19 && DateTime.TryParseExact(line.Substring(0, 19), "dd.MM.yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime logDate))
                        {
                            if (logDate >= startDate && logDate <= endDate)
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске в файле: {ex.Message}");
            }
        }







    }
}
