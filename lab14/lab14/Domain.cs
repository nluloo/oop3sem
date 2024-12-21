using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Loader;
using System.Reflection;


namespace lab14
{
    internal class Domain
    {
        public static void DomainManipul()
        {
            Console.WriteLine($"Текущий домен: {AppDomain.CurrentDomain.FriendlyName}");
            Console.WriteLine($"Базовый путь: {AppDomain.CurrentDomain.BaseDirectory}");

            Console.WriteLine("Все загруженные сборки текущего домена:");
            int i = 0;
            foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine($"{++i}. {item.FullName}");
            }


            var newDomain = new AssemblyLoadContext(name: "NewDomain", isCollectible: true);
            Console.WriteLine($"Создан новый домен: {newDomain.Name}");

            try
            {
                Console.WriteLine("Загружаем сборку Newtonsoft.Json...");
                var assembly = newDomain.LoadFromAssemblyName(new AssemblyName("Newtonsoft.Json"));
                Console.WriteLine($"Сборка {assembly.FullName} успешно загружена.");

                Console.WriteLine("Все загруженные сборки текущего домена:");
                int j = 0;
                foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
                {
                    Console.WriteLine($"{++j}. {item.FullName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке сборки: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Выгружаем контекст загрузки");
                newDomain.Unload();
                Console.WriteLine("Контекст загрузки успешно выгружен");
            }
        }

    }
}
