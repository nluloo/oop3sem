using System;

namespace lab4
{

    enum IdDep
    {
        Technique, Furniture, Clothing, Food
    }

    enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    struct DepWorking
    {
        public IdDep Dep { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosedTime { get; set; }
        public TimeSpan CurrentTime { get; set; }

        public DepWorking(IdDep dep, TimeSpan openingTime, TimeSpan closedTime)
        {
            Dep = dep;
            OpeningTime = openingTime;
            ClosedTime = closedTime;
            CurrentTime = DateTime.Now.TimeOfDay;
        }

        
        public void ShowWorking(DayOfWeek day)
        {
            if (IsWeekend(day))
            {
                Console.WriteLine($"Отдел {Dep} работает с 10:00 до 18:00 в выходные дни.");
            }
            else
            {
                Console.WriteLine($"Отдел {Dep} работает с {OpeningTime} до {ClosedTime} в будние дни.");
            }
        }

        
        public bool IsDepartmentOpen(DayOfWeek day)
        {
            if (IsWeekend(day))
            {
                return CurrentTime >= TimeSpan.FromHours(10) && CurrentTime <= TimeSpan.FromHours(18);
            }
            else
            {
                return CurrentTime >= OpeningTime && CurrentTime <= ClosedTime;
            }
        }

        
        private bool IsWeekend(DayOfWeek day)
        {
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        
        public void IsOpen(DayOfWeek day)
        {
            if (IsDepartmentOpen(day))
            {
                Console.WriteLine($"Отдел {Dep} сейчас открыт.Текущее время: {CurrentTime.Hours}:{CurrentTime.Minutes}");
            }
            else
            {
                Console.WriteLine($"Отдел {Dep} сейчас закрыт.Текущее время: {CurrentTime.Hours}:{CurrentTime.Minutes}");
            }
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Product monitor = new Monitor(499, "DELL 321523", 144);
            Product headphones = new Headphones(100, "Xiaomi", "Внутриканальные");
            Product pc = new PC(700, "Gaming PC", 16000);
            Product table = new Table(250, "IKEA Table", 5);
            Product projector = new Projector(400, "Epson 503", 3000);
            Product screen = new Screen(200, "Samsung Display", "1920x1080");

            Product[] products = { monitor, headphones, pc, table, projector, screen };

            Printer printer = new Printer();

            Furniture tablee = new Table(500, "Стол", 10);

            foreach (Product product in products)
            {
                Console.WriteLine(product.ToString());

                if (product is Monitor mon)
                {
                    mon.ShowFeatures();
                }
                else if (product is Headphones head)
                {
                    head.ShowFeatures();
                }
                else if (product is PC pcObj)
                {
                    pcObj.ShowFeatures();
                }
                else if (product is Table tableObj)
                {
                    tablee.ShowFeatures();
                    tableObj.ShowFeatures();
                }
                else if (product is Projector proj)
                {
                    proj.ShowFeatures();
                }
                else if (product is Screen screenObj)
                {
                    screenObj.ShowFeatures();
                }

                Console.WriteLine("\n=====IAmPrinting====\n");
                printer.IAmPrinting(product);
                Console.WriteLine("\n=====IAmPrinting====\n");
            }

            Console.WriteLine("\n--- Использование методов интерфейса Ipowerable через оператор 'as' ---\n");

            Ipowerable powerableDevice = monitor as Ipowerable;
            if (powerableDevice != null)
            {
                powerableDevice.TurnOn();
                powerableDevice.Show();
                powerableDevice.TurnOff();
            }

            Technique powerableDev = new PC(1000, "Mac", 16000);
            if (powerableDev != null)
            {
                powerableDev.Show();
            }

            powerableDevice = pc as Ipowerable;
            if (powerableDevice != null)
            {
                powerableDevice.TurnOn();
                powerableDevice.Show();
                powerableDevice.TurnOff();
            }

            powerableDevice = projector as Ipowerable;
            if (powerableDevice != null)
            {
                powerableDevice.TurnOn();
                powerableDevice.Show();
                powerableDevice.TurnOff();
            }

            powerableDevice = screen as Ipowerable;
            if (powerableDevice != null)
            {
                powerableDevice.TurnOn();
                powerableDevice.Show();
                powerableDevice.TurnOff();
            }

            powerableDevice = table as Ipowerable;
            if (powerableDevice != null)
            {
                powerableDevice.TurnOn();
                powerableDevice.Show();
                powerableDevice.TurnOff();
            }
            else
            {
                Console.WriteLine("Объект класса Table не реализует интерфейс Ipowerable.");
            }

            Product pc2 = new PC(1000, "Mac", 32000);


            pc2.GetHashCode();

            Console.WriteLine(pc.Equals(pc2));



            DepWorking techDepartment = new DepWorking(IdDep.Technique, TimeSpan.FromHours(9), TimeSpan.FromHours(20));

            techDepartment.ShowWorking(DayOfWeek.Monday);

            techDepartment.IsOpen(DayOfWeek.Thursday);


            CLabContainer container = new CLabContainer(3);
            CLabContainer.CLabController controller = new CLabContainer.CLabController(container);

            controller.LoadProductsFromFile("data.txt");

            controller.PrintAllItems();


            Console.WriteLine(controller.GetIndex(1));


                controller.Set_Def(0);
                controller.Set_Def(1);

                controller.RemoveItem(0);

                controller.DefectiItems();

                controller.SetObject(0, monitor);

                controller.PrintAllItems();

                controller.SortItemsByPrice();

                controller.PrintTotalCost();


            Console.ReadLine();
        }
    }
}
