using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace lab3
{
    internal class CollectionType<T> : IGeneric<T>
    {
        private List<T> list = new List<T>();

        public void Add(T obj)
        {
            list.Add(obj);
        }

        public void Remove(T obj)
        {
            try
            {
                if (!list.Remove(obj))
                {
                    throw new Exception("Объект не содержится в списке, поэтому не может быть удалён.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("________________ОБРАБОТКА ИСКЛЮЧЕНИЯ ЗАКОНЧЕНА____________________");
            }
        }

        public void GetInfo()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            foreach (T obj in list)
            {
                Console.WriteLine(obj);
            }
        }

        public void SaveToFile(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Данные сохранены в {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Операция сохранения выполнена.");
            }
        }

        public void ReadFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    list = JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
                    Console.WriteLine($"Данные загружены из {filePath}");
                }
                else
                {
                    Console.WriteLine("Файл не существует.");
                }
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Ошибка десериализации: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке из файла: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Операция загрузки завершена.");
            }
        }
    }
}
