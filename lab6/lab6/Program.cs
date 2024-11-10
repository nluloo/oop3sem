using System;
using System.Diagnostics;
using System.IO;

namespace lab6
{

    internal class Program
    {
        static void FileErrorEx(SessionDataBase bd)
        {
            try
            {
                bd.Name_DataBase = "SQL";
            }
            catch (FailConnectionException e)
            {
                bd.logger.LogException(e);
                throw;
            }
        }

        static void Main(string[] args)
        {
            Ilogger logger = new ConsoleLogger();


            logger.LogInfo("Программа запущена.");

            SessionDataBase dataBase = new SessionDataBase();

            dataBase.SetTypeLog(logger);

            try
            {
                // Ошибка с номером базы данных
                dataBase.Set_number = 11; // Превышает допустимый размер

                // Попытка задать неверное имя базы данных
                dataBase.Name_DataBase = "SQLite"; // Недопустимое имя

                // Отключение от базы данных
                dataBase.Disconnect(); // Еще не подключена база данных

                // Деление на ноль
                dataBase.DivideByZero(); // Деление на ноль

                // Чтение несуществующего файла
                dataBase.ReadFileException("hello.txt"); // Файл не найден
            }
            catch (DataBaseArgumentsException e)
            {
                logger.LogException(e);
            }
            catch (FailConnectionException e)
            {
                logger.LogException(e);
            }
            catch (DataBaseException e)
            {
                logger.LogException(e);
            }
            catch (DivideByZeroException e)
            {
                logger.LogException(e);
            }
            catch (FileNotFoundException e)
            {
                logger.LogException(e);
            }
            catch (Exception e)
            {
                // Универсальный обработчик исключений
                logger.LogException(e);
            }
            finally
            {
                logger.LogInfo("Программа завершена. Все операции выполнены.");
            }

            Console.ReadLine();
        }
    }
}
