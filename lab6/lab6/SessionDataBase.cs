using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class SessionDataBase
    {
        private string name_dataBase;
        private const int MaxSize = 10;
        private int set_number;
        private bool isConnected = false;
        public Ilogger logger;


        public void SetTypeLog(Ilogger logger)
        {
            this.logger = logger;
        }

        public int Set_number
        {
            get => set_number;
            set
            {
                Debug.Assert(value > -1, $"Ошибка: значение номера базы данных должно быть не отрицательным. Переданной значение: {value}");
                if (value > MaxSize)
                {
                    throw new DataBaseArgumentsException("Выход за пределы базы данных", value);
                }
                else
                {
                    set_number = value;
                }
            }
        }

        public string Name_DataBase
        {
            get => name_dataBase;
            set
            {
                if (value != "MySQL" && value != "Postgres")
                {
                    throw new FailConnectionException("Не удается найти базу данных под данным именем", value);
                }
                else
                {
                    name_dataBase = value;
                    isConnected = true;
                    logger.LogInfo($"База данных {name_dataBase} успешно подключена.");
                }
            }
        }

        public void Disconnect()
        {
            if (!isConnected)
            {
                throw new DataBaseException("База данных не подключена, невозможно отключиться.");
            }
            else
            {
                isConnected = false;
                logger.LogInfo("База данных успешно отключена.");
            }
        }

        public int DivideByZero()
        {
            int a = 4;
            int b = a / 0; // Исключение деления на ноль
            return b;
        }

        public void ReadFileException(string name_file)
        {
            if (!File.Exists(name_file))
            {
                throw new FileNotFoundException("Файл не найден", name_file);
            }
        }
    }
}
