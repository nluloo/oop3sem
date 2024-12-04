using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            int n = 4;
            Console.WriteLine("----------ВЫБОРКА СЛОВ МЕНЬШЕ n-------------");
            var ResultMonth = from p in months
                              where p.Length < n
                              select p;

            foreach (string item in ResultMonth)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("----------ВЫБОРКА ЗИМНИХ И ЛЕТНИХ МЕСЯЦЕВ-------------");
            var summerMonths = months.Where(month => 
                                                month.CompareTo("June") == 0 || month.CompareTo("July") == 0 || month.CompareTo("August") == 0 || month.CompareTo("December") == 0 || month.CompareTo("January") == 0 || month.CompareTo("February") == 0);


            foreach (var month in summerMonths)
            {
                Console.WriteLine(month);
            }


            Console.WriteLine("----------СОРТИРОВКА МЕСЯЦЕВ ПО АЛФАВИТУ-------------");

            var Result = from p in months
                         orderby p
                         select p;


            foreach (var month in Result)
            {
                Console.WriteLine(month);
            }

            Console.WriteLine("----------ВЫВОД КОЛИЧЕСТВА СЛОВ В КОТОРЫХ СОДЕРЖИТСЯ u И ДЛИНА НЕ МЕНЕЕ 4-------------");
            var result = months.Where(month => month.Contains("u") && month.Length >= 4).OrderBy(month => month).Count();

            Console.WriteLine(result);

            Console.ReadLine();
            Console.Clear();

            List<Triangle> triangles = new List<Triangle>();

            triangles.Add(new Triangle(new Point(4, 2), new Point(6, 7), new Point(8, 2)));
            triangles.Add(new Triangle(new Point(-2, -2), new Point(2, -2), new Point(0, 2)));
            triangles.Add(new Triangle(new Point(1, 1), new Point(4, 1), new Point(2, 5)));
            triangles.Add(new Triangle(new Point(0, 0), new Point(3000, 0), new Point(0, 3000)));
            triangles.Add(new Triangle(new Point(2, -1), new Point(5, 2), new Point(0, 4)));
            triangles.Add(new Triangle(new Point(-4, 1), new Point(1, 4), new Point(-2, 2)));
            triangles.Add(new Triangle(new Point(0, 0), new Point(6, 0), new Point(3, 6)));
            triangles.Add(new Triangle(new Point(-1, -3), new Point(2, -1), new Point(0, 2)));
            triangles.Add(new Triangle(new Point(3, 0), new Point(6, 3), new Point(0, 6)));
            triangles.Add(new Triangle(new Point(-2, 2), new Point(2, -2), new Point(4, 0)));

            Console.WriteLine("----------ПОДСЧЕТ КОЛИЧЕСТВА ТРЕУГОЛЬНИКОВ, НАХОЖДЕНИЕ МАКС МИН В ГРУППЕ-------------");
            var typeCounts = triangles
                .GroupBy(t => t.type_triangle) // Группируем по полю type_triangle
                .Select(g => new
                {
                    Type = g.Key, // Тип треугольника
                    Count = g.Count(), // Количество треугольников данного типа
                    MaxPerim = g.Max(t => t.Per), // Макс периметр в группе
                    MinPerim = g.Min(t => t.Per) // Мин периметр в группе
                });

            // Вывод информации о группах
            foreach (var item in typeCounts)
            {
                Console.WriteLine($"Тип: {item.Type}");
                Console.WriteLine($"Количество: {item.Count}");
                Console.WriteLine($"Максимальный периметр: {item.MaxPerim}");
                Console.WriteLine($"Минимальный периметр: {item.MinPerim}");
                Console.WriteLine();
            }

            Console.WriteLine("----------МИНИМАЛЬНАЯ ПЛОЩАДЬ-------------");
            var minArea = triangles.Min(p=>p.Area);
            Console.WriteLine($"Минимальная площадь: {minArea}");


            Console.ReadLine();
            Console.Clear();
            double m = 3;
            double ni = 6;
            Console.WriteLine("----------ОГРАНИЧЕНИЕ ПО ДЛИНЕ-------------");
            var ResultSides = triangles.Where(t => (t.AB < ni && t.AB > m) &&
                                                   (t.BC < ni && t.BC > m) &&
                                                   (t.CA < ni && t.CA > m))
                                       .OrderBy(t => t.Per); 

            foreach (var item in ResultSides)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("----------УПОРЯДОЧЕННЫЙ ПО СУММЕ ДЛИН СТОРОН-------------");
            var orderedTriangles = triangles.OrderBy(t => t.Per).ToArray();

            foreach (var item in orderedTriangles)
            {
                Console.WriteLine(item.Per);
            }

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("-----------ГРУППЫ ПО ТИПУ, ПОДСЧЕТ КОЛИЧЕСТВА, СРЕДНЯЯ ПЛОЩАДЬ, ВЫВОД ПЕРИМЕТРА ПО УБЫВАНИЮ, ОГРАНИЧЕНИЕ ВЗЯТИЯ ГРУППЫ------------");
            var triangleReport = triangles
                        .Where(t => t.Area > 0) // Указать другую площадь!!!!!
                        .Select(t => new { Triangle = t, Type = t.type_triangle, Perimeter = t.select_perim() }) // Проекция
                        .OrderByDescending(t => t.Perimeter) // Упорядочивание
                        .GroupBy(t => t.Type) // Группировка
                        .Select(group => new
                         {
                        Type = group.Key,
                        Count = group.Count(), // Агрегирование
                        AverageArea = group.Average(t => t.Triangle.Area), // Агрегирование
                        Triangles = group.ToList()
                        })
                        .Where(group => group.Count >= 2) // Количество треугольников в группе не меньше 2
                        .Take(3); // Разбиение


            foreach (var group in triangleReport)
            {
                Console.WriteLine($"Тип: {group.Type}");
                Console.WriteLine($"Количество: {group.Count}");
                Console.WriteLine($"Средняя площадь: {group.AverageArea}");
                foreach (var triangle in group.Triangles)
                {
                    Console.WriteLine($"  Периметр: {triangle.Perimeter}, Площадь: {triangle.Triangle.Area}");
                }
            }

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("----------РАБОТА JOIN-------------");
            var students = new[]
            {
                new {ID = 24, name = "Кирилл"},
                new {ID = 12, name = "Денис"},
                new {ID = 16, name = "Максим"},
                new {ID = 20, name = "Алексей"},
            };
            var GradesOOP = new[]
            {
                new {studID = 24, grades = 9},
                new {studID = 12, grades = 8},
                new {studID = 16, grades = 7},
                new {studID = 20, grades = 6},
                new {studID = 2, grades = 10},
            };


            var Grades = students
                        .Join(
                         GradesOOP,
                         id => id.ID,
                         grID => grID.studID,
                         (id, grID) => new
                         {
                             name = id.name,
                             grade = grID.grades
                         }
                         );

            

            foreach(var pair in Grades)
            {
                Console.WriteLine(pair);
            }

            Console.ReadLine();
        }
    }
}
