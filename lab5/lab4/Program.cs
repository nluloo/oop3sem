using lab6;
using System;
using System.Diagnostics;

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
        static Ilogger logger = new ConsoleLogger();
        static void Zero()
        {
            try
            {
                int a = 100;
                int b = 0;
                int c = 100 / b; // zero
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("DivideByZeroExceptionFUNC: Исключение Zero()");
                logger.LogException(ex);
                throw;
            }



        }
        static void Main(string[] args)
        {
            /*           Product monitor = new Monitor(1, 499, "DELL 321523", 144);
                       Product headphones = new Headphones(1, 100, "Xiaomi", "Внутриканальные");
                       Product pc = new PC(1, 700, "Gaming PC", 16000);
                       Product table = new Table(1, 250, "IKEA Table", 5);
                       Product projector = new Projector(1, 400, "Epson 503", 3000);
                       Product screen = new Screen(1, 200, "Samsung Display", "1920x1080");

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
            */


            logger.LogInfo("Программа запущена.");

            try
            {

                Debugger.Break();
                Debug.Fail("Продолжить выполнение?");
                Zero();
                string productName = null;
                Product monitor = new Monitor(1, 200, productName, 144); // null


                int price = -200; // Пример некорректной цены
                Debug.Assert(price >= 0, "Цена не может быть отрицательной"); // Проверка условия
                Product monitor1 = new Monitor(1, price, "DELL 321523", 144); // negative price


                Product table = new Table(1, 250, "IKEA Table", 5); // ид отдела
                table.set_dep(0, "Техника");
                IdDep tech = IdDep.Technique;

                if (table is Table && table.return_id_department() == (int)tech)
                {
                    throw new TechOrFurnException("TechOrFurnException: Неверно указан id отдела", "Техника");
                }


                Product monitor3 = new Monitor(2, 499, "DELL 321523", 144); // Назначение неправильно ид 


            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"DivideByZeroException: {ex.Message}");
                logger.LogException(ex);
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine($"NullReferenceException: {ne.Message}");
                logger.LogException(ne);
            }
            catch(NegativePriceException nep)
            {
                Console.WriteLine($"NegativePriceException: {nep.Message}. Price: ${nep.InvalidPrice}");
                logger.LogException(nep);
            }
            catch(TechOrFurnException te)
            {
                Console.WriteLine(te.Message);
                logger.LogException(te);
            }
            catch (OutOfRangeProducts exr) {
                Console.WriteLine($"OutOfRangeProducts: {exr.Message}\nВведенное значение: {exr.value}");
                logger.LogException(exr);
            }

            catch(Exception e) 
            {
                Console.WriteLine($"Exception: {e.Message}.");
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
