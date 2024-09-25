using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace lab2
{
    partial class Triangle
    {
        Point A, B, C;
        const double pi = 3.14;
        private DateTime DateTime { get { return DateTime.Now; } }
        static int count;
        private double AB {
            get;
            set;
        }
        private double BC { get; set; }
        private double CA { get; set; }
        private readonly int ID;
        private double Per { get; set; }
        private string name_triangle;
        private string type_triangle = "Произвольный";

        public DateTime return_date_create()
        {
            return DateTime;
        }

        public Triangle()
        {

            A = new Point(1, 2);
            B = new Point(2, 3);
            C = new Point(3, 4);
            ID = CalculId(A, B, C);
            count++;
            computing();
        }

        static Triangle()
        {
            count = 0;
        }
        public void set_name_triangle(string name_triangle)
        {
            this.name_triangle = name_triangle;
        }
        private double[] MaxVer()
        {
            double[] max = { AB,BC,CA};
            for(int i = 0; i < max.Length; i++)
            {
                for(int j = i + 1; j < max.Length; j++)
                {
                    if (max[i] > max[j])
                    {
                        double temp = max[i];
                        max[i] = max[j];
                        max[j] = temp;
                    }
                }
            }
            return max;
        }

        public double select_perim()
        {
            return this.Per;
        }

        public void selectType()
        {
            double epsilon = 0.0001;

            if (Math.Abs(AB - BC) < epsilon && Math.Abs(BC - CA) < epsilon)
            {
                type_triangle = "Равносторонний";
            }
            else if (AB == BC || BC == CA || AB == CA) {
                type_triangle = "Равнобедренный";
            }
            double[] max = MaxVer();
            if ((float)Math.Pow(max[0], 2) + (float)Math.Pow(max[1], 2) == (float) Math.Pow(max[2], 2))
            {
                type_triangle = "Прямоугольный";
            }
        }

        public Triangle(string name)
        {
            A = new Point(0, 0);
            B = new Point(10, 0);
            C = new Point(0, 30);
            name_triangle = name;
            count++;
            ID = CalculId(A, B, C);
            computing();
        }

        public string NameTriangle()
        {
            return name_triangle;
        }
        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
            ID = CalculId(A, B, C);
            count++;
            computing();
        }

        public void computing()
        {
            double ab, bc, ca;
            Dl(ref A, ref B, ref C, out ab, out bc, out ca);
            AB = ab;
            BC = bc;
            CA = ca;
            Perim();
            selectType();
        }

       public override string ToString()
{
    return $"Triangle Name: {name_triangle}\n" +
           $"Count: {count}\n" +
           $"Point A: {A}\n" +
           $"Point B: {B}\n" +
           $"Point C: {C}\n" +
           $"AB: {AB}\n" +
           $"BC: {BC}\n" +
           $"CA: {CA}\n" +
           $"Perimeter: {Per}\n" +
           $"ID: {ID}\n" +
           $"Type: {type_triangle}\n" +
           $"Date create: {DateTime}";
}
    }

    partial class Triangle
    {
        private void Dl(ref Point a, ref Point b, ref Point c, out double ab, out double bc, out double ca)
        {
            ab = Math.Sqrt(Math.Pow((b.RetCoordX() - a.RetCoordX()), 2) + Math.Pow((b.RetCoordY() - a.RetCoordY()), 2));
            bc = Math.Sqrt(Math.Pow((c.RetCoordX() - b.RetCoordX()), 2) + Math.Pow((c.RetCoordY() - b.RetCoordY()), 2));
            ca = Math.Sqrt(Math.Pow((a.RetCoordX() - c.RetCoordX()), 2) + Math.Pow((a.RetCoordY() - c.RetCoordY()), 2));
        }
        private int CalculId(Point a, Point b, Point c)
        {
            double res = ((a.RetCoordX() + b.RetCoordY()) / pi + (a.RetCoordX() + b.RetCoordX()) / 33) * 100;
            return (int)res;
        }
        public override int GetHashCode()
        {
            unchecked 
            {
                int hash = 1;
                hash = hash * 11 + A.GetHashCode();
                hash = hash * 11 + B.GetHashCode();
                hash = hash * 11 + C.GetHashCode();
                return hash;
            }
        }
        private double Perim()
        {
            Per = AB + BC + CA;
            return Per;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Triangle other))
            {
                return false;
            }

            return this.Perim() == other.Perim();
        }

        static public Triangle MaxTrian(Triangle[] triangles)
        {
            Triangle max = triangles[0];
            for(int i = 0; i < triangles.Length; i++)
            {
                if(max.select_perim() < triangles[i].select_perim())
                {
                    max = triangles[i];
                }
            }
            return max;
        }
        static public Triangle MinTrian(Triangle[] triangles)
        {
            Triangle min = triangles[0];
            for (int i = 0; i < triangles.Length; i++)
            {
                if (min.select_perim() < triangles[i].select_perim())
                {
                    min = triangles[i];
                }
            }
            return min;
        }

        static int[] count_types = { 0,0,0,0};

        static private void write_types()
        {
            for(int i = 0; i < count_types.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine($"Равносторонних: {count_types[i]}");
                        break;
                    case 1:
                        Console.WriteLine($"Равнобедренных: {count_types[i]}");
                        break;
                    case 2:
                        Console.WriteLine($"Прямоугольных: {count_types[i]}");
                        break;
                    case 3:
                        Console.WriteLine($"Произвольных: {count_types[i]}");
                        break;
                }
            }   
        }

        static public void count_type(Triangle[] triangles)
        {
            for(int i = 0;i < triangles.Length; i++)
            {
                switch (triangles[i].type_triangle)
                {
                    case "Равносторонний":
                        count_types[0]++;
                        break;
                    case "Равнобедренный":
                        count_types[1]++;
                        break;
                    case "Прямоугольный":
                        count_types[2]++;
                        break;
                    case "Произвольный":
                        count_types[3]++;
                        break;
                }
            }
            write_types();
        }

    }


    class Point
    {
        private double x { get; set; }
        private double y { get; set; }

        public double RetCoordX()
        {
            return x;
        }
        public double RetCoordY()
        {
            return y;
        }

        public Point(double x = 1, double y = 1)
        {
            this.x = x;
            this.y = y;
        }



    public override string ToString()
        {
            return $"({x}, {y})";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(1, 2);
            Point p2 = new Point(2, 3);
            Point p3 = new Point(10, 10);
            Triangle t = new Triangle(p, p2, p3);
            t.set_name_triangle("Крутой треугольник");

            Console.WriteLine(t.ToString());
            Console.ReadLine();

            Triangle pii;
            pii = new Triangle("Треугольник по умолчанию");
            Console.WriteLine(pii.ToString());
            Console.ReadLine();
            t.Equals(pii);

            Triangle t2 = new Triangle(new Point(0,0), new Point(10000, 0), new Point(0, 2000));
            Triangle t3 = new Triangle(new Point(0, 0), new Point(2, 0), new Point(1, 2));
            Triangle t4 = new Triangle(new Point(0, 0), new Point(4, 0), new Point(0, 3));
            Triangle t5 = new Triangle(new Point(0, 0), new Point(-5, 8.7), new Point(5, 8.7));
            t2.set_name_triangle("ВТОРОЙ");
            Console.WriteLine(t2.ToString());
            Console.WriteLine(t3.ToString());
            Console.WriteLine(t4.ToString());
            Console.WriteLine(t5.ToString());

            Triangle[] triangles = {t,pii, t2,t3,t4,t5};

            Console.WriteLine(Triangle.MinTrian(triangles).ToString());
            Console.WriteLine(Triangle.MaxTrian(triangles).ToString());

            Triangle.count_type(triangles);

            Console.WriteLine("--------------------------------------------");

            Console.WriteLine(t.GetHashCode());

            Console.WriteLine("--------------------------------------------");

            Console.WriteLine(t.Equals(pii));

            var triangle = new Triangle(new Point(1, 2), new Point(2, 3), new Point(3, 4));
            triangle.set_name_triangle("Анонимный треугольник");
            Console.WriteLine(triangle);

            Console.ReadLine();
        }
    }
}
